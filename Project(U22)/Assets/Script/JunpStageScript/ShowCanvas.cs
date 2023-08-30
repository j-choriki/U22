using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowCanvas : MonoBehaviour
{
    private Canvas canvas;

    // GameManagerを格納するための変数
    private JumpStageManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        // Canvasを取得
        canvas = GetComponent<Canvas>();

        // gameManagerのオブジェクトを代入
        gameManager = FindObjectOfType<JumpStageManager>();

        //3秒後に変数の値を変更する
        float delay = 4.0f; // 遅延時間（秒）
        Invoke("CanvasShow", delay);
    }

    // Update is called once per frame
    void Update()
    {
        //ゲーム終了すれば１秒後にパラメータパネルを閉じる
        if (gameManager.game == "fin")
        {
            float delay = 1.0f;
            Invoke("CanvasClose", delay);
        }
        else if (gameManager.jumpFlag && gameManager.game != "fin")//パラメ―ター20以下の時の処理
        {
            float delay = 6.0f;//ジャンプしてから６秒後にcanvasを閉じる
            Invoke("CanvasClose", delay);
        }
    }
    private void CanvasShow()
    {
        canvas.enabled = true;
    }

    private void CanvasClose()
    {
        canvas.enabled = false;
    }
}
