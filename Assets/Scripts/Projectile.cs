using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Vector2 screenBounds;
    public Rigidbody2D rb;
    public float impactForce = 0.1f;
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        rb.velocity = transform.up * Weapon.projectileSpeed;
    }
    private void LateUpdate()
    {
        if ((transform.position.x >= screenBounds.x) || (transform.position.y >= screenBounds.y) || (transform.position.x <= -screenBounds.x) || (transform.position.y <= -screenBounds.y))
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    { 
        if(collision.gameObject.CompareTag("Asteroid"))
        {
            Weapon.scrapsNum += (Saving.savedASLv - 1) * (Weapon.multiplier + ((Time.time - Saving.startTime) * 0.01)) * 20;
            Saving.SaveState();
            Saving.LoadState();
            Saving.LoadScrapsText();
            collision.attachedRigidbody.AddForce(rb.velocity * impactForce);
            Destroy(gameObject);
        }

        if(collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
