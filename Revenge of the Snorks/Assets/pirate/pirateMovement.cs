using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pirateMovement : MonoBehaviour
{
    public GameObject gob;
    private bool isWalking;
    private float waitTime = 3;
    private float waitCounter;

    public float x_speed;
    public float y_speed;
    private Vector3 v;
    private void Start()
        {
        
             v = new Vector3(x_speed, y_speed, 0);
            isWalking = true;
        }
    private void Update()
    {
        if (isWalking)
        {

            gob.transform.position += v * Time.deltaTime;
            if (gob.transform.position.x > 6f || gob.transform.position.x < 4)
            {
                isWalking = false;
                waitCounter = waitTime;
                Flip();

            }
        }
    }
    private void Flip()
    {
        transform.localScale = new Vector3((transform.localScale.x * -1), transform.localScale.y * -1, 0);
        isWalking = true;
    }
}
