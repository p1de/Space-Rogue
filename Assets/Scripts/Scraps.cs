using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scraps : MonoBehaviour
{
    public static Transform scraps;
    private void Start()
    {
        scraps = transform.Find("Value");
    }
    private void Awake()
    {
        scraps = transform.Find("Value");
        Saving.LoadScrapsText();
    }
    public static void SetScraps(double value)
    {
        if (value >= 100000)
            scraps.Find("ScrapsValue").GetComponent<Text>().text = value.ToString("0.0##e+00") + " S";
        else
            scraps.Find("ScrapsValue").GetComponent<Text>().text = value.ToString("0") + " S";
    }
}
