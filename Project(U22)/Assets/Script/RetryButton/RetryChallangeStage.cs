using UnityEngine;
using UnityEngine.UI;
using System.Runtime.InteropServices;

public class RetryChallangeStage : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void ChallangeStage();



    // �{�^���������ꂽ�ꍇ�A����Ăяo�����֐�
    public void OnClick()
    {
        ChallangeStage();
    }
}
