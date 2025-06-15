using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName = "InventoryItem", menuName = "ScriptableObject/InventoryItem")]
public class ItemData : ScriptableObject
{
    public int Id = 0;
    public TMP_Text Editable_Text;
    public int Amount;

    public void SetProperty(int value)
    {
        Amount = value;
        UpdateUI();
    }

    public void AddProperty(int value)
    {
        Amount += value;
    }
    
    public void WithDrawProperty(int value)
    {
        Amount -= value;
    }

    private void UpdateUI()
    {
        Editable_Text.text = NumberConverter.Convert(Amount);
    }
}
