using UnityEngine;
using UnityEngine.UI;
using System.Runtime.InteropServices;

public class RetryChallangeStage : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void ChallangeStage();



    // ボタンが押された場合、今回呼び出される関数
    public void OnClick()
    {
        ChallangeStage();
    }
}
