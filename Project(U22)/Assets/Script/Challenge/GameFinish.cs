using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFinish : MonoBehaviour
{
    //GmaeManagerの宣言
    private ChallengeGameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<ChallengeGameManager>();//GameManagerのインスタス生成
    }

    private void OnTriggerEnter()
    {
        gm.game = "fin";
        gm.moveCnt = 0;
        gm.aryCnt = 0;
    }
}
