using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFinish : MonoBehaviour
{
    //GmaeManager�̐錾
    private ChallengeGameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<ChallengeGameManager>();//GameManager�̃C���X�^�X����
    }

    private void OnTriggerEnter()
    {
        gm.game = "fin";
        gm.moveCnt = 0;
        gm.aryCnt = 0;
    }
}
