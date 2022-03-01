using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyUI.Dialogs;

public class Demo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DialogUI.Instance
            .SetTitle("Ohno! This level is filled with mobs, you have to kill them to continue!").Show();
        
    }

}
