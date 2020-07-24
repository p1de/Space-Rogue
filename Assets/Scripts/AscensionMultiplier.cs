using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AscensionMultiplier : MonoBehaviour
{
    private static Transform multiplier;
    private void Start()
    {
        multiplier = transform.Find("Value");
    }
    private void Awake()
    {
        multiplier = transform.Find("Value");
        Saving.LoadMultiplierText();
    }
    private void FixedUpdate()
    {
        Saving.LoadMultiplierText();
    }
    public static void SetMultiplier(double value)
    {
        multiplier.Find("AscensionMultiplierValue").GetComponent<Text>().text = "X" + value.ToString("0.0");
    }
}
