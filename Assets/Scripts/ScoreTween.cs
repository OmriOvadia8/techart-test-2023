using UnityEngine;
using DG.Tweening;
using System.Collections.Generic;
using TMPro;
using static ScoreMultiplier;

public class ScoreTween : MonoBehaviour
{
    [System.Serializable]
    public class ScoreItem
    {
        public bool isActivated = true; // Determine if some scores are shown
        public GameObject item;
    }

    [Header("Score Multiplier Settings")]
    [SerializeField] private ScoreMultiplier scoreMultiplier;

    [Header("Reward Amount Settings")]
    [SerializeField] private TMP_Text rewardAmountText;
    [SerializeField] private int rewardAmount;

    [Header("Score Item Animation Settings")]
    [SerializeField] private float stretchDuration;
    [SerializeField] private float startScaleX;
    [SerializeField] private float delayBeforeStart;
    [SerializeField] private List<ScoreItem> scoreItems = new();

    private void Start()
    {
        InitializeScoreItems();
    }

    private void InitializeScoreItems()
    {
        rewardAmountText.text = rewardAmount.ToString("N0");

        foreach (ScoreItem item in scoreItems)
        {
            item.item.SetActive(false);
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

        foreach (ScoreItem scoreItem in scoreItems)
        {
            if (scoreItem.isActivated)
            {
                seq.AppendCallback(() => StretchFromLeft(scoreItem));
                seq.AppendInterval(stretchDuration + delayBeforeStart);
            }
        }

        return seq;
    }

    private void StretchFromLeft(ScoreItem scoreItem)
    {
        scoreItem.item.SetActive(true);

        RectTransform rectTransform = scoreItem.item.GetComponent<RectTransform>();
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

        foreach (MultiplierItem item in scoreMultiplier.GetMultiplierItems())
        {
            totalMultiplier *= item.multiplierValue;
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
            DOVirtual.Float(initialReward, rewardAmount, 1f, value =>
            {
                rewardAmountText.text = value.ToString("N0");
            })
            .OnComplete(() => AnimateRewardTextScale(originalScale));
        }
    }

    private void AnimateRewardTextScale(Vector3 originalScale)
    {
        rewardAmountText.transform.DOScale(originalScale * 1.2f, 0.5f)
        .OnComplete(() => rewardAmountText.transform.DOScale(originalScale, 0.5f));
    }
}
