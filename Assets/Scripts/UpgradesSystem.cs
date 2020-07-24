using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class UpgradesSystem : MonoBehaviour
{
    private static Transform upgradeMenu;
    private void Start()
    {
        upgradeMenu = transform.Find("UpgradeButtons");
    }
    private void Awake()
    {
        upgradeMenu = transform.Find("UpgradeButtons");
        Saving.LoadUpgradesText();
    }
    public static void SetPD(float value)
    {
        upgradeMenu.Find("PDLv").GetComponent<Text>().text = value.ToString();
        SetPDCost(CalculateScrapsCost(value.ToString()));
    }
    public static void SetPS(float value)
    {
        upgradeMenu.Find("PSLv").GetComponent<Text>().text = value.ToString();
        SetPSCost(CalculateScrapsCost(value.ToString()));
    }
    public static void SetFR(float value)
    {
        upgradeMenu.Find("FRLv").GetComponent<Text>().text = value.ToString();
        SetFRCost(CalculateScrapsCost(value.ToString()));
    }
    public static void SetAS(float value)
    {
        upgradeMenu.Find("ASLv").GetComponent<Text>().text = value.ToString();
        SetASCost(CalculateTitaniumCost(value.ToString()));
    }
    public static void SetMultiplier(float value)
    {
        upgradeMenu.Find("MultiplierLv").GetComponent<Text>().text = value.ToString();
        SetMultiplierCost(CalculateMultiplierCost(value.ToString()));
    }
    private static void SetPDCost(double value)
    {
        if(value >= 100000)
            upgradeMenu.Find("PDCost").GetComponent<Text>().text = value.ToString("0.0##e+00")+" S";
        else
            upgradeMenu.Find("PDCost").GetComponent<Text>().text = value.ToString() + " S";
    }
    private static void SetPSCost(double value)
    {
        if (value >= 100000)
            upgradeMenu.Find("PSCost").GetComponent<Text>().text = value.ToString("0.0##e+00") + " S";
        else
            upgradeMenu.Find("PSCost").GetComponent<Text>().text = value.ToString() + " S";
    }
    private static void SetFRCost(double value)
    {
        if (value >= 100000)
            upgradeMenu.Find("FRCost").GetComponent<Text>().text = value.ToString("0.0##e+00") + " S";
        else
            upgradeMenu.Find("FRCost").GetComponent<Text>().text = value.ToString() + " S";
    }
    private static void SetASCost(double value)
    {
        if (value >= 100000)
            upgradeMenu.Find("ASCost").GetComponent<Text>().text = value.ToString("0.0##e+00") + " T";
        else
            upgradeMenu.Find("ASCost").GetComponent<Text>().text = value.ToString() + " T";
    }
    public static void SetMultiplierCost(double value)
    {
        if (value >= 100000)
            upgradeMenu.Find("MultiplierCost").GetComponent<Text>().text = value.ToString("0.0##e+00") + " T";
        else
            upgradeMenu.Find("MultiplierCost").GetComponent<Text>().text = value.ToString() + " T";
    }
    public static void SetTitaniumObtained()
    {
        Saving.SaveTitanium();
        if ((Saving.savedTitanium) >= 100000)
            upgradeMenu.Find("AscensionValue").GetComponent<Text>().text = Math.Floor((Saving.savedTitanium)).ToString("0.0##e+00") + " T";
        else
            upgradeMenu.Find("AscensionValue").GetComponent<Text>().text = Math.Floor((Saving.savedTitanium)).ToString() + " T";
    }
    public static double CalculateScrapsCost(String level)
    {
        double lv,cost;
        lv = double.Parse(level);
        cost = Math.Floor(30 * Math.Pow(2.5, lv));
        return cost;
    }
    public static double CalculateTitaniumCost(String level)
    {
        double lv, cost;
        lv = double.Parse(level);
        cost = Math.Floor(30 * Math.Pow(1.5, lv));
        return cost;
    }
    public static double CalculateMultiplierCost(String multiplier)
    {
        double mp, cost;
        mp = double.Parse(multiplier);
        cost = Math.Floor(100 * Math.Pow(1.5, mp));
        return cost;
    }
}
