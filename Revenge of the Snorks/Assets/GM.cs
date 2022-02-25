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

    public Transform spawnPoint;
    public float spawnDelay = 2;
    public Transform spawnPrefab;


    public IEnumerator spawn()
    {
        yield break;
    }


}
