using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlag : MonoBehaviour
{

    // GameManagerを格納するための変数
    private JumpStageManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        // gameManagerのオブジェクトを代入
        gameManager = FindObjectOfType<JumpStageManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        gameManager.game = "fin";
    }

    private void OnTriggerEnter(Collider other)
    {
        gameManager.game = "fin";
    }
}
