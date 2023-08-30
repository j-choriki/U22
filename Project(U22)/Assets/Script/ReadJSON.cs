using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//以下追記
using UnityEngine.Networking;// WWWを使うため
using System.IO;// Fileを使うため

public class ReadJSON : MonoBehaviour
{//=====変数宣言部===========================================================================

    //読み込むphpファイルまでのパス
    private string phpPath = "https://tsumikikun.sakura.ne.jp/letsgotsumiki/pupil/testdb_unity.php";

    //ファイルパスを格納
    private string filepath = Application.streamingAssetsPath;

    //キャラクターが動く回数をカウントする変数
    public int cnt = 0;

    //キャラクターが動くための配列の添え字代入する数字が格納される(cnt-1)
    public int ArrayControl;

    //JSONファイルが保存されているフォルダ名を格納する
    public string resultText;

    //JSONで読み込んだデータを配列で格納
    public string result;


    //積まれた積み木の個数を配列で格納
    public string numberResult;

    //クリアの最小個数格納する変数
    public int numberCnt;

    //積み木の指示がJSONから送られてくる配列
    [System.Serializable]
    public class InputJSON
    {
        public string[] process;
    }

    //積んだ積み木の個数がJSONから送られくる配列
    [System.Serializable]
    public class Number
    {
        public string[] process;
    }

    public int aryCnt;

    //=====処理部================================================================================
    public IEnumerator textLoad()
    {
        //オンライン用で使用するPHPに関する処理
        WWW wwwphp = new WWW(phpPath);
        yield return wwwphp;
        resultText = wwwphp.text;

        //指示を読み込むためのJSONが格納されているファイルパス
        string readJSONPath = filepath + "/" + resultText + ".json";//オンライン用
        
        if (readJSONPath.Contains("://") || readJSONPath.Contains(":///"))//　オンライン用
        {
            WWW www = new WWW(readJSONPath);
            yield return www;
            result = www.text;
            InputJSON inputJSON = JsonUtility.FromJson<InputJSON>(result);
            //JSONに記載されている指示の個数分変数をインクリメント
            foreach (string p in inputJSON.process)
            {
                cnt++;
            }
            aryCnt = cnt - 1;
        }
        else// オフライン用
        {
            result = File.ReadAllText(readJSONPath);// ファイルデータをすべて読み込み文字列型の配列で返す
            InputJSON inputJson = JsonUtility.FromJson<InputJSON>(result);
            foreach (string p in inputJson.process)
            {
                cnt++;
            }
            aryCnt = cnt - 1;
        }

        //積まれた積み木の数を格納しているJSONファイルの読み込み
        //積まれた積み木の数を格納しているJSONファイルまでのパス
        string numberFilepath = filepath + "/" + resultText + "number.json";
        if (numberFilepath.Contains("://") || numberFilepath.Contains(":///"))
        {
            WWW wwwNum = new WWW(numberFilepath);
            yield return wwwNum;
            numberResult = wwwNum.text;
            Number number = JsonUtility.FromJson<Number>(numberResult);
            foreach (string n in number.process)
            {
                numberCnt++;
            }
        }
        else
        {
            numberResult = File.ReadAllText(numberFilepath);// ファイルデータをすべて読み込み文字列型の配列で返す
            Number number = JsonUtility.FromJson<Number>(numberResult);
            foreach (string n in number.process)
            {
                numberCnt++;
            }
        }

    }

    void Awake()
    {
        StartCoroutine(textLoad());
    }

  }
