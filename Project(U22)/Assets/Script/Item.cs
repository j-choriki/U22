using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    //アイテムを画面から消す
    private void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);
    }
}
