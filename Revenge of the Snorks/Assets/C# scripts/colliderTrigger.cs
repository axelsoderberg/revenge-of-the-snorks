using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colliderTrigger : MonoBehaviour
{
    private movingElevator elevator;

    private bool elevatorCalled = false;
    private bool canCallElevator = false;

    [SerializeField] private MeshRenderer callButton;

   /* private void Start()
    {
        elevator = gameObject.Find(elevator) 
    }
























    /*[SerializeField] private Vector3 velocity;
    private bool moving;
    public GameObject Player;


    private void FixedUpdate()
    {
        if (moving)
        {
            transform.position += (velocity * Time.deltaTime);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == Player)
        {
            moving = true;
            collision.collider.transform.SetParent(transform);
            //The parent of the platform is now the player
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject == Player)
        {
            moving = false;
            collision.collider.transform.SetParent(null);
        }
    }
    */
}
