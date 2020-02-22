using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAsteroid : MonoBehaviour
{
    private GameObject asteroid;
    public Transform pos1;
    public Transform pos2;
    private string asteroidTag = "Asteroid";

    public bool isSpawning = true;

    void Start()
    {
        GetAstroidFromObjectPool();
        SpawningAsteroid();
    }

    void SpawningAsteroid()
    {
        StartCoroutine(AsteroidSpawn());
    }

    void GetAstroidFromObjectPool()
    {
        asteroid = GameObject.FindGameObjectWithTag(asteroidTag);   
    }

    IEnumerator AsteroidSpawn()
    {
        while(isSpawning)
        {
            asteroid.gameObject.transform.position = GetPosition();
            yield return new WaitForSeconds(5f);
        }
    }

    Vector2 GetPosition()
    {
        Vector2 position = new Vector2(pos1.position.x,Random.Range(pos1.position.y , pos2.position.y));
        return position;
    }

}
