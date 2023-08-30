using UnityEngine;
using UnityEngine.UI;
using System.Runtime.InteropServices;

public class RetryFreeStage : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void FreeStage();



    // ボタンが押された場合、今回呼び出される関数
    public void OnClick()
    {
       FreeStage();
    }
}
