using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreMultiplier : MonoBehaviour
{
    [System.Serializable]
    public class ScoreMultiplierItem // all values should be assigned using a config/data in real game scenario
    {
        // Score settings
        public bool IsActivated = true;
        public GameObject ScoreInfoItem;

        // Multiplier settings
        public int MultiplierValue;
        public TMP_Text MultiplierText;
        public CanvasGroup CanvasGroupAlpha;
    }

    public List<ScoreMultiplierItem> ScoreMultiplierItems = new();
    [SerializeField] private int noneValue;
    [SerializeField] private float noneAlphaValue, noneTextSize, normalTextSize, normalAlphaValue;
    [SerializeField] private string noneString;

    private void Start() => RefreshMultiplierDisplays();

    private void RefreshMultiplierDisplays()
    {
        foreach (ScoreMultiplierItem item in ScoreMultiplierItems)
        {
            if (IsMultiplierNone(item))
            {
                SetMultiplierAsNone(item);
            }
            else
            {
                SetMultiplierDisplay(item);
            }
        }
    }

    private bool IsMultiplierNone(ScoreMultiplierItem item)
    {
        return item.MultiplierValue == noneValue;
    }

    private void SetMultiplierAsNone(ScoreMultiplierItem item)
    {
        item.MultiplierText.text = noneString;
        item.MultiplierText.fontSize = noneTextSize;
        item.CanvasGroupAlpha.alpha = noneAlphaValue;
    }

    private void SetMultiplierDisplay(ScoreMultiplierItem item)
    {
        item.MultiplierText.text = item.MultiplierValue.ToMultiplierString();
        item.MultiplierText.fontSize = normalTextSize;
        item.CanvasGroupAlpha.alpha = normalAlphaValue;
    }

    public List<ScoreMultiplierItem> GetMultiplierItems()
    {
        return ScoreMultiplierItems;
    }
}
