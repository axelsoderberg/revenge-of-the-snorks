using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireweapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject flarePrefab;


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
        Instantiate(flarePrefab, firePoint.position, firePoint.rotation);

    }
}
