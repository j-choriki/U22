using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hiidenObj : MonoBehaviour
{
    private ChallengeGameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<ChallengeGameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        gm.boxShow = "hidden";
    }

}
