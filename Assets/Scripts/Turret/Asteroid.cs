using UnityEngine;

public class Asteroid : MonoBehaviour
{

    public int crashDamage = 10;
    public float speed = 8f;

    private string SpaceShipTag = "SpaceShip";

    void Start()
    {
        gameObject.SetActive(true);
    }

    void Update()
    {
        MoveAsteroid();
    }

    void MoveAsteroid()
    {
        gameObject.transform.Translate(Vector2.right * speed * Time.deltaTime, UnityEngine.Space.World);
    }

    public int GetDamage()
    {
        return crashDamage;
    }

}
