using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InventoryItem", menuName = "ScriptableObject/UI/UIData")]
public class UIData : ScriptableObject
{
    public ExpData ExpData;
    public MagicPointsData MagicPointsData;
    public List<ItemData> InventoryItems;
}
