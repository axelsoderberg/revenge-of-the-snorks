using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tile_rotation : MonoBehaviour
{
    void OnMouseDown() {
        if (!NetGameController.win)
            transform.Rotate(0.0f, 0.0f, 90.0f);
    }
}
