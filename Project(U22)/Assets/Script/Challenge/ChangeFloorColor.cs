using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeFloorColor : MonoBehaviour
{
    //つみき君が歩いた足場の色を変える
    private void OnCollisionEnter(Collision collision)
    {
        GetComponent<Renderer>().material.color = new Color32(226, 114, 29, 255);
     
    }
}
