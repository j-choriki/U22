using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textExitBox : MonoBehaviour
{
    private ChallangeMoveChara cmg;
    // Start is called before the first frame update
    void Start()
    {
        cmg = FindObjectOfType<ChallangeMoveChara>();//ChallangeMoveChara�̃I�u�W�F�N�g�𐶐�
    }

    // �����������ɌĂ΂��֐�
    void OnColiisionExit(Collision collision)
    {
        cmg.crimeFlag = false;
    }

}
