using UnityEngine;
using System.Collections;

public class TurretFirePoint : MonoBehaviour
{
    [SerializeField] protected float fireRate;
    [SerializeField] protected bool isFiring;
    [SerializeField] protected float startFireTimer;
    [SerializeField] protected string audioName;

    protected BulletPool bulletPool;
    protected GameObject bullet;

    private void Awake()
    {
        bulletPool = GetComponentInParent<BulletPool>();
    }

    private void Start()
    {
        StartCoroutine(Fire());
    }

    protected virtual IEnumerator Fire()
    {
        yield return new WaitForSeconds(startFireTimer);
        while (isFiring)
        {
            bullet = bulletPool.GetBullet();
            bullet.transform.position = transform.position;
            bullet.transform.rotation = transform.rotation;
            bullet.gameObject.SetActive(true);

            PlayAudio();

            yield return new WaitForSeconds(fireRate);
        }
    }

    protected void PlayAudio()
    {
        AudioManager.Instance.Play(audioName);
    }

}
