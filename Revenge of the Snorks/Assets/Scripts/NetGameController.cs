using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NetGameController : MonoBehaviour
{

    public static bool win; 

    [SerializeField]
    private Transform[] pictures;

    // Start is called before the first frame update
    void Start()
    {
        win = false;
    }

    // Update is called once per frame
    void Update()
    {

        // This is awful I know, will fix this if I have the time
        if (pictures[0].rotation.eulerAngles.z == 90 &&
            pictures[1].rotation.eulerAngles.z == 0 &&
            pictures[2].rotation.eulerAngles.z == 180 &&
            pictures[5].rotation.eulerAngles.z == 270 &&
            pictures[6].rotation.eulerAngles.z == 270 &&
            pictures[7].rotation.eulerAngles.z == 90 &&
            pictures[8].rotation.eulerAngles.z == 0)
        {
            win = true;
            UnityEngine.Debug.Log("Net puzzle win");
            SceneManager.LoadScene (sceneName:"Ship_lower_deck");
        }
    }
}
