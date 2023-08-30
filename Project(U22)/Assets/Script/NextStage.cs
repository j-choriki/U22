using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using UnityEngine.UI;

public class NextStage : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void NextStageButton();

    // ボタンが押された場合、今回呼び出される関数
    public void OnClick()
    {
        NextStageButton();
    }
}
