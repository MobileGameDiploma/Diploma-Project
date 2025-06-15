using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class LevelSystem : MonoBehaviour
{
    public int CurrentValue;
    public int NextLevelValue;
    public Slider ExpSlider;
    public List<int> LevelExps;
    public List<int> LevelUpMagicPoints;
    private int index;
    [Inject] private UISystem _uiSystem;

    private void Awake()
    {
        index = 0;
    }

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
            _uiSystem.ActivatePrizeWindow(LevelUpMagicPoints[index]);
            _uiSystem.MagicPointsController.AddValue(LevelUpMagicPoints[index]);
            index++;
        }
    }
}
