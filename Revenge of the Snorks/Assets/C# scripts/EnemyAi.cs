using Pathfinding;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;


[RequireComponent( typeof (Rigidbody2D))]
[RequireComponent(typeof (Seeker))]
public class EnemyAi : MonoBehaviour
{
    public Transform target;

    public float updateRate = 2f;


    private Seeker seeker;
    private Rigidbody2D rb;

    //The calc path 
    public Path path;

    //The Ai's speed per second
    public float speed = 20f;
    public ForceMode2D fMode;

    [HideInInspector]
    public bool pathIsEnded = false;

    //Max distace from the AI to the wavepoint
    public float nextWavePointDist = 3f;
    private int currentWayPoint = 0;

    private bool checkForPlayer = false;


    private void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        if (target == null)
        {
            if (!checkForPlayer)
            {
                checkForPlayer = true;
                StartCoroutine(searchForPlayer());
            }
            return;
        }

        seeker.StartPath(transform.position, target.position, OnPathComplete);

        StartCoroutine(UpdatePath());
    
            
    }

    IEnumerator searchForPlayer()
    {
        GameObject sResult = GameObject.FindGameObjectWithTag("Player");
        if(sResult == null)
        {
            yield return new WaitForSeconds(0.5f);
            StartCoroutine (searchForPlayer());
        }else
        {
            checkForPlayer = false;
            StartCoroutine (UpdatePath());
            yield return false;
        }

    }

    IEnumerator UpdatePath()
    {
        if(target == null)
        {
            if (!checkForPlayer)
            {
                checkForPlayer = true;
                StartCoroutine(searchForPlayer());
            }
            yield return false;
        }
        seeker.StartPath(transform.position, target.position, OnPathComplete);

        yield return new WaitForSeconds(1f / updateRate);

    }
    
    public void OnPathComplete(Path p)
    {
        Debug.Log("We got a path" + p.error);
        if (!p.error)
        {
            path = p;
            currentWayPoint = 0;
        }

    }

    private void FixedUpdate()
    {
        if(target == null)
        {
            if (!checkForPlayer)
            {
                checkForPlayer = true;
                StartCoroutine(searchForPlayer());
            }
           
            return;
        }
        if(path == null)
        {
            return;
        }
        if(currentWayPoint >= path.vectorPath.Count)
        {
            if (pathIsEnded)
            {
                return;
            }
            Debug.Log("End of path reached");
            pathIsEnded = true;
            return;
        }

        pathIsEnded = false;

        Vector3 dir = (path.vectorPath[currentWayPoint] - transform.position).normalized;
        dir *= speed * Time.deltaTime;

        //move the AI
        rb.AddForce(dir, fMode);
        float dist = Vector3.Distance(transform.position, path.vectorPath[currentWayPoint]);
        if (dist < nextWavePointDist)
        {
            currentWayPoint++;
            return;
        }

    }



}
