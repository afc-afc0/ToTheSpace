using UnityEngine;

public class AsteroidPositionArrow : MonoBehaviour
{

    private GameObject asteroid;

    public Vector2 pos;

    private string asteroidTag = "Asteroid";

    void Start()
    {
        pos = gameObject.transform.position;
        asteroid = GameObject.FindGameObjectWithTag(asteroidTag);
    }

    void Update()
    {
        pos.y = asteroid.transform.position.y;
        transform.position = pos;
    }

}
