using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool minigame_complete = false;
    private float moveH, moveV;
    [SerializeField] private float moveSpeed = 1.0f;
    [SerializeField] private GameObject black_hole;
    public List<string> gamesdone;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        black_hole.SetActive(false);
        gamesdone = MinigameController.Instance.minigames_done;
        DontDestroyOnLoad(this);
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        MinigameController.Instance.minigames_done = gamesdone;
        if (SceneManager.GetActiveScene().name == "upper_floor") {
            SceneManager.LoadScene("Memory_minigame");
        }

        if (SceneManager.GetActiveScene().name == "SampleScene") {
            if (collision.tag == "Finish" && minigame_complete) {
                transform.position = new Vector3(3.51200008f,-3.40400004f,-0.136920005f);
                SceneManager.LoadScene("upper_floor");
            } if (collision.tag == "Minigame" && !minigame_complete) {
                SceneManager.LoadScene("Net_puzzle");
                minigame_complete = true;
            } if (collision.tag == "Respawn") {
                transform.position = new Vector3(0.95f,4.15f,0);
            }
        }
    }

    private void memory_game_done()
    {
        if (MinigameController.Instance.minigames_done.Contains("Memory"))
        { 
            black_hole.SetActive(true);
            GameObject.FindGameObjectWithTag("Memory_trigger").SetActive(false);
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        UnityEngine.Debug.Log(collision);
        if (collision.gameObject.tag == "Collision+")
            rb.transform.position += new Vector3(0.3f,-0.15f,0) * Time.deltaTime;
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
