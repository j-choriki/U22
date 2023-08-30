using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeFloorColor : MonoBehaviour
{
    //‚Â‚İ‚«ŒN‚ª•à‚¢‚½‘«ê‚ÌF‚ğ•Ï‚¦‚é
    private void OnCollisionEnter(Collision collision)
    {
        GetComponent<Renderer>().material.color = new Color32(226, 114, 29, 255);
     
    }
}
