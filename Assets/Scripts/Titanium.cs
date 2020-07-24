using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Titanium : MonoBehaviour
{
    public static Transform titanium;
    private void Start()
    {
        titanium = transform.Find("Value");
    }
    private void Awake()
    {
        titanium = transform.Find("Value");
        Saving.LoadTitaniumText();
    }
    public static void SetTitanium(double value)
    {
        if (value >= 100000)
            titanium.Find("TitaniumValue").GetComponent<Text>().text = value.ToString("0.0##e+00") + " T";
        else
            titanium.Find("TitaniumValue").GetComponent<Text>().text = value.ToString("0") + " T";
    }
}
