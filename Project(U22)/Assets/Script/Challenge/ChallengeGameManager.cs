using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System;
using Newtonsoft.Json.Linq;
using UnityEngine.UI;

public class ChallengeGameManager : MonoBehaviour
{
    //====変数宣言部========================================================

    //ブロックの個数管理のための配列
    public ChallengeItem[] blocks;

    //ゲームをクリア管理する変数
    public string game;          //ゲームの状態を格納する変数
    public string gameJuge;      //ゲームクリア時の評価を格納する
    public string gameJugeNum;   //ゲーム評価用の数字が格納される変数

    //ゲーム終了時のフラグ変数
    public bool gameOverFlag;

    //キャラクター動く回数を格納する変数
    public int moveCnt;
    //キャラクターの指示を格納している配列操作用の変数(添え字)
    public int aryCnt;

    //カウントアップのための変数
    private float count = 0.0f;
    private float interval = 3.5f; // カウントアップの間隔（秒）

    //JSON受け取りのための宣言
    private JArray processArray; // クラスのメンバ変数として宣言
    private bool startLoad;      //JSON受け取りタイミングをずらすための変数

    //キャラクター操作の指示が入る変数
    public string charaAction;

    //ファイルの読み込み
    private ReadJSON readJSON;      //ReadJSONファイルの読み込み
    private MoveChara moveChara;    //MoveCharaファイルの読み込み

 
    //アイテムの個数を格納する変数
    private int itemCnt;

    //アイテムの取得個数を格納
    public int getItemCnt;

    //ステージ番号が格納される変数
    public string stageName;
    //ゲームのURLが入る文字列
    private string currentURL;

    //歩く距離を制限するためのボックスの活性を制御する変数
    public string boxShow;

    public GameObject[] tagobjs;


    //=====処理部===========================================================

    void Start()
    {
        //各変数初期化
        game = "play";
        GameObject obj = GameObject.Find("ReadJSON");   //ReadJSONの名前のオブジェクトを探す
        readJSON = obj.GetComponent<ReadJSON>();        //付いているスクリプトを取得
        startLoad = true;
        charaAction = "stop";       //キャラクターの指示が正しく来ない時はstopを格納
        gameJuge = "noJuge";        //ゲームクリア時判定の初期化
        gameJugeNum = "0";          //ゲームクリア時判定の数値の初期化
        gameOverFlag = false;       //ゲーム終了のフラグ
        getItemCnt = 0;
        boxShow = "show";

        //stopAdvanceのタグがついているオブジェトを配列で取得
        GameObject[] tagobjs = GameObject.FindGameObjectsWithTag("stopAdvance");

        //ページURLを取得
        currentURL = Application.absoluteURL;
        string[] arr = currentURL.Split('/');   //スラッシュでURLを分割して配列に追加
        int lastIndex = arr.Length - 2;         // 最後から二番目の要素のインデックスを計算
        stageName = arr[lastIndex];             //変数にステージ番号を格納

    }

    // Update is called once per frame
    void Update()
    {
        charaAction = "stop";
        count += Time.deltaTime; // DeltaTimeを加算して時間をカウントアップ

        //ゲーム開始１秒後だけの処理(JSONの読み込みタイミングが想定より遅いため)
        if (count >= interval && startLoad)
        {
            //JSONの指示の回数の読み込み
            moveCnt = readJSON.cnt;
 
            //キャラクター指示配列の添え字コントロール用の変数
            aryCnt = readJSON.aryCnt;

            //JSONの読み込み
            try
            {
                JObject jsonObject = JObject.Parse(readJSON.result);
                processArray = (JArray)jsonObject["process"];
            }
            catch (JsonReaderException e)
            {
                Debug.LogError("JSON読み取りエラー: " + e.Message);
            }
            startLoad = false;
        }

        //1秒ごとに処理
        if (count >= interval)
        {
            if (moveCnt != 0)//指示回数が0でない時
            {
                //キャラクターの動かすための指示を変数に格納
                if (processArray[aryCnt].ToString() == "walk")      //1歩進む
                {
                    charaAction = "walk";
                }
                else if (processArray[aryCnt].ToString() == "jump") //ジャンプ
                {
                    charaAction = "jump";
                }
                else if (processArray[aryCnt].ToString() == "climb")//梯子を上る
                {
                    charaAction = "climb";
                }
                //動作が終われば各カウンターの数値を減らす
                moveCnt--;
                aryCnt--;
            }
            else// 指示の回数が0回の時
            {
                game = "fin";

            }
            count = 0.0f; // カウントをリセット
        }

        

        if (boxShow == "show")
        {
            foreach (GameObject obj in tagobjs)
            {
                obj.SetActive(true);
            }
        }
        else
        {
            foreach (GameObject obj in tagobjs)
            {
                obj.SetActive(false);
            }
        }
    }


    //======メソッド========================================================

    //アイテム全部取得したか判断
    public bool itemAllClear()
    {
        foreach (ChallengeItem b in blocks)
        {
            if (b != null)
            {
                return false;
            }
        }
        return true;
    }

}