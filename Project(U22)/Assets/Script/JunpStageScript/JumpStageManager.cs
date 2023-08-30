using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class JumpStageManager : MonoBehaviour
{
    [SerializeField] Text valTxt;   //�ς��W�����v�p�����[�^�[�̐���
    public int sendNum;             //Int�^�ɕϊ��������l����
    private string textNum;         //���͒l��string�^�ŕێ�
    public bool jumpFlag;           //�W�����v�����J�n�𔻒f����
    public bool jumpStart;          //�W�����v����p
    public string game;             //�Q�[���̏�Ԃ��i�[(play,fin)
    public string juge;             //�l�ɂ���ă��U���g�ŕ\������摜��ς���

    // Start is called before the first frame update
    void Start()
    {
        //�ϐ��̏�����
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
        //�W�����v�{�^���������ꂽ��
        if (jumpFlag)
        {
            //���͒l��ϐ��ɑ��
            textNum = valTxt.text;

            //���͂Ƀ{�b�N�X�ɒl�����͂��ꂽ���̏���
            if (textNum != "")
            {
                sendNum = int.Parse(textNum); //���͒l��Int�ɂ��ēn��
            }
            else //���̓{�b�N�X�ɒl�������Ă��Ȃ��Ƃ��̏���
            {
                sendNum = 0;
                valTxt.text = "0"; //�R�[�h�\��������0��\��
            }
        }
    }
}
