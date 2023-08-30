using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChallengeItem : MonoBehaviour
{
    //GmaeManager‚ÌéŒ¾
    private ChallengeGameManager gm;

    void Start()
    {
        gm = FindObjectOfType<ChallengeGameManager>();
    }
    //¯‚Ìæ“¾‚ğƒvƒ‰ƒX‚µ‚Ä‚¢‚­
    private void OnTriggerEnter(Collider other)
    {
        gm.getItemCnt = gm.getItemCnt + 1;
    }
}
