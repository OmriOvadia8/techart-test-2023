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
        public bool isActivated = true; // in case some scores aren't shown (retrieve data from actual game)
        public GameObject item;
    }

    [SerializeField] ScoreMultiplier scoreMultiplier;
    [SerializeField] TMP_Text rewardAmountText;
    [SerializeField] int rewardAmount;
    [SerializeField] private float stretchDuration, startScaleX, delayBeforeStart;
    [SerializeField] private List<ScoreItem> scoreItems = new();

    private void Start()
    {
        rewardAmountText.text = rewardAmount.ToString("N0");

        foreach (ScoreItem item in scoreItems)
        {
            item.item.SetActive(false);
        }
    }

    public void AnimateScoreItems()
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

        seq.AppendCallback(RewardBonusTween);

        seq.Play();
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

        foreach (MultiplierItem item in scoreMultiplier.GetMultiplierItems())
        {
            rewardAmount *= item.multiplierValue;
        }

        DOVirtual.Float(0, rewardAmount, 1f, value =>
        {
            rewardAmountText.text = value.ToString("N0");
        })
    .OnComplete(() =>
    {
        rewardAmountText.transform.DOScale(originalScale * 1.2f, 0.5f)
        .OnComplete(() =>
        {
            rewardAmountText.transform.DOScale(originalScale, 0.5f);
        });
    });

    }
}
