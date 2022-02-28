
using UnityEngine;

public class ConveyorBeltMinus : MonoBehaviour
{
    public GameObject gob;
    public GameObject parent;
    private Vector3 v = new Vector3(-0.3f, 0.15f, 0);
    private bool createFlag = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gob.transform.position += v * Time.deltaTime;
        if (gob.transform.position.x <= -2 ) {
            if (gob.transform.position.x <= -4) {
                Destroy(gob);
            } else if (createFlag) {
                GameObject newGob = GameObject.Instantiate(gob, new Vector3(0,0,0), transform.rotation);
                newGob.transform.parent = parent.transform;
                newGob.transform.position = new Vector3(2,-1,0);
                createFlag = false;
            }
        }
    }
}
