using System.Collections;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{

    public int health = 100;

    //public GameObject death;

    public void TakeDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        //Instantiate(death, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
