using UnityEngine;
using TMPro;

public class CanonBullet : TurretBulletBase
{
    private float startTime;
    private float countDown;

    [SerializeField]private TextMeshProUGUI Timer;

    [Header("TIMER")]
    [SerializeField]private float randomTimeStart = 1.2f;
    [SerializeField]private float randomTimeFinish = 4.5f;


    void Start()
    {
        startTime = Random.Range(randomTimeStart, randomTimeFinish);
        countDown = startTime;
    }

    void OnEnable()
    {
        startTime = Random.Range(randomTimeStart, randomTimeFinish);
        countDown = startTime;
    }
    void Update()
    {
        MoveBullet();
        ExplotionTimer();
    }

    void Explode()
    {
        GameObject explosion = ObjectPooler.Instance.GetPoolObject("Explosion");
        explosion.transform.position = transform.position;
        explosion.transform.rotation = transform.rotation;
        explosion.SetActive(true);
        gameObject.SetActive(false);     
    }

    
    void ExplotionTimer()
    {
        countDown -= Time.deltaTime;

        if(countDown <= 0)
        {
            Explode();
        }
        Timer.text = ((int)countDown).ToString();
    }

}
