using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 3;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D hit)
    {
        Mobs enemy = hit.GetComponent<Mobs>();
        if(enemy != null)
        {
            enemy.TakeDamage(damage);

        }
        Destroy(enemy);
    }
    // Update is called once per frame

}
