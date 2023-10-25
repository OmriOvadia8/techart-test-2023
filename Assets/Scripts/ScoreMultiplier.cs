using System.Collections;
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

    public List<MultiplierItem> multiplierItems = new();
    [SerializeField] private int noneValue, normalAlphaValue;
    [SerializeField] float noneAlphaValue = 0.5f;

    private void Start() => UpdateMultipliersDisplay();

    private void UpdateMultipliersDisplay()
    {
        foreach (MultiplierItem item in multiplierItems)
        {
            if (item.multiplierValue == noneValue)
            {
                item.multiplierText.text = "NONE";
                item.canvasGroupAlpha.alpha = noneAlphaValue;
            }
            else
            {
                item.multiplierText.text = "X" + item.multiplierValue.ToString();
                item.canvasGroupAlpha.alpha = normalAlphaValue;
            }
        }
    }

    public List<MultiplierItem> GetMultiplierItems()
    {
        return multiplierItems;
    }

}
