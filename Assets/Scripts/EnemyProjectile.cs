using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    private Vector2 screenBounds;
    private Vector3 direction;
    public float projectileSpeed = 5f;
    public Rigidbody2D rb;
    public float projectileDamage = 1f;
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }
    private void LateUpdate()
    {
        if ((transform.position.x >= screenBounds.x) || (transform.position.y >= screenBounds.y) || (transform.position.x <= -screenBounds.x) || (transform.position.y <= -screenBounds.y))
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")) {
            FindObjectOfType<AudioManager>().Play("Explosion");
            Destroy(gameObject);
            Health.health -= projectileDamage;
        }

        if(other.gameObject.CompareTag("Asteroid"))
        {
            Destroy(gameObject);
        }
    }
}
