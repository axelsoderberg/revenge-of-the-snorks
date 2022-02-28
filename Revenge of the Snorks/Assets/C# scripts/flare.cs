using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flare : MonoBehaviour
{
    public GameObject thisFlare;
    public int damage = 20;
   

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject fire = Instantiate(thisFlare, transform.position, Quaternion.identity);
        Destroy(fire, 5f);
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D hit)
    {
       EnemyStats enemy =  hit.GetComponent<EnemyStats>();
        if(enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        Destroy(gameObject);
    }


}
