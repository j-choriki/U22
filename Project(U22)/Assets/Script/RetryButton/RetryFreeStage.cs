using UnityEngine;
using UnityEngine.UI;
using System.Runtime.InteropServices;

public class RetryFreeStage : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void FreeStage();



    // �{�^���������ꂽ�ꍇ�A����Ăяo�����֐�
    public void OnClick()
    {
       FreeStage();
    }
}
