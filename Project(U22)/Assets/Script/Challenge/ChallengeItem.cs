using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChallengeItem : MonoBehaviour
{
    //GmaeManagerの宣言
    private ChallengeGameManager gm;

    void Start()
    {
        gm = FindObjectOfType<ChallengeGameManager>();
    }
    //星の取得をプラスしていく
    private void OnTriggerEnter(Collider other)
    {
        gm.getItemCnt = gm.getItemCnt + 1;
    }
}
