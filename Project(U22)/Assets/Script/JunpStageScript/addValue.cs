using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//�ǉ�����I
using UnityEngine.UI;

public class addValue : MonoBehaviour
{
    [SerializeField] Text valTxt;

    //�I�u�W�F�N�g�ƌ��т���
    public InputField inputField;

    void Start()
    {
        //Component��������悤�ɂ���
        inputField = inputField.GetComponent<InputField>();
        // �J�n���Ƀe�L�X�g�� "0" �ɐݒ�
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
            //�e�L�X�g��inputField�̓��e�𔽉f
            valTxt.text = "0";
        }
        else
        {
            //�e�L�X�g��inputField�̓��e�𔽉f
            valTxt.text = inputField.text;
        }



    }

}