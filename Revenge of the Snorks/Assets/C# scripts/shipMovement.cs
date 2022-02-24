using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipMovement : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody2D rb;
    public Camera cam;
    Vector2 movement;
    Vector2 mousePos;


    // Update is called once per frame
    void Update()
    {

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxis("Vertical");

       //mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
        Vector2 lookdir = mousePos - rb.position;
       // float angle = Mathf.Atan2(lookdir.y, lookdir.x) * Mathf.Rad2Deg - 90;
        //rb.rotation = angle;
    }
}
