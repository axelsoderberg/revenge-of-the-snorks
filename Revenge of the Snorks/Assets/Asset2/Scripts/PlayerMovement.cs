using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private float moveH, moveV;
    [SerializeField] private float moveSpeed = 1.0f;



    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    private void FixedUpdate()
    {
        movingPlayer();
    }

    private void movingPlayer()
    {
        moveH = Input.GetAxis("Horizontal") * moveSpeed;
        moveV = Input.GetAxis("Vertical") * moveSpeed;
        rb.velocity = new Vector2(moveH, moveV);//OPTIONAL rb.MovePosition();

        Vector2 direction = new Vector2(moveH, moveV);

        FindObjectOfType<PlayerAnimation>().SetDirection(direction);

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (SceneManager.GetActiveScene().name == "ToTheCellar")
        {
            SceneManager.LoadScene("topDownShooter");
        }


    }
}
    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            
        }
        if (SceneManager.GetActiveScene().name == "ToTheCellar")
        {
            SceneManager.LoadScene("topdownShooter");
        }
    }

       /* if (SceneManager.GetActiveScene().name == "SampleScene")
        {
            if (collision.tag == "Finish" && minigame_complete)
            {
                transform.position = new Vector3(3.51200008f, -3.40400004f, -0.136920005f);
                SceneManager.LoadScene("upper_floor");
            }
            if (collision.tag == "Minigame" && !minigame_complete)
            {
                SceneManager.LoadScene("Net_puzzle");
                minigame_complete = true;
            }
            if (collision.tag == "Respawn")
            {
                transform.position = new Vector3(0.95f, 4.15f, 0);
            }

        }
       */


