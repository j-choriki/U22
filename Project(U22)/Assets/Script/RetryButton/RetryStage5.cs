using UnityEngine;
using UnityEngine.UI;
using System.Runtime.InteropServices;

public class RetryStage5 : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void Stage5();



    // �{�^���������ꂽ�ꍇ�A����Ăяo�����֐�
    public void OnClick()
    {
       Stage5();
    }
}
