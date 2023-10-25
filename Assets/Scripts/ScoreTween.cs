using UnityEngine;
using DG.Tweening;
using TMPro;

public class ScoreTween : MonoBehaviour
{
    [Header("Score Multiplier Settings")]
    [SerializeField] private ScoreMultiplier scoreMultiplier;

    [Header("Reward Amount Settings")]
    [SerializeField] private TMP_Text rewardAmountText;
    [SerializeField] private int rewardAmount; // assign real reward amount via config/data

    [Header("Score Item Animation Settings")]
    [SerializeField] private float stretchDuration;
    [SerializeField] private float startScaleX;
    [SerializeField] private float delayBeforeStart;
    [SerializeField] private float rewardRiseDuration;

    [Header("Reward Text Animation Settings")]
    [SerializeField] private float rewardTextScaleUpFactor = 1.2f;
    [SerializeField] private float rewardTextAnimationDuration = 0.5f;

    private void Start() => InitializeScoreItems();

    private void InitializeScoreItems()
    {
        rewardAmountText.text = rewardAmount.ToN0String();

        foreach (var item in scoreMultiplier.GetMultiplierItems())
        {
            item.ScoreInfoItem.SetActive(false);
        }
    }

    public void AnimateScoreItems()
    {
        Sequence seq = CreateScoreItemSequence();
        seq.AppendCallback(RewardBonusTween);
        seq.Play();
    }

    private Sequence CreateScoreItemSequence()
    {
        Sequence seq = DOTween.Sequence();

        foreach (var multiplierItem in scoreMultiplier.GetMultiplierItems())
        {
            if (multiplierItem.IsActivated)
            {
                seq.AppendCallback(() => StretchFromLeft(multiplierItem));
                seq.AppendInterval(stretchDuration + delayBeforeStart);
            }
        }

        return seq;
    }

    private void StretchFromLeft(ScoreMultiplier.ScoreMultiplierItem multiplierItem)
    {
        multiplierItem.ScoreInfoItem.SetActive(true);

        RectTransform rectTransform = multiplierItem.ScoreInfoItem.GetComponent<RectTransform>();
        Vector3 originalScale = rectTransform.localScale;

        rectTransform.localScale = new Vector3(startScaleX, originalScale.y, originalScale.z);
        rectTransform.DOScaleX(originalScale.x, stretchDuration);
    }

    public void RewardBonusTween()
    {
        Vector3 originalScale = rewardAmountText.transform.localScale;
        int initialReward = rewardAmount;
        int totalMultiplier = CalculateTotalMultiplier();

        rewardAmount *= totalMultiplier;
        UpdateRewardAmountText(initialReward, originalScale);
    }

    private int CalculateTotalMultiplier()
    {
        int totalMultiplier = 1;

        foreach (var item in scoreMultiplier.GetMultiplierItems())
        {
            if (item.IsActivated)
            {
                totalMultiplier *= item.MultiplierValue;
            }
        }

        return totalMultiplier;
    }

    private void UpdateRewardAmountText(int initialReward, Vector3 originalScale)
    {
        if (initialReward == rewardAmount)
        {
            AnimateRewardTextScale(originalScale);
        }
        else
        {
            DOVirtual.Float(initialReward, rewardAmount, rewardRiseDuration, value =>
            {
                rewardAmountText.text = value.ToN0String();
            })
            .OnComplete(() => AnimateRewardTextScale(originalScale));
        }
    }

    private void AnimateRewardTextScale(Vector3 originalScale)
    {
        rewardAmountText.transform.DOScale(originalScale * rewardTextScaleUpFactor, rewardTextAnimationDuration)
        .OnComplete(() => rewardAmountText.transform.DOScale(originalScale, rewardTextAnimationDuration));
    }
}