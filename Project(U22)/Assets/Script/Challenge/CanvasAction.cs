using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasAction : MonoBehaviour
{
    private ChallengeGameManager gm;
    private Canvas canvas;
    private string score;
    public Text textObject; // Textオブジェクトへの参照

    // Start is called before the first frame update
    void Start()
    {
        //GameManagerのインスタス生成
        gm = FindObjectOfType<ChallengeGameManager>();
        // Canvasを取得
        canvas = GetComponent<Canvas>();

    }

    // Update is called once per frame
    void Update()
    {
     
        //ゲームが終了すれば評価画面を表示する
        if (gm.game == "fin")
        { 
            score = gm.getItemCnt.ToString();
            ChangeText(score);
            canvas.enabled = true;
        }
    }

    
    public void ChangeText(string newText)
    {
        if (textObject != null)
        {
            textObject.text = newText; // テキストの変更
        }
    }




}
