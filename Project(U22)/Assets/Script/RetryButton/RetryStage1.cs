using UnityEngine;
using UnityEngine.UI;
using System.Runtime.InteropServices;

public class RetryStage1 : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void Stage1();



    // �{�^���������ꂽ�ꍇ�A����Ăяo�����֐�
    public void OnClick()
    {
       Stage1();
    }
}
