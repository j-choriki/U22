using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//追加する！
using UnityEngine.UI;

public class addValue : MonoBehaviour
{
    [SerializeField] Text valTxt;

    //オブジェクトと結びつける
    public InputField inputField;

    void Start()
    {
        //Componentを扱えるようにする
        inputField = inputField.GetComponent<InputField>();
        // 開始時にテキストを "0" に設定
        valTxt.text = "0";

    }

    public void InputText()
    {
        int num;
        if (inputField.text == "")
        {
            num  = 0;
        }
        else
        {
            num = int.Parse(inputField.text);
        }

        if (num > 100)
        {
            //テキストにinputFieldの内容を反映
            valTxt.text = "0";
        }
        else
        {
            //テキストにinputFieldの内容を反映
            valTxt.text = inputField.text;
        }



    }

}