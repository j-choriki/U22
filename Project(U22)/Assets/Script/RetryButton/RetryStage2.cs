using UnityEngine;
using UnityEngine.UI;
using System.Runtime.InteropServices;

public class RetryStage2 : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void Stage2();



    // �{�^���������ꂽ�ꍇ�A����Ăяo�����֐�
    public void OnClick()
    {
       Stage2();
    }
}
