using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WaveSpawner : MonoBehaviour
{

    public enum SpawnState { SPAWNING, WAITING, COUNTING };
    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform enemy;
        public int count;
        public float rate; 
    }

    public Wave[] waves;
    private int nextWave = 0;

    public float timeBetweenWaves = 5f; //Time measurement in seconds
    public float waveCountDown;
    private SpawnState state = SpawnState.COUNTING;
    private float searchCountDown;
    public Transform[] spawnPoints;

    void Start()
    {
        waveCountDown = timeBetweenWaves;
        
    }
    private void Update()
    {
        if(state == SpawnState.WAITING)
        {
            //Check if enemies are still alive
            if (!EnemyIsAlive())
            {
                //Begin a new round
                Debug.Log("Wave Completed!");
            }
            else
            {
                return;
            }
        }

        if (waveCountDown <= 0)
        {
            if (state != SpawnState.SPAWNING)
            {
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
            else
            {
                waveCountDown -= Time.deltaTime;
            }
        }
    }

    bool EnemyIsAlive()
    {
        searchCountDown -= Time.deltaTime;
        if (searchCountDown <= 0f)
        {
            searchCountDown = 1f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;


            }
           
        }
        return true;
    }


    IEnumerator SpawnWave(Wave _wave)
    {
        Debug.Log("Spawning Wave" + _wave.name);
        state = SpawnState.SPAWNING;

        for(int i = 0; i < _wave.count; i++)
        {
            EnemySpawn(_wave.enemy);
            yield return new WaitForSeconds(1f/ _wave.rate);
        }

        state = SpawnState.WAITING;
        yield break;
    }

    void EnemySpawn(Transform _enemy)
    {
        Debug.Log("Spawning Enemy: " + _enemy.name);
        Transform _sp = spawnPoints[UnityEngine.Random.Range(0, spawnPoints.Length)];
        Instantiate(_enemy, _sp.position, _sp.rotation);
        /*Vector2 firePointPos = new Vector2(firePointPos.position.x, firePointPos.position.y);
        RaycastHit2D hit = Physics2D.Raycast (, )
        EnemyAi enemy = RaycastHit2D.collider.GetComponent<EnemyAi>();
        */

    }

}
