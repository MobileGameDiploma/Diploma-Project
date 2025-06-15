using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class LootSystem : MonoBehaviour
{
    [Inject] private UISystem _uiSystem;
    [Inject] LevelSystem _levelSystem;
    

    public void GivePrize(int MagicPoints, int ExpPoints)
    {
        _uiSystem.MagicPointsController.AddValue(MagicPoints);
        _levelSystem.AddExp(ExpPoints);
    }
}
