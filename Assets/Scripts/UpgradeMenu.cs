using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UpgradeMenu : MonoBehaviour
{
    public GameObject upgradeMenuUI;
    public static bool isUpgrading;
    private float time = 0f;
    void Update()
    {
        if (Health.isDead)
        {
            time += Time.deltaTime;
            if(time > 1.0f)
            {
                isUpgrading = true;
                upgradeMenuUI.SetActive(true);
                if (!Saving.saved)
                {
                    Saving.SaveState();
                    Saving.LoadState();
                    Saving.SaveTitanium();
                    Saving.LoadUpgradesText();
                    Saving.LoadScrapsText();
                    Saving.LoadTitaniumText();
                }
                Time.timeScale = 0f;
            }
        }
    }

    public void Replay()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        isUpgrading = false;
        Health.isDead = false;
        Health.health = Health.maxHealth;
        Saving.SaveState();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Saving.LoadState();
        Saving.startTime = Time.time;
        Saving.saved = false;
        Time.timeScale = 1f;
        Saving.LoadScrapsText();
        Saving.LoadTitaniumText();
    }
    public void BuyPD()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        if (Weapon.scrapsNum >= UpgradesSystem.CalculateScrapsCost(Weapon.projectileDamage.ToString())){
            Weapon.scrapsNum -= UpgradesSystem.CalculateScrapsCost(Weapon.projectileDamage.ToString());
            Weapon.projectileDamage += 1f;  
        }
        Saving.SaveState();
        Saving.LoadState();
        Saving.LoadUpgradesText();
        Saving.LoadScrapsText();
    }
    public void BuyPS()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        if (Weapon.scrapsNum >= UpgradesSystem.CalculateScrapsCost(Weapon.projectileSpeed.ToString()))
        {
            Weapon.scrapsNum -= UpgradesSystem.CalculateScrapsCost(Weapon.projectileSpeed.ToString());
            Weapon.projectileSpeed += 1f;
        }
        Saving.SaveState();
        Saving.LoadState();
        Saving.LoadUpgradesText();
        Saving.LoadScrapsText();
    }
    public void BuyFR()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        if (Weapon.scrapsNum >= UpgradesSystem.CalculateScrapsCost(Weapon.fireRate.ToString()))
        {
            Weapon.scrapsNum -= UpgradesSystem.CalculateScrapsCost(Weapon.fireRate.ToString());
            Weapon.fireRate += 1f;
        }
        Saving.SaveState();
        Saving.LoadState();
        Saving.LoadUpgradesText();
        Saving.LoadScrapsText();
    }
    public void BuyAS()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        if (Saving.savedTitaniumHolder >= UpgradesSystem.CalculateTitaniumCost(Weapon.asteroidScrap.ToString()))
        {
            Saving.savedTitaniumHolder -= UpgradesSystem.CalculateTitaniumCost(Weapon.asteroidScrap.ToString());
            Weapon.asteroidScrap += 1f;
        }
        Saving.SaveState();
        Saving.LoadState();
        Saving.LoadUpgradesText();
        Saving.LoadTitaniumText();
        Saving.LoadScrapsText();
    }
    public void BuyMultiplier()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        if (Saving.savedTitaniumHolder >= UpgradesSystem.CalculateMultiplierCost(Weapon.multiplier.ToString()))
        {
            Saving.savedTitaniumHolder -= UpgradesSystem.CalculateMultiplierCost(Weapon.multiplier.ToString());
            Weapon.multiplier += 1f;
        }
        Saving.SaveState();
        Saving.LoadState();
        Saving.LoadUpgradesText();
        Saving.LoadTitaniumText();
        Saving.LoadScrapsText();
    }
    public void Ascend()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        Saving.Ascension();
    }
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        PauseMenu.inMainMenu = true;
        isUpgrading = true;
        Saving.SaveState();
        SceneManager.LoadScene("MainMenu");
        Saving.LoadState();
        Saving.savedOnce = true;
        Saving.saved = false;
    }
}
