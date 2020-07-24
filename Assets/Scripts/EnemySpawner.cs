using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public uint maxEnemies = 5;
    private Vector2 screenBounds;

    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if(enemies.Length < maxEnemies)
        {
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        Vector3 enemyPos = new Vector3(0, 0, 0);

        /* spawnSide
         * 1 - right
         * 2 - down
         * 3 - left
         * 4 - up
         */
        int spawnSide = Random.Range(1, 5); // range is 1 to 4 since 5 is exclusive

        switch (spawnSide)
        {
            // right
            case 1:
                enemyPos = new Vector3(
                    Random.Range(screenBounds.x + 1, screenBounds.x + 2),
                    Random.Range(-screenBounds.y, screenBounds.y),
                    0);
                break;
            // down
            case 2:
                enemyPos = new Vector3(
                    Random.Range(-screenBounds.x, screenBounds.x),
                    Random.Range(-screenBounds.y - 2, -screenBounds.y - 1),
                    0);
                break;
            // left
            case 3:
                enemyPos = new Vector3(
                    Random.Range(-screenBounds.x - 2, -screenBounds.x - 1),
                    Random.Range(-screenBounds.y, screenBounds.y),
                    0);
                break;
            // up
            case 4:
                enemyPos = new Vector3(
                    Random.Range(-screenBounds.x, screenBounds.x),
                    Random.Range(screenBounds.y + 1, screenBounds.y + 2),
                    0);
                break;
        }

        Instantiate(enemy, enemyPos, Quaternion.identity);
    }
}
