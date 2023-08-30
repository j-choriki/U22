using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pushButton : MonoBehaviour
{
    //InputFieldを格納するための変数
    private InputField inputField;
    //GameManagerを格納するための変数
    private JumpStageManager gameManager;

    // Start is called before the first frame update
    void Update()
    {
        //InputFieldオブジェクトを直接見つけてコンポーネントを取得
        GameObject inputFieldObj = GameObject.Find("InputField");
        inputField = inputFieldObj.GetComponent<InputField>();

        //gameManagerのオブジェクトを代入
        gameManager = FindObjectOfType<JumpStageManager>();
    }

    //ボタンが押された時の処理
    public void OnClick()
    {
        gameManager.jumpFlag = true;
    }
}
