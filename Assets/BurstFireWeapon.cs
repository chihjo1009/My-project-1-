using System.Collections;
using UnityEngine;

public class BurstFireWeapon : WeaponBase
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public int burstCount = 1;
    public float shotDelay = 0.1f;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(FireBurst());
        }
    }

    private IEnumerator FireBurst()
    {
        for (int i = 0; i < burstCount; i++)
        {
            Fire();
            yield return new WaitForSeconds(shotDelay);
        }
    }

    public override void Fire()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.GetComponent<Rigidbody>().velocity = firePoint.forward * 20f;
    }
}
