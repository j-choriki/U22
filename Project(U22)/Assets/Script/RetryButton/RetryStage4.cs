using UnityEngine;
using UnityEngine.UI;
using System.Runtime.InteropServices;

public class RetryStage4 : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void Stage4();



    // �{�^���������ꂽ�ꍇ�A����Ăяo�����֐�
    public void OnClick()
    {
       Stage4();
    }
}
