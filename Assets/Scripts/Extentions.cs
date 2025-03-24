using System.Collections.Generic;
using UnityEngine;

public static class Extentions
{
    public static void ToConsole<T, D>(this Dictionary<T, D> dictionary)
    {
        foreach (KeyValuePair<T,D> keyValuePair in dictionary)
        {
            Debug.Log(keyValuePair.Key + " : " + keyValuePair.Value);
        }
    }
}