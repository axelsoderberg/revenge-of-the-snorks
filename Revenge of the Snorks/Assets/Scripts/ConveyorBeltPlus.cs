
using UnityEngine;

public class ConveyorBeltPlus : MonoBehaviour
{
    public GameObject gob;
    public GameObject parent;
    private Vector3 v = new Vector3(0.5f, -0.25f, 0);
    private bool createFlag = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gob.transform.position += v * Time.deltaTime;
        if (gob.transform.position.x >= 2) {
            if (gob.transform.position.x >= 7) {
                Destroy(gob);
            } else if (createFlag) {
                GameObject newGob = GameObject.Instantiate(gob, new Vector3(0,0,0), transform.rotation);
                newGob.transform.parent = parent.transform;
                newGob.transform.position = new Vector3(-3,1.5f,0);
                createFlag = false;
            }
        }
    }
}
