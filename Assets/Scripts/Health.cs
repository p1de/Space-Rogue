using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Range(0f, 15f)] public static float maxHealth = 1f;
    [Range(0f,15f)] public static float health = 1f;
    public static bool isDead = false;
    private void Update()
    {
        if (health <= 0f)
        {
            isDead = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            isDead = true;
        }

        if(collision.gameObject.CompareTag("Enemy"))
        {
            FindObjectOfType<AudioManager>().Play("Explosion");
            isDead = true;
        }
    }
}
