using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using TMPro;
using UnityEngine;
using Zenject;

public class ShopSystem : MonoBehaviour
{
    [Inject]private UISystem _uiSystem;
    [Inject] private PlayerStats _playerStats;
    
    public TextMeshProUGUI DamagePriceText;
    public TextMeshProUGUI SpeedPriceText;
    public TextMeshProUGUI CastSpeedPriceText;
    
    [Inject(Id = "DamageUpgrades")] private List<int> _damageUpgrades;
    [Inject(Id = "SpeedUpgrades")] private List<float> _speedUpgrades;
    [Inject(Id = "CastUpgrades")] private List<float> _castUpgrades;
    
    [Inject(Id = "DamageUpgradesPrices")] private List<int> _damageUpgradesPrices;
    [Inject(Id = "SpeedUpgradesPrices")] private List<int> _speedUpgradesPrices;
    [Inject(Id = "CastSpeedUpgradesPrices")] private List<int> _castSpeedUpgradesPrices;

    private int _damageIndex;
    private int _speedIndex;
    private int _castIndex;

    private void Awake()
    {
        _damageIndex = 0;
        _speedIndex = 0;
        _castIndex = 0;
        NumberConverter.SetUp();
    }

    public void DamageUpgrade()
    {
        if (_uiSystem.MagicPointsController.CurrentValue >= _damageUpgradesPrices[_damageIndex])
        {
            _uiSystem.MagicPointsController.WithDrawValue(_damageUpgradesPrices[_damageIndex]);
            _playerStats.GetSpellByName("Fireball").Damage += _damageUpgrades[_damageIndex];
            _damageIndex++;
            DamagePriceText.text = NumberConverter.Convert(_damageUpgradesPrices[_damageIndex]);
        }
    }

    public void SpeedUpgrade()
    {
        if (_uiSystem.MagicPointsController.CurrentValue >= _speedUpgradesPrices[_speedIndex])
        {
            _uiSystem.MagicPointsController.WithDrawValue(_speedUpgradesPrices[_speedIndex]);
            _playerStats.Speed += _speedUpgrades[_speedIndex];
            _speedIndex++;
            SpeedPriceText.text = NumberConverter.Convert(_speedUpgradesPrices[_speedIndex]);
        }
    }

    public void CastSpeedUpgrade()
    {
        if (_uiSystem.MagicPointsController.CurrentValue >= _castSpeedUpgradesPrices[_castIndex])
        {
            _uiSystem.MagicPointsController.WithDrawValue(_castSpeedUpgradesPrices[_castIndex]);
            _playerStats.GetSpellByName("Fireball").CastDelay -= _castUpgrades[_castIndex];
            _castIndex++;
            CastSpeedPriceText.text = NumberConverter.Convert(_castSpeedUpgradesPrices[_castIndex]);
        }
    }
}
