using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using UnityEngine.UI;

public class NextStage : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void NextStageButton();

    // �{�^���������ꂽ�ꍇ�A����Ăяo�����֐�
    public void OnClick()
    {
        NextStageButton();
    }
}
