using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchBox : MonoBehaviour
{
    //ChallangeMoveCharaのファイルの宣言
    private ChallangeMoveChara cmg;


    // Start is called before the first frame update
    void Start()
    {
        //ChallangeMoveCharaのオブジェクトを生成
        cmg = FindObjectOfType<ChallangeMoveChara>();
    }

   

    // 当たった時に呼ばれる関数
    private void OnCollisionEnter(Collision collision)
    {
        cmg.crimeFlag = false;
    }

}
