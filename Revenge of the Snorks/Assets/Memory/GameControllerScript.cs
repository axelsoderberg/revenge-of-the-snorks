using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControllerScript : MonoBehaviour
{
    public const int columns = 4;
    public const int rows = 3;

    public const float Xspace = 3.5f;
    public const float Yspace = -3.5f;

    [SerializeField] private MainImageScript startObject;
    [SerializeField] private Sprite[] images;
    [SerializeField] private GameObject game_done_bg;
    [SerializeField] private TextMesh doneText;
    [SerializeField] private TextMesh failText;
    [SerializeField] private GameObject restart;


    private int[] Randomiser(int[] locations)
    {
        int[] array = locations.Clone() as int[];
        for(int i=0; i < array.Length; i++)
        {
            int newArray = array[i];
            int j = Random.Range(i, array.Length);
            array[i] = array[j];
            array[j] = newArray;
        }
        return array;
    }

    private void Start()
    {
        int[] locations = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5};
        locations = Randomiser(locations);
        game_done_bg.gameObject.SetActive(false);

        Vector3 startPosition = startObject.transform.position;

        for(int i = 0; i < columns; i++)
        {
            for(int j = 0; j < rows; j++)
            {
                MainImageScript gameImage;
                if(i == 0 && j == 0)
                {
                    gameImage = startObject;
                }
                else
                {
                    gameImage = Instantiate(startObject) as MainImageScript;
                }

                int index = j * columns + i;
                int id = locations[index];
                gameImage.ChangeSprite(id, images[id]);

                float positionX = (Xspace * i) + startPosition.x;
                float positionY = (Yspace * j) + startPosition.y;

                gameImage.transform.position = new Vector3(positionX, positionY, startPosition.z);
            }
        }
    }

    private void Update()
    {
        if (score == 6)
        {
            EnableDoneText();
        }
        if (attempts > 14)
        {
            EnableFailText();
        }
    }

    private MainImageScript firstOpen;
    private MainImageScript secondOpen;

    private int score = 0;
    private int attempts = 0;

    [SerializeField] private TextMesh scoreText;
    [SerializeField] private TextMesh attemptsText;

    public bool canOpen
    {
        get { return secondOpen == null; }
    }

    public void imageOpened(MainImageScript startObject)
    {
        if(firstOpen == null)
        {
            firstOpen = startObject;
        }
        else
        {
            secondOpen = startObject;
            StartCoroutine(CheckGuessed());
        }
    }

    private IEnumerator CheckGuessed()
    {
        if (firstOpen.spriteId == secondOpen.spriteId) // Compares the two objects
        {
            score++; // Add score
            scoreText.text = "Score: " + score;
        }
        else
        {
            yield return new WaitForSeconds(0.5f); // Start timer

            firstOpen.Close();
            secondOpen.Close();
        }

        attempts++;
        attemptsText.text = "Attempts: " + attempts;

        firstOpen = null;
        secondOpen = null;
    }

    public void EnableDoneText()
    {

        game_done_bg.SetActive(true);
        doneText.gameObject.SetActive(true);
        failText.gameObject.SetActive(false);
        restart.SetActive(false);

    }
    public void EnableFailText()
    {

        game_done_bg.SetActive(true);
        failText.gameObject.SetActive(true);
        doneText.gameObject.SetActive(false);
        restart.SetActive(true);
        startObject.GameDone();
    }
    public void Quit()
    {
        SceneManager.LoadScene("Upper_floor");
    }

    public void Restart()
    {
        SceneManager.LoadScene("Memory_minigame");
    }
}
