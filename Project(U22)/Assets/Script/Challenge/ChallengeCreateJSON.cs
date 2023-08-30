using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;//JSON�t�@�C���ۑ��p�ɕK�v

public class ChallengeCreateJSON : MonoBehaviour
{
    //GmaeManager�̐錾
    private ChallengeGameManager gm;

    //JSON�ւ̏������݂𑀍삷��ϐ�
    private bool writeFlag;

    //�Q�[���N���A����JSON�𐶐����邽�߂̕ϐ��Q
    private string datapath;//JSON�t�@�C���ۑ��ꏊ���i�[����ϐ�
    private string folderPath = Application.streamingAssetsPath + "/UserInf";//�t�@�C�����擾�p�̃t�H���_�p�X
    //����JSON�̒��g�̃f�[�^
    [System.Serializable]
    public class CreateJson
    {
        public string clearLabel;//�uhanamaru�v���umaru�v������
    }

    // Start is called before the first frame update
    void Start()
    {
        //�t�@�C�����̎擾
        string[] fs = System.IO.Directory.GetFiles(@folderPath, "*", System.IO.SearchOption.TopDirectoryOnly);
        string path = fs[0];
        string fileName = System.IO.Path.GetFileNameWithoutExtension(path);
 
        //���߂ɕۑ�����v�Z����@Application.dataPath�ō��J���Ă���Unity�v���W�F�N�g��Assets�t�H���_�������w�肵�āA���ɕۑ���������
        datapath = Application.streamingAssetsPath + "/UserInf/" + fileName + ".json"; // �����t�@�C�������w�肷��ƒ��g�͏㏑�������
 

        //GameManager�̃C���X�^�X����
        gm = FindObjectOfType<ChallengeGameManager>();

        //�t���O�̏�����
        writeFlag = true;
    }

    // Update is called once per frame
    void Update()
    {
        //�Q�[���N���A���Ɉ�x�����������܂���
        if (writeFlag && gm.game == "clear")
        {
            //JSON�f�[�^�̐���
            CreateJson createJSON = new CreateJson();
            createJSON.clearLabel = gm.gameJugeNum;         // �Q�[���]����creatJSON�̃I�u�W�F�N�g�^�ϐ��Ɋi�[
            string json = JsonUtility.ToJson(createJSON);   //JSON�`���ɃV���A���C�Y��
            StreamWriter writer = new StreamWriter(datapath, false);    //���߂Ɏw�肵���f�[�^�̕ۑ�����J��
            writer.WriteLine(json); //JSON�f�[�^����������
            writer.Flush();         //�o�b�t�@���N���A����
            writer.Close();         //�t�@�C�����N���[�Y����

            //�t���O�̕ύX
            writeFlag = false;
        }

    }
}
