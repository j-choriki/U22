using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    //�A�C�e������ʂ������
    private void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);
    }
}
