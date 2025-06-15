using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unity.VisualScripting;
using UnityEngine;

public static class NumberConverter
{
    public static Dictionary<long, string> numbers = new Dictionary<long, string>();
    

    public static void SetUp()
    {
        numbers.Add(1000, "K");
        numbers.Add(1000000, "M");
        numbers.Add(1000000000, "B");
        numbers.Add(1000000000000, "C");
        numbers.Add(1000000000000000, "Q");
        numbers.Add(1000000000000000000, "R");
    }
    
    
    public static string Convert(long number)
    {
        string result = string.Empty;
        switch (number)
        {
            case > 1000000000000000000:
                result = AddCommaToString((number / 1000000000000000).ToString(), 1) + ' ' + numbers[1000000000000000000];
                break;
            case > 1000000000000000:
                result = AddCommaToString((number / 1000000000000).ToString(), 1) + ' ' + numbers[1000000000000000];
                break;
            case > 1000000000000:
                result = AddCommaToString((number / 1000000000).ToString(), 1) + ' ' + numbers[1000000000000];
                break;
            case > 1000000000:
                result = AddCommaToString((number / 1000000).ToString(), 1) + ' ' + numbers[1000000000];
                break;
            case > 1000000:
                result = AddCommaToString((number / 1000).ToString(), 1) + ' ' + numbers[1000000];
                break;
            case > 1000:
                result = AddCommaToString((number / 1 ).ToString(), 1) + ' ' + numbers[1000];
                break;
            default:
                result = System.Convert.ToString(number);
                break;
        }
        
        return result;
    }

    public static string AddCommaToString(string target, int index)
    {
        StringBuilder sb = new StringBuilder();

        sb.Append(target.Substring(0,target.Length - (target.Length - index)));
        sb.Append(',');
        sb.Append(target.Substring(target.Length - (target.Length - index),target.Length - (target.Length - (target.Length - index)) - 1));
        
        return sb.ToString();
    }
}
