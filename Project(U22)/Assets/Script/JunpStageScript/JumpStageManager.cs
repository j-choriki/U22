using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class JumpStageManager : MonoBehaviour
{
    [SerializeField] Text valTxt;   //変わるジャンプパラメーターの数字
    public int sendNum;             //Int型に変換したい値を代入
    private string textNum;         //入力値をstring型で保持
    public bool jumpFlag;           //ジャンプ処理開始を判断する
    public bool jumpStart;          //ジャンプ動作用
    public string game;             //ゲームの状態を格納(play,fin)
    public string juge;             //値によってリザルトで表示する画像を変える

    // Start is called before the first frame update
    void Start()
    {
        //変数の初期化
       sendNum = 0;
       valTxt.text = "0";
       jumpFlag = false;
       jumpStart = false;
       game = "play";
       juge = "fail";
    }

    // Update is called once per frame
    void Update()
    {
        //ジャンプボタンがおされたら
        if (jumpFlag)
        {
            //入力値を変数に代入
            textNum = valTxt.text;

            //入力にボックスに値が入力された時の処理
            if (textNum != "")
            {
                sendNum = int.Parse(textNum); //入力値をIntにして渡す
            }
            else //入力ボックスに値が入っていないときの処理
            {
                sendNum = 0;
                valTxt.text = "0"; //コード表示部分に0を表示
            }
        }
    }
}
