using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFin : MonoBehaviour
{
    //GmaeManagerの宣言
    private GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameManager>();   //GameManagerのインスタス生成
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
