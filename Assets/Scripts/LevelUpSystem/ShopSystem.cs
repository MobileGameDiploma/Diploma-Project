using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using TMPro;
using UnityEngine;
using Zenject;

public class ShopSystem : MonoBehaviour
{
    [Inject]private UIData _uiData;
    [Inject] private PlayerStats _playerStats;
    
    public TextMeshProUGUI DamagePriceText;
    public TextMeshProUGUI SpeedPriceText;
    public TextMeshProUGUI CastSpeedPriceText;
    
    [Inject(Id = "DamageUpgrades")] private List<int> _damageUpgrades;
    [Inject(Id = "SpeedUpgrades")] private List<int> _speedUpgrades;
    [Inject(Id = "CastUpgrades")] private List<int> _castUpgrades;
    
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
    }

    public void DamageUpgrade()
    {
        if (_uiData.MagicPointsData.CurrentValue >= _damageUpgradesPrices[_damageIndex])
        {
            _uiData.MagicPointsData.WithDrawValue(_damageUpgradesPrices[_damageIndex]);
            _playerStats.GetSpellByName("Fireball").Damage += _damageUpgrades[_damageIndex];
            _damageIndex++;
            DamagePriceText.text = NumberConverter.INSTANCE.Convert(_damageUpgradesPrices[_damageIndex]);
        }
    }

    public void SpeedUpgrade()
    {
        if (_uiData.MagicPointsData.CurrentValue >= _speedUpgradesPrices[_speedIndex])
        {
            _uiData.MagicPointsData.WithDrawValue(_speedUpgradesPrices[_speedIndex]);
            _playerStats.Speed += _speedUpgrades[_speedIndex];
            _speedIndex++;
            SpeedPriceText.text = NumberConverter.INSTANCE.Convert(_speedUpgradesPrices[_speedIndex]);
        }
    }

    public void CastSpeedUpgrade()
    {
        if (_uiData.MagicPointsData.CurrentValue >= _castSpeedUpgradesPrices[_castIndex])
        {
            _uiData.MagicPointsData.WithDrawValue(_castSpeedUpgradesPrices[_castIndex]);
            _playerStats.GetSpellByName("Fireball").CastDelay -= _castUpgrades[_castIndex];
            _castIndex++;
            CastSpeedPriceText.text = NumberConverter.INSTANCE.Convert(_castSpeedUpgradesPrices[_castIndex]);
        }
    }
}
