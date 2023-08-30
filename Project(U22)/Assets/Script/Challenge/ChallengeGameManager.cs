using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System;
using Newtonsoft.Json.Linq;
using UnityEngine.UI;

public class ChallengeGameManager : MonoBehaviour
{
    //====�ϐ��錾��========================================================

    //�u���b�N�̌��Ǘ��̂��߂̔z��
    public ChallengeItem[] blocks;

    //�Q�[�����N���A�Ǘ�����ϐ�
    public string game;          //�Q�[���̏�Ԃ��i�[����ϐ�
    public string gameJuge;      //�Q�[���N���A���̕]�����i�[����
    public string gameJugeNum;   //�Q�[���]���p�̐������i�[�����ϐ�

    //�Q�[���I�����̃t���O�ϐ�
    public bool gameOverFlag;

    //�L�����N�^�[�����񐔂��i�[����ϐ�
    public int moveCnt;
    //�L�����N�^�[�̎w�����i�[���Ă���z�񑀍�p�̕ϐ�(�Y����)
    public int aryCnt;

    //�J�E���g�A�b�v�̂��߂̕ϐ�
    private float count = 0.0f;
    private float interval = 3.5f; // �J�E���g�A�b�v�̊Ԋu�i�b�j

    //JSON�󂯎��̂��߂̐錾
    private JArray processArray; // �N���X�̃����o�ϐ��Ƃ��Đ錾
    private bool startLoad;      //JSON�󂯎��^�C�~���O�����炷���߂̕ϐ�

    //�L�����N�^�[����̎w��������ϐ�
    public string charaAction;

    //�t�@�C���̓ǂݍ���
    private ReadJSON readJSON;      //ReadJSON�t�@�C���̓ǂݍ���
    private MoveChara moveChara;    //MoveChara�t�@�C���̓ǂݍ���

 
    //�A�C�e���̌����i�[����ϐ�
    private int itemCnt;

    //�A�C�e���̎擾�����i�[
    public int getItemCnt;

    //�X�e�[�W�ԍ����i�[�����ϐ�
    public string stageName;
    //�Q�[����URL�����镶����
    private string currentURL;

    //���������𐧌����邽�߂̃{�b�N�X�̊����𐧌䂷��ϐ�
    public string boxShow;

    public GameObject[] tagobjs;


    //=====������===========================================================

    void Start()
    {
        //�e�ϐ�������
        game = "play";
        GameObject obj = GameObject.Find("ReadJSON");   //ReadJSON�̖��O�̃I�u�W�F�N�g��T��
        readJSON = obj.GetComponent<ReadJSON>();        //�t���Ă���X�N���v�g���擾
        startLoad = true;
        charaAction = "stop";       //�L�����N�^�[�̎w�������������Ȃ�����stop���i�[
        gameJuge = "noJuge";        //�Q�[���N���A������̏�����
        gameJugeNum = "0";          //�Q�[���N���A������̐��l�̏�����
        gameOverFlag = false;       //�Q�[���I���̃t���O
        getItemCnt = 0;
        boxShow = "show";

        //stopAdvance�̃^�O�����Ă���I�u�W�F�g��z��Ŏ擾
        GameObject[] tagobjs = GameObject.FindGameObjectsWithTag("stopAdvance");

        //�y�[�WURL���擾
        currentURL = Application.absoluteURL;
        string[] arr = currentURL.Split('/');   //�X���b�V����URL�𕪊����Ĕz��ɒǉ�
        int lastIndex = arr.Length - 2;         // �Ōォ���Ԗڂ̗v�f�̃C���f�b�N�X���v�Z
        stageName = arr[lastIndex];             //�ϐ��ɃX�e�[�W�ԍ����i�[

    }

    // Update is called once per frame
    void Update()
    {
        charaAction = "stop";
        count += Time.deltaTime; // DeltaTime�����Z���Ď��Ԃ��J�E���g�A�b�v

        //�Q�[���J�n�P�b�ゾ���̏���(JSON�̓ǂݍ��݃^�C�~���O���z����x������)
        if (count >= interval && startLoad)
        {
            //JSON�̎w���̉񐔂̓ǂݍ���
            moveCnt = readJSON.cnt;
 
            //�L�����N�^�[�w���z��̓Y�����R���g���[���p�̕ϐ�
            aryCnt = readJSON.aryCnt;

            //JSON�̓ǂݍ���
            try
            {
                JObject jsonObject = JObject.Parse(readJSON.result);
                processArray = (JArray)jsonObject["process"];
            }
            catch (JsonReaderException e)
            {
                Debug.LogError("JSON�ǂݎ��G���[: " + e.Message);
            }
            startLoad = false;
        }

        //1�b���Ƃɏ���
        if (count >= interval)
        {
            if (moveCnt != 0)//�w���񐔂�0�łȂ���
            {
                //�L�����N�^�[�̓��������߂̎w����ϐ��Ɋi�[
                if (processArray[aryCnt].ToString() == "walk")      //1���i��
                {
                    charaAction = "walk";
                }
                else if (processArray[aryCnt].ToString() == "jump") //�W�����v
                {
                    charaAction = "jump";
                }
                else if (processArray[aryCnt].ToString() == "climb")//��q�����
                {
                    charaAction = "climb";
                }
                //���삪�I���Ίe�J�E���^�[�̐��l�����炷
                moveCnt--;
                aryCnt--;
            }
            else// �w���̉񐔂�0��̎�
            {
                game = "fin";

            }
            count = 0.0f; // �J�E���g�����Z�b�g
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


    //======���\�b�h========================================================

    //�A�C�e���S���擾���������f
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