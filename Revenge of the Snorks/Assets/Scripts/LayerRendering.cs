using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerRendering : MonoBehaviour
{
    // Start is called before the first frame update
    private bool runOnlyOnce = false;
    private Renderer myRenderer;
    [SerializeField]
    private int sortingOrderBase = 5000; 
    [SerializeField]
    private int offset = 0;

    private void Awake() {
        myRenderer = gameObject.GetComponent<Renderer>();
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        myRenderer.sortingOrder = (int)(sortingOrderBase - transform.position.y - offset);
        if (runOnlyOnce) {
            Destroy(this);
        }
    }

}
