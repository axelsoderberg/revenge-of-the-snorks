using System.Collections;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    
    [System.Serializable]
    public class Stats
    {
        public int Health = 100;
    }

    public Stats stats = new Stats();
    
     public void DamageTaken(int damage)
    {
        stats.Health -= damage;
        if(stats.Health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
