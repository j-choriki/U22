using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pushButton : MonoBehaviour
{
    //InputField���i�[���邽�߂̕ϐ�
    private InputField inputField;
    //GameManager���i�[���邽�߂̕ϐ�
    private JumpStageManager gameManager;

    // Start is called before the first frame update
    void Update()
    {
        //InputField�I�u�W�F�N�g�𒼐ڌ����ăR���|�[�l���g���擾
        GameObject inputFieldObj = GameObject.Find("InputField");
        inputField = inputFieldObj.GetComponent<InputField>();

        //gameManager�̃I�u�W�F�N�g����
        gameManager = FindObjectOfType<JumpStageManager>();
    }

    //�{�^���������ꂽ���̏���
    public void OnClick()
    {
        gameManager.jumpFlag = true;
    }
}
