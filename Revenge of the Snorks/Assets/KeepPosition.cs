
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeepPosition : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public Vector3 pos;
    void Awake() {
        DontDestroyOnLoad(this);
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "SampleScene")
            pos = player.transform.position;
    }
}
