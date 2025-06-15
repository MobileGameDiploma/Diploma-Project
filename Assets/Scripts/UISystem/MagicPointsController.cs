using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MagicPointsController
{
    public long CurrentValue = 0;
    private  TextMeshProUGUI _textValue;

    public MagicPointsController(TextMeshProUGUI textValue)
    {
        _textValue = textValue;
    }
    
    public void SetValue(long value)
    {
        CurrentValue = value;
        _textValue.text = NumberConverter.INSTANCE.Convert(value);
    }

    public void AddValue(int value)
    {
        CurrentValue += value;
        _textValue.text = NumberConverter.INSTANCE.Convert(value);
    }

    public void WithDrawValue(int value)
    {
        CurrentValue -= value;
        _textValue.text = NumberConverter.INSTANCE.Convert(value);
    }
}
