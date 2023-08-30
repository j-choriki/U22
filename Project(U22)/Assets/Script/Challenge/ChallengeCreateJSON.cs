using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;//JSONファイル保存用に必要

public class ChallengeCreateJSON : MonoBehaviour
{
    //GmaeManagerの宣言
    private ChallengeGameManager gm;

    //JSONへの書き込みを操作する変数
    private bool writeFlag;

    //ゲームクリア時にJSONを生成するための変数群
    private string datapath;//JSONファイル保存場所を格納する変数
    private string folderPath = Application.streamingAssetsPath + "/UserInf";//ファイル名取得用のフォルダパス
    //生成JSONの中身のデータ
    [System.Serializable]
    public class CreateJson
    {
        public string clearLabel;//「hanamaru」か「maru」が入る
    }

    // Start is called before the first frame update
    void Start()
    {
        //ファイル名の取得
        string[] fs = System.IO.Directory.GetFiles(@folderPath, "*", System.IO.SearchOption.TopDirectoryOnly);
        string path = fs[0];
        string fileName = System.IO.Path.GetFileNameWithoutExtension(path);
 
        //初めに保存先を計算する　Application.dataPathで今開いているUnityプロジェクトのAssetsフォルダ直下を指定して、後ろに保存名を書く
        datapath = Application.streamingAssetsPath + "/UserInf/" + fileName + ".json"; // 同じファイル名を指定すると中身は上書きされる
 

        //GameManagerのインスタス生成
        gm = FindObjectOfType<ChallengeGameManager>();

        //フラグの初期化
        writeFlag = true;
    }

    // Update is called once per frame
    void Update()
    {
        //ゲームクリア時に一度だけ書き込ませる
        if (writeFlag && gm.game == "clear")
        {
            //JSONデータの生成
            CreateJson createJSON = new CreateJson();
            createJSON.clearLabel = gm.gameJugeNum;         // ゲーム評価をcreatJSONのオブジェクト型変数に格納
            string json = JsonUtility.ToJson(createJSON);   //JSON形式にシリアライズ化
            StreamWriter writer = new StreamWriter(datapath, false);    //初めに指定したデータの保存先を開く
            writer.WriteLine(json); //JSONデータを書き込み
            writer.Flush();         //バッファをクリアする
            writer.Close();         //ファイルをクローズする

            //フラグの変更
            writeFlag = false;
        }

    }
}
