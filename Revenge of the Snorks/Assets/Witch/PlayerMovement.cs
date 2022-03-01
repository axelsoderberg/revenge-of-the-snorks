using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private float moveH, moveV;
    [SerializeField] private float moveSpeed = 1.0f;
    [SerializeField] private GameObject black_hole;
    public List<string> gamesdone;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        black_hole.SetActive(false);
        gamesdone = MinigameController.Instance.minigames_done;
    }

    private void FixedUpdate()
    {
        moveH = Input.GetAxis("Horizontal") * moveSpeed;
        moveV = Input.GetAxis("Vertical") * moveSpeed;
        rb.velocity = new Vector2(moveH, moveV);//OPTIONAL rb.MovePosition();

        Vector2 direction = new Vector2(moveH, moveV);

        FindObjectOfType<PlayerAnimation>().SetDirection(direction);

        if (MinigameController.Instance.minigames_done.Contains("Memory"))
        {
            black_hole.SetActive(true);
            //GameObject.FindGameObjectWithTag("Memory_trigger").SetActive(false);
            GameObject.FindGameObjectWithTag("Memory_trigger").SetActive(false);
        }
    }


    public void saveProgress()
    {
        MinigameController.Instance.minigames_done = gamesdone;
    }

    private void memory_game_done()
    {
        if (MinigameController.Instance.minigames_done.Contains("Memory"))
        { 
            black_hole.SetActive(true);
            GameObject.FindGameObjectWithTag("Memory_trigger").SetActive(false);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GameObject.FindGameObjectWithTag("Memory_trigger"))
        {
            //Destroy(collision);
            DontDestroyOnLoad(rb);
            SceneManager.LoadScene("Memory_minigame", LoadSceneMode.Additive);
            SceneManager.UnloadSceneAsync("Memory_minigame");
        }
        else if (GameObject.FindGameObjectWithTag("Black_hole"))
        {
            Destroy(collision);
            GameObject.FindGameObjectWithTag("Black_hole").SetActive(false);
            DontDestroyOnLoad(rb);
            SceneManager.LoadScene("Memory_minigame", LoadSceneMode.Additive);
            SceneManager.UnloadSceneAsync("Memory_minigame");
        }
    }
}
