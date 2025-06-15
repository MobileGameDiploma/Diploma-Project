using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "InventoryItem", menuName = "ScriptableObject/UI/ExpData")]
public class ExpData : ScriptableObject
{
    public int CurrentValue;
    public int NextLevelValue;
    public Slider ExpSlider;
    public List<int> LevelExps;
    [FormerlySerializedAs("PrizeSystem")] public LootSystem lootSystem;
    private int index;
    //Add price system

    public void SetExp(int exp)
    {
        CurrentValue = exp;
        ExpSlider.value = exp;
        CheckOnLevelUp();
    }

    public void AddExp(int exp)
    {
        CurrentValue += exp;
        ExpSlider.value = exp;
        CheckOnLevelUp();
    }

    public void RemoveExp(int exp)
    {
        CurrentValue -= exp;
        ExpSlider.value = exp;
    }

    private void CheckOnLevelUp()
    {
        if (CurrentValue >= NextLevelValue)
        {
            NextLevel();
        }
    }

    private void NextLevel()
    {
        if (LevelExps.Count < index)
        {
            SetExp(0);
            NextLevelValue=LevelExps[index];
            ExpSlider.maxValue = NextLevelValue;
            index++;
        }
    }
}
