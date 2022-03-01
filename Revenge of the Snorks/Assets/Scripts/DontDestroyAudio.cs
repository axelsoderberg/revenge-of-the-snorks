using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyAudio : MonoBehaviour
{
    // Start is called before the first frame update
    private static DontDestroyAudio gob;
    void Start()
    {
        DontDestroyOnLoad(this);
        if (gob == null) {
            gob = this;
        } else {
            DestroyObject(gameObject);
        }
    }
}