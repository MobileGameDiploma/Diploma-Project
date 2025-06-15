using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unity.VisualScripting;
using UnityEngine;

public class NumberConverter
{
    private Dictionary<long, string> numbers = new Dictionary<long, string>();
    
    public static NumberConverter INSTANCE
    {
        get
        {
            if (INSTANCE == null)
            {
                INSTANCE = new NumberConverter();
            }
            return INSTANCE;
        }
        private set
        {
            INSTANCE = value;
        }
    }

    public NumberConverter()
    {
        numbers.Add(1000, "K");
        numbers.Add(1000000, "M");
        numbers.Add(1000000000, "B");
        numbers.Add(1000000000000, "C");
        numbers.Add(1000000000000000, "Q");
        numbers.Add(1000000000000000000, "R");
    }
    
    
    public string Convert(long number)
    {
        string result = string.Empty;

        switch (number)
        {
            case > 1000000000000000000:
                result = AddCommaToString(System.Convert.ToString(number / 1000000000000000), 1) + ' ' + numbers[1000000000000000000];
                break;
            case > 1000000000000000:
                result = AddCommaToString(System.Convert.ToString(number / 1000000000000), 1) + ' ' + numbers[1000000000000000];
                break;
            case > 1000000000000:
                result = AddCommaToString(System.Convert.ToString(number / 1000000000), 1) + ' ' + numbers[1000000000000];
                break;
            case > 1000000000:
                result = AddCommaToString(System.Convert.ToString(number / 1000000), 1) + ' ' + numbers[1000000000];
                break;
            case > 1000000:
                result = AddCommaToString(System.Convert.ToString(number / 1000), 1) + ' ' + numbers[1000000];
                break;
            case > 1000:
                result = AddCommaToString(System.Convert.ToString(number / 1 ), 1) + ' ' + numbers[1000];
                break;
            default:
                result = System.Convert.ToString(number);
                break;
        }
        
        return result;
    }

    private string AddCommaToString(string target, int index)
    {
        StringBuilder sb = new StringBuilder();

        sb.Append(target.Substring(0,target.Length - (target.Length - index)));
        sb.Append(',');
        sb.Append(target.Substring(target.Length - (target.Length - index),target.Length - (target.Length - (target.Length - index)) - 1));
        
        return sb.ToString();
    }
}
