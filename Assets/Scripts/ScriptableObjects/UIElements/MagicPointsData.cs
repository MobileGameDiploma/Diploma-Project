using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName = "InventoryItem", menuName = "ScriptableObject/UI/MagicPointsData")]
public class MagicPointsData : ScriptableObject
{
    public long CurrentValue;
    public TextMeshProUGUI ValueText;

    public void SetValue(long value)
    {
        CurrentValue = value;
        ValueText.text = NumberConverter.Convert(value);
    }

    public void AddValue(int value)
    {
        CurrentValue += value;
        ValueText.text = NumberConverter.Convert(value);
    }

    public void WithDrawValue(int value)
    {
        CurrentValue -= value;
        ValueText.text = NumberConverter.Convert(value);
    }
}
