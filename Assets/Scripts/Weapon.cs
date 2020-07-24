using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject projectilePrefab;
    public static double scrapsNum = 0d;
    public static double titaniumNum = 0d;
    public static float asteroidScrap = 1f, multiplier = 1f;
    [Range(5f, 60f)] public static float fireRate = 1f;
    [Range(1f, 50f)] public static float projectileDamage = 1f;
    [Range(5f, 50f)] public static float projectileSpeed = 5f;
    private float nextTimeToFire = 0f;
    void FixedUpdate()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire && !PauseMenu.isPaused && !UpgradeMenu.isUpgrading && !Health.isDead)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }
    void Shoot()
    {
        Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
    }
}
