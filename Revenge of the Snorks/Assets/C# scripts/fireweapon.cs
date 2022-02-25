using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireweapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject flarePrefab;
    public float bulletForce = 10f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject flare = Instantiate(flarePrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = flare.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);

    }
}
