using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireweapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject flarePrefab;
    public float bulletForce = 10f;
    public float fireRate = 0;
    public GameObject impact;
    public int damage = 20;

    public LayerMask whatTohit;
    // Update is called once per frame
    private void Awake()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }
    void Update()
    {
        if (fireRate == 0)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
            }
        }
    }

    void Shoot()
    {
        GameObject flare = Instantiate(flarePrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = flare.GetComponent<Rigidbody2D>();
        RaycastHit2D hit = Physics2D.Raycast(firePoint.position, firePoint.up * bulletForce);

        if (hit)
        {
           EnemyStats enemy = hit.transform.GetComponent<EnemyStats>();
            if(enemy != null)
            {
                enemy.TakeDamage(damage);
            }
            Instantiate(impact, hit.point, Quaternion.identity);
        }

    }
}
