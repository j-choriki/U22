using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCanvasAction : MonoBehaviour
{
    private ChallengeGameManager gm;
    public Canvas gameCanvas;
    private string score;
    public Text textObject; // Textオブジェクトへの参照
   
    // Start is called before the first frame update
    void Start()
    {
        //GameManagerのインスタス生成
        gm = FindObjectOfType<ChallengeGameManager>();
        gameCanvas = GetComponent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        score = gm.getItemCnt.ToString();
        ChangeText(score);
        if (gm.game == "fin")
        {
            //右上スコアの非表示化
            gameCanvas.enabled = false;
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
