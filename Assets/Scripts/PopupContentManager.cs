using TMPro;
using UnityEngine;
using DG.Tweening;
using static ScoreMultiplier;

public class PopupContentManager : MonoBehaviour
{
    [SerializeField] string playerName; // In real game, retrieve the actual name from data
    [SerializeField] TMP_Text crushText;
    [SerializeField] Color nameColor;

    private void Start()
    {
        string hexColor = ColorUtility.ToHtmlStringRGB(nameColor);
        crushText.text = $"YOU CRUSHED <color=#{hexColor}>{playerName}</color>";
    }
}
