using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RewardText : MonoBehaviour
{
    [SerializeField] string name; // In real game,retrieve the actual name from data
    [SerializeField] int rewardAmount; // retrieve actual reward amount;
    [SerializeField] TextMeshPro rewardAmountText;
    [SerializeField] Image coinIcon;

    private void Start()
    {
        rewardAmountText.text = "You crushed <color=#009ac7>" + name + "</color>";
    }


}
