using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFin : MonoBehaviour
{
    //GmaeManager�̐錾
    private GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameManager>();   //GameManager�̃C���X�^�X����
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter()
    {
        gm.gameOverFlag = true;
    }
}
