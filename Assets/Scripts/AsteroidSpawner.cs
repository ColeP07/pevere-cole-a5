using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject asteroidPrefab;
    public int maxAsteroids = 10;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SpawnAsteroid();
    }

    int GetAsteroidCount()
    {
        return GameObject.FindGameObjectsWithTag("Asteroid").Length;
    }

    void SpawnAsteroid()
    {
        while (GetAsteroidCount() < maxAsteroids)
        {
            Instantiate(asteroidPrefab, RandomSpawnPos(),Quaternion.identity);
        } 
    }

    Vector2 RandomSpawnPos()
    {
        float spawnX = Random.Range(-9f, 9f);
        float spawnY = Random.Range(-5f, 5f);

        return new Vector2(spawnX, spawnY);
    }
}
