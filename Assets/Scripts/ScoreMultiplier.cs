using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreMultiplier : MonoBehaviour
{
    [System.Serializable]
    public class MultiplierItem
    {
        public int multiplierValue;
        public TMP_Text multiplierText;
        public CanvasGroup canvasGroupAlpha;
    }

    [SerializeField] private List<MultiplierItem> multiplierItems = new();
    [SerializeField] private int noneValue;
    [SerializeField] private float noneAlphaValue, noneTextSize, normalTextSize, normalAlphaValue;

    private void Start()
    {
        RefreshMultiplierDisplays();
    }

    private void RefreshMultiplierDisplays()
    {
        foreach (MultiplierItem item in multiplierItems)
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

    private bool IsMultiplierNone(MultiplierItem item)
    {
        return item.multiplierValue == noneValue;
    }

    private void SetMultiplierAsNone(MultiplierItem item)
    {
        item.multiplierText.text = "NONE";
        item.multiplierText.fontSize = noneTextSize;
        item.canvasGroupAlpha.alpha = noneAlphaValue;
    }

    private void SetMultiplierDisplay(MultiplierItem item)
    {
        item.multiplierText.text = "X" + item.multiplierValue.ToString();
        item.multiplierText.fontSize = normalTextSize;
        item.canvasGroupAlpha.alpha = normalAlphaValue;
    }

    public List<MultiplierItem> GetMultiplierItems()
    {
        return multiplierItems;
    }
}
