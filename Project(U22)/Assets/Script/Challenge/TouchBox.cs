using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchBox : MonoBehaviour
{
    //ChallangeMoveChara�̃t�@�C���̐錾
    private ChallangeMoveChara cmg;


    // Start is called before the first frame update
    void Start()
    {
        //ChallangeMoveChara�̃I�u�W�F�N�g�𐶐�
        cmg = FindObjectOfType<ChallangeMoveChara>();
    }

   

    // �����������ɌĂ΂��֐�
    private void OnCollisionEnter(Collision collision)
    {
        cmg.crimeFlag = false;
    }

}
