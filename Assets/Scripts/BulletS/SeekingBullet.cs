using UnityEngine;
using System.Collections;

public class SeekingBullet : TurretBulletBase
{
    [SerializeField]private float lifeTime = 3f;
    [SerializeField]private GameObject target;
    [SerializeField]private float rotateSpeed = 200f;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        target = SpaceShipBase.Instance.gameObject;
    }

    private IEnumerator Disable()
    {
        yield return new WaitForSeconds(lifeTime);
        gameObject.SetActive(false);
    }


    private void OnEnable()
    {
        StartCoroutine(Disable());
    }

    private void OnDisable()
    {
        StopCoroutine(Disable());
    }

    void FixedUpdate()
    {
        MoveBullet();
    }

    protected override void MoveBullet()
    {
        Vector2 direction = (Vector2)target.transform.position - rb.position;

        direction.Normalize();

        float rotateAmount = Vector3.Cross(direction,transform.up).z;

        rb.angularVelocity = -rotateAmount * rotateSpeed;

        rb.velocity = transform.up * speed;
    }
}
