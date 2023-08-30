using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowResultCanvas : MonoBehaviour
{
    private Canvas canvas;

    // GameManagerを格納するための変数
    private JumpStageManager gameManager;

    //ゲーム終了時に表示する画像のオブジェクト
    public GameObject RetryImg;
    public GameObject SuccessImg;

    // Start is called before the first frame update
    void Start()
    {
        // Canvasを取得
        canvas = GetComponent<Canvas>();
        // gameManagerのオブジェクトを代入
        gameManager = FindObjectOfType<JumpStageManager>();

        //ゲーム終了時に表示する画像の非活性化
        if (RetryImg != null)
        {
            RetryImg.SetActive(false);
        }
        if (SuccessImg != null)
        {
            SuccessImg.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.game == "fin")
        {
            float delay = 1.5f ; // 遅延時間（秒）
            Invoke("CanvasShow", delay);
        }
        else if (gameManager.jumpFlag && gameManager.sendNum < 20)
        {
            float delay = 6.0f; // 遅延時間（秒）
            Invoke("CanvasShow", delay);
        }


    }

    private void CanvasShow()
    {
        canvas.enabled = true;     

        if (gameManager.juge == "success")
        {
            SuccessImg.SetActive(true);
        }
        else if (gameManager.juge == "fail")
        {
            RetryImg.SetActive(true);
        }

    }
}
    