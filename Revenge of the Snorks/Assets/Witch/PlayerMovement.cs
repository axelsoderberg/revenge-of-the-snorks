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
    }
    
    [SerializeField] public GameControllerScript GCScript;
    [SerializeField] public GameObject GameController;
    //public MinigameController minigameController;
    public List<string> gamesdone;

    public void saveProgress()
    {
        MinigameController.Instance.minigames_done = gamesdone;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (SceneManager.GetActiveScene().Equals("upper_floor"))
        // {
        // PlayerIsSwitchingScene();
        DontDestroyOnLoad(collision);
        DontDestroyOnLoad(rb);
        SceneManager.LoadScene("Memory_minigame", LoadSceneMode.Additive);
        //GameController = GameObject.FindWithTag("GameController");
        //GCScript = GameController.GetComponent<GameControllerScript>();
        
        if (MinigameController.Instance.minigames_done.Contains("Memory"))
        {
            print("Hej");
        }
        /*
        print(GCScript.getMinigameDone());
        //if (GCScript.getMinigameDone())
        //{

            Destroy(collision.gameObject);
            print("Hej");
            // PlayerIsComingBack();
            black_hole.SetActive(true);
        //}
            */
       // }
      
    }


    private void PlayerIsSwitchingScene()
    {
        PlayerPrefs.SetFloat("X", rb.transform.position.x);
        PlayerPrefs.SetFloat("Y", rb.transform.position.y);
       // PlayerPrefs.SetFloat("Z", rb.transform.position.z);
        // Player Switches Scene
    }
    private void PlayerIsComingBack()
    {
        rb.velocity = new Vector2(rb.transform.position.x, rb.transform.position.y);
        // Player comes back
        /*
        rb.transform.position.x = PlayerPrefs.GetFloat("X");
        rb.transform.position.y = PlayerPrefs.GetFloat("Y");
        rb.transform.position.z = PlayerPrefs.GetFloat("Z");
        */
    }



}
