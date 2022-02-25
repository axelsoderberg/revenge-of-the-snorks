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


    private void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        if (target == null)
        {
            Debug.LogError("No player");
            return;
        }

        seeker.StartPath(transform.position, target.position, OnPathComplete);

        StartCoroutine(UpdatePath());
    
            
    }

    IEnumerator UpdatePath()
    {
        if(target == null)
        {
            //TODO: Insert playersearch
            yield break;
         
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



    }



}
