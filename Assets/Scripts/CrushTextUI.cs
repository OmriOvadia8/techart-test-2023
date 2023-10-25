using TMPro;
using UnityEngine;

public class CrushTextUI : MonoBehaviour
{
    [SerializeField] private string playerName; // In the real game, retrieve the actual name from data
    [SerializeField] private TMP_Text crushText;
    [SerializeField] private Color nameColor;

    private void Start()
    {
        UpdateCrushText();
    }

    private void UpdateCrushText()
    {
        string hexColor = ColorUtility.ToHtmlStringRGB(nameColor);
        crushText.text = $"YOU CRUSHED <color=#{hexColor}>{playerName}</color>";
    }
}
