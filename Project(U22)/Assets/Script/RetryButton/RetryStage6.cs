using UnityEngine;
using UnityEngine.UI;
using System.Runtime.InteropServices;

public class RetryStage6 : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void Stage6();



    // �{�^���������ꂽ�ꍇ�A����Ăяo�����֐�
    public void OnClick()
    {
       Stage6();
    }
}
