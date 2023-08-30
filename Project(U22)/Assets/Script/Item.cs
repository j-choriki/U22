using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    //ƒAƒCƒeƒ€‚ğ‰æ–Ê‚©‚çÁ‚·
    private void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);
    }
}
