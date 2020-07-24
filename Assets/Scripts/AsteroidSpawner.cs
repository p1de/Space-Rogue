using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public int maxNumberOfAsteroids = 10;
    public GameObject asteroid;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < maxNumberOfAsteroids; i++)
        {
            Instantiate(asteroid);
        }
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] asteroids = GameObject.FindGameObjectsWithTag("Asteroid");
        if(asteroids.Length < maxNumberOfAsteroids)
        {
            Instantiate(asteroid);
        }
    }
}
