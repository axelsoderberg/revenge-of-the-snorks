﻿using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool minigame_complete = false;
    private float moveH, moveV;
    [SerializeField] private float moveSpeed = 1.0f;
    //[SerializeField] private GameObject black_hole

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        /*if (SceneManager.GetActiveScene().name == "upper_floor") {
            GameObject.FindGameObjectWithTag("Black_hole").SetActive(false);
            gamesdone = MinigameController.Instance.minigames_done;
        }*/
        DontDestroyOnLoad(this);
    }
    private void FixedUpdate()
    {
        moveH = Input.GetAxis("Horizontal") * moveSpeed;
        moveV = Input.GetAxis("Vertical") * moveSpeed;
        rb.velocity = new Vector2(moveH, moveV);//OPTIONAL rb.MovePosition();

        Vector2 direction = new Vector2(moveH, moveV);

        FindObjectOfType<PlayerAnimation>().SetDirection(direction);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (SceneManager.GetActiveScene().name == "upper_floor") {
            if (collision.tag == "Memory_trigger")
            {
                //Destroy(collision);
                DontDestroyOnLoad(rb);
                SceneManager.LoadScene("Memory_minigame", LoadSceneMode.Additive);
                SceneManager.UnloadSceneAsync("Memory_minigame");
                GameObject.FindGameObjectWithTag("Black_hole").SetActive(true);
                minigame_complete = true;
            }
            else if (collision.tag == "Black_hole" && minigame_complete)
            {
                Destroy(collision);
                GameObject.FindGameObjectWithTag("Black_hole").SetActive(false);
                DontDestroyOnLoad(rb);
                SceneManager.LoadScene("Memory_minigame", LoadSceneMode.Additive);
                SceneManager.UnloadSceneAsync("Memory_minigame");
            }
        }


        if (SceneManager.GetActiveScene().name == "SampleScene") {
            if (collision.tag == "Finish" && minigame_complete) {
                transform.position = new Vector3(7.83300018f,-2.21000004f,0);
                SceneManager.LoadScene("upper_floor");
            } if (collision.tag == "Minigame" && !minigame_complete) {
                SceneManager.LoadScene("Net_puzzle");
                minigame_complete = true;
            } if (collision.tag == "Respawn") {
                transform.position = new Vector3(0.95f,4.15f,0);
            }
        }
    }

    /*private void memory_game_done()
    {
        if (MinigameController.Instance.minigames_done.Contains("Memory"))
        { 
            GameObject.FindGameObjectWithTag("Black_hole").SetActive(true);
            GameObject.FindGameObjectWithTag("Memory_trigger").SetActive(false);
        }
    }*/
    private void OnCollisionStay2D(Collision2D collision)
    {
        UnityEngine.Debug.Log(collision);
        if (collision.gameObject.tag == "Collision+")
            rb.transform.position += new Vector3(0.3f,-0.15f,0) * Time.deltaTime;
    }

}
