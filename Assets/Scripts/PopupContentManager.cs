using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopupContentManager : MonoBehaviour
{
    [SerializeField] string playerName; // In real game,retrieve the actual name from data
    [SerializeField] int rewardAmount; // retrieve actual reward amount;
    [SerializeField] TMP_Text rewardAmountText;
    [SerializeField] TMP_Text crushText;
    [SerializeField] Image coinIcon;
    [SerializeField] Color nameColor;

    private void Start()
    {
        string hexColor = ColorUtility.ToHtmlStringRGB(nameColor);
        crushText.text = $"YOU CRUSHED <color=#{hexColor}>{playerName}</color>";
    }
}
