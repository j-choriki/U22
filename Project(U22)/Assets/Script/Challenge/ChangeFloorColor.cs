using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeFloorColor : MonoBehaviour
{
    //�݂��N������������̐F��ς���
    private void OnCollisionEnter(Collision collision)
    {
        GetComponent<Renderer>().material.color = new Color32(226, 114, 29, 255);
     
    }
}
