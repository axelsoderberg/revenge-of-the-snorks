
using UnityEngine;

public class ConveyorBelts : MonoBehaviour
{

    public GameObject gob;
    public GameObject parent;
    public GameObject Conveyors;
    void Start()
    {

    }

    void Update()
    {
        //Move the Rigidbody forwards constantly at speed you define (the blue+ arrow axis in Scene view)
        transform.Translate(new Vector3(-1,0.5f,0) * Time.deltaTime);
        if (gob.transform.position.x < -3) {
            UnityEngine.Debug.Log("AAA");
            Destroy(gob);
            gob = Instantiate(Conveyors, transform.position, transform.rotation);
            gob.transform.parent = parent.transform;
            gob.transform.position = new Vector3(0,0,0);
        }
    }
}
