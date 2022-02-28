using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flare : MonoBehaviour
{
    public float speed = 10f;
    public int damage = 20;
    public Rigidbody2D rb;
    private void Start()
    {
        rb.velocity = transform.up * speed;

    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject fire = Instantiate(thisFlare, transform.position, Quaternion.identity);
        Destroy(fire, 10f);
        Destroy(gameObject);
    }*/
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
