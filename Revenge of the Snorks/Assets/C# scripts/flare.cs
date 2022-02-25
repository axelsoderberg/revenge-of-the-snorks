using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flare : MonoBehaviour
{
    public GameObject thisFlare;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject fire = Instantiate(thisFlare, transform.position, Quaternion.identity);
        Destroy(fire, 5f);
        Destroy(gameObject);
    }

}
