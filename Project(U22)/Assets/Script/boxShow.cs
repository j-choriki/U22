using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxShow : MonoBehaviour
{
    private ChallengeGameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<ChallengeGameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter()
    {
        gm.boxShow = "hidden";
    }
}
