using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float fireRate = 0.5f;
    public float movementSpeed = 0.05f;
    public GameObject enemyBullet;
    public GameObject enemyExplosion;
    public Animator animator;

    private float projectileSpeed = 5.0f;
    private float previousShotTime = 0f;
    private float timeToFire;

    private Vector3 direction;
    private Vector3 playerPos;
    private bool isDead = false; // quick fix so enemies can't shoot while exploding
    void Start()
    {
        timeToFire = 1.0f / fireRate;
    }

    void Update()
    {
        playerPos = GameObject.Find("Player").transform.position;

        // To point towards player
        direction = playerPos - transform.position;
        transform.up = -direction;

        if(previousShotTime > timeToFire && !isDead)
        {
            previousShotTime = 0f;
            // left cannon
            Shoot(new Vector3(0.5f, 0.0f, 0.0f));
            // right cannon
            Shoot(new Vector3(-0.5f, 0.0f, 0.0f));
        }

        previousShotTime += Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("PlayerProjectile"))
        {
            if(!isDead)
            {
                Weapon.scrapsNum += (75 + Weapon.projectileDamage * 25) * (Weapon.multiplier + ((Time.time - Saving.startTime) * 0.05));
                Saving.SaveState();
                Saving.LoadState();
                Saving.LoadScrapsText();
                Kill();
            }
        }
        if(collision.gameObject.CompareTag("Asteroid"))
        {
            Kill();
        }
    }
    private void FixedUpdate()
    {
        if(direction.sqrMagnitude < 150.0f)
        {
            // if player is less than 150 units away from enemy
            // rotate around player
            transform.RotateAround(playerPos, Vector3.forward, 10 * Time.fixedDeltaTime);
        } 
        else
        {
            // if player is more than 150 units away from enemy
            // go towards player
            direction.Normalize();
            transform.position += direction * movementSpeed;
        }
    }

    private void Shoot(Vector3 offset)
    {
        // instantiate bullet at enemy's position
        GameObject bullet = Instantiate(enemyBullet, transform.position, Quaternion.identity, transform);
        // offset the bullet position so that it look's as shot from left/right cannon
        bullet.transform.localPosition = offset;
        // set bullet's speed direction towards player (this way both bullets travel in parallel)
        bullet.GetComponent<Rigidbody2D>().velocity = direction.normalized * projectileSpeed;
        // detach the bullet from enemy so that enemy's transform doesn't affect the bullet's trajectory
        transform.DetachChildren();
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void Kill()
    {
        // making sure that bullets as well as player cannot collide with 
        // explosion
        Collider2D[] colliders = gameObject.GetComponents<Collider2D>();
        foreach(Collider2D col in colliders)
        {
            col.enabled = false;
        }
        FindObjectOfType<AudioManager>().Play("Explosion");
        isDead = true;
        animator.SetTrigger("Explosion");
        Destroy(gameObject, 1.0f);
    }
}
