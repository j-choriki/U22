using UnityEngine;
using UnityEngine.UI;
using System.Runtime.InteropServices;

public class RetryStage4 : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void Stage4();



    // ボタンが押された場合、今回呼び出される関数
    public void OnClick()
    {
       Stage4();
    }
}
