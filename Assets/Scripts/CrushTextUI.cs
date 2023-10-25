using TMPro;
using UnityEngine;

public class CrushTextUI : MonoBehaviour
{
    // all values should be assigned using a config/data in real game scenario
    [SerializeField] private string playerName; 
    [SerializeField] private TMP_Text crushText;
    [SerializeField] private string actionString; 
    [SerializeField] private Color nameColor;

    private void Start() => UpdateCrushText();

    private void UpdateCrushText()
    {
        string hexColor = ColorUtility.ToHtmlStringRGB(nameColor);
        crushText.text = actionString.FormatWithColor(playerName, hexColor);
    }
}
