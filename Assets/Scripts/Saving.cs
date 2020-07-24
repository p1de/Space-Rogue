using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saving : MonoBehaviour
{
    public static double savedTitaniumHolder = 0d, scrapsThisGame;
    public static double savedTitanium, savedScraps;
    private static float savedPSLv, savedPDLv, savedFRLv, savedMaxHP;
    public static float ascensionCounter = 0f, savedASLv = 1f, startTime = 0f, savedMultiplier = 1f;
    public static bool saved = false, savedOnce = false, savedShot = false;
    private static bool upgradeUIState, pauseUIState, deathState;
    public void Awake()
    {
        if (!PauseMenu.inMainMenu) DontDestroyOnLoad(gameObject);
        else Destroy(gameObject);

    }
    public static void SaveState()
    {
        pauseUIState = PauseMenu.isPaused;
        upgradeUIState = UpgradeMenu.isUpgrading;
        deathState = Health.isDead;
        savedMaxHP = Health.maxHealth;
        savedScraps = Weapon.scrapsNum;
        savedPSLv = Weapon.projectileSpeed;
        savedPDLv = Weapon.projectileDamage;
        savedFRLv = Weapon.fireRate;
        savedASLv = Weapon.asteroidScrap;
        savedMultiplier = Weapon.multiplier;
    }
    public static void SaveTitanium()
    {
        savedTitanium = Math.Floor(savedScraps / 100d);
    }
    public static void LoadState()
    {
        PauseMenu.isPaused = pauseUIState;
        UpgradeMenu.isUpgrading = upgradeUIState;
        Health.isDead = deathState;
        Health.maxHealth = savedMaxHP;
        Weapon.scrapsNum = savedScraps;
        Weapon.projectileSpeed = savedPSLv;
        Weapon.projectileDamage = savedPDLv;
        Weapon.fireRate = savedFRLv;
        Weapon.asteroidScrap = savedASLv;
        Weapon.multiplier = savedMultiplier;
        saved = true;
    }
    public static void LoadTitanium()
    {
        //if (ascensionCounter >= 1f)
            Weapon.titaniumNum = savedTitaniumHolder;
        //else
            //Weapon.titaniumNum = savedTitanium;
    }
    public static void LoadUpgradesText()
    {
        UpgradesSystem.SetPD(savedPDLv);
        UpgradesSystem.SetPS(savedPSLv);
        UpgradesSystem.SetFR(savedFRLv);
        UpgradesSystem.SetAS(savedASLv);
        UpgradesSystem.SetMultiplier(savedMultiplier);
        UpgradesSystem.SetTitaniumObtained();
    }
    public static void LoadScrapsText()
    {
        Scraps.SetScraps(savedScraps);
    }
    public static void LoadTitaniumText()
    {
        Titanium.SetTitanium(savedTitaniumHolder);
    }
    public static void LoadMultiplierText()
    {
        AscensionMultiplier.SetMultiplier(Weapon.multiplier + Mathf.Floor(Time.time - startTime) * 0.05);
    }
    public static void RebootState()
    {
        deathState = false;
        pauseUIState = false;
        upgradeUIState = false;
        savedMaxHP = 1f;
        savedScraps = 0d;
        savedPDLv = 1f;
        savedPSLv = 5f;
        savedFRLv = 1f;
        savedASLv = 1f;
        savedMultiplier = 1f;
        ascensionCounter = 0f;
        savedTitaniumHolder = 0d;
        SaveTitanium();
        LoadState();
        LoadUpgradesText();
        LoadScrapsText();
        LoadTitaniumText();
    }
    public static void Ascension()
    {
        deathState = false;
        pauseUIState = false;
        upgradeUIState = true;
        savedMaxHP = 1f;
        savedTitaniumHolder += savedTitanium;
        savedScraps = 0d;
        savedPDLv = 1f;
        savedPSLv = 5f;
        savedFRLv = 1f;
        ascensionCounter++;
        SaveTitanium();
        LoadState();
        LoadTitanium();
        LoadUpgradesText();
        LoadScrapsText();
        LoadTitaniumText();
    }
}
