using UnityEngine;
using UnityEngine.UI;
using System.Runtime.InteropServices;

public class RetryStage3 : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void Stage3();



    // �{�^���������ꂽ�ꍇ�A����Ăяo�����֐�
    public void OnClick()
    {
       Stage3();
    }
}
