using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour
{
    public static GM gameMaster;

    private void Start()
    {
        if(gameMaster == null)
        {
            gameMaster = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GM>();
        }
    }

    public Transform enemyPrefab;
    public Transform spawnPrefab;
    public Transform spawnPoint;
    public float spawnDelay = 2;
    

    public void RespawnEnemy(){
        Instantiate(spawnPrefab, spawnPoint.position, spawnPoint.rotation);
    }

   

    public IEnumerator spawn()
    {
        yield return new WaitForSeconds (spawnDelay);

        Instantiate(spawnPrefab, spawnPoint.position, spawnPoint.rotation);
    }

    public static void KillEnemy (EnemyAi enemy)
    {
        Destroy(enemy.gameObject);
    }

}
