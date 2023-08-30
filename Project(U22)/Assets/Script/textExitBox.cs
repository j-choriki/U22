using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textExitBox : MonoBehaviour
{
    private ChallangeMoveChara cmg;
    // Start is called before the first frame update
    void Start()
    {
        cmg = FindObjectOfType<ChallangeMoveChara>();//ChallangeMoveCharaのオブジェクトを生成
    }

    // 当たった時に呼ばれる関数
    void OnColiisionExit(Collision collision)
    {
        cmg.crimeFlag = false;
    }

}
