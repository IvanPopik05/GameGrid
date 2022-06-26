using TMPro;
using UnityEngine;

public static class UtilityExtensions
{
    public static void GetRandomWord(this TextMeshProUGUI text)
    {
        string words = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        int range = Random.Range(0, words.Length);
        text.text = words[range].ToString();
    }
    
}