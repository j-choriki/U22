using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChallengeItem : MonoBehaviour
{
    //GmaeManager�̐錾
    private ChallengeGameManager gm;

    void Start()
    {
        gm = FindObjectOfType<ChallengeGameManager>();
    }
    //���̎擾���v���X���Ă���
    private void OnTriggerEnter(Collider other)
    {
        gm.getItemCnt = gm.getItemCnt + 1;
    }
}
