using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadUpperFloor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (MinigameController.Instance.minigames_done.Contains("Memory"))
        {
            GameObject.FindGameObjectWithTag("Memory_trigger").SetActive(false);
            GameObject.FindGameObjectWithTag("Black_hole").SetActive(true);
        }
        else
            GameObject.FindGameObjectWithTag("Black_hole").SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
