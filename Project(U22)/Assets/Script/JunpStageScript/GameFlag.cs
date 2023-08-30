using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlag : MonoBehaviour
{

    // GameManager���i�[���邽�߂̕ϐ�
    private JumpStageManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        // gameManager�̃I�u�W�F�N�g����
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
