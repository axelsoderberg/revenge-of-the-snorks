using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
public class movingElevator : MonoBehaviour
{
    [SerializeField] public GameObject[] waypoints;
        public GameObject player;
    private int currentwaypointIndex = 0;

    private float speed = 0.1f;


    private void Update()
    {
        if (Vector2.Distance(waypoints[currentwaypointIndex].transform.position, transform.position) < .1f)
        {
            currentwaypointIndex++;
            if(currentwaypointIndex >= waypoints.Length)
            {
                currentwaypointIndex = 0;
            }
        }

        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentwaypointIndex].transform.position, Time.deltaTime * speed);
    }




    /*
    private void FixedUpdate()
    {

        if (isCalledToPanel == true)
        {
            if (PointB != null)
            {
                if (transform.position != PointB.position)
                    transform.position = Vector3.MoveTowards(transform.position, PointB.position, speed * Time.deltaTime);
            }

        }
        else
        {
            if (PointA != null)
            {
                if (transform.position != PointA.position)
                {
                    transform.position = Vector3.MoveTowards(transform.position, PointA.position, speed * Time.deltaTime);
                }
            }
        }
        /*var step = speed * Time.deltaTime;
        //This should move the elevator to the waypoints based on the bool
        //if called to panel move to pointB else move to pointA

        transform.position = Vector3.MoveTowards(transform.position, isCalledToPanel ? PointB.position : PointA.position, step);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == Player)
        {
            Player.transform.parent = transform;
            //The parent of the platform is now the player
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == Player)
        {
            Player.transform.parent = null;
            //The player is no longer parent
        }



        */
}

 