using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//�ȉ��ǋL
using UnityEngine.Networking;// WWW���g������
using System.IO;// File���g������

public class ReadJSON : MonoBehaviour
{//=====�ϐ��錾��===========================================================================

    //�ǂݍ���php�t�@�C���܂ł̃p�X
    private string phpPath = "https://tsumikikun.sakura.ne.jp/letsgotsumiki/pupil/testdb_unity.php";

    //�t�@�C���p�X���i�[
    private string filepath = Application.streamingAssetsPath;

    //�L�����N�^�[�������񐔂��J�E���g����ϐ�
    public int cnt = 0;

    //�L�����N�^�[���������߂̔z��̓Y����������鐔�����i�[�����(cnt-1)
    public int ArrayControl;

    //JSON�t�@�C�����ۑ�����Ă���t�H���_�����i�[����
    public string resultText;

    //JSON�œǂݍ��񂾃f�[�^��z��Ŋi�[
    public string result;


    //�ς܂ꂽ�ςݖ؂̌���z��Ŋi�[
    public string numberResult;

    //�N���A�̍ŏ����i�[����ϐ�
    public int numberCnt;

    //�ςݖ؂̎w����JSON���瑗���Ă���z��
    [System.Serializable]
    public class InputJSON
    {
        public string[] process;
    }

    //�ς񂾐ςݖ؂̌���JSON���瑗��ꂭ��z��
    [System.Serializable]
    public class Number
    {
        public string[] process;
    }

    public int aryCnt;

    //=====������================================================================================
    public IEnumerator textLoad()
    {
        //�I�����C���p�Ŏg�p����PHP�Ɋւ��鏈��
        WWW wwwphp = new WWW(phpPath);
        yield return wwwphp;
        resultText = wwwphp.text;

        //�w����ǂݍ��ނ��߂�JSON���i�[����Ă���t�@�C���p�X
        string readJSONPath = filepath + "/" + resultText + ".json";//�I�����C���p
        
        if (readJSONPath.Contains("://") || readJSONPath.Contains(":///"))//�@�I�����C���p
        {
            WWW www = new WWW(readJSONPath);
            yield return www;
            result = www.text;
            InputJSON inputJSON = JsonUtility.FromJson<InputJSON>(result);
            //JSON�ɋL�ڂ���Ă���w���̌����ϐ����C���N�������g
            foreach (string p in inputJSON.process)
            {
                cnt++;
            }
            aryCnt = cnt - 1;
        }
        else// �I�t���C���p
        {
            result = File.ReadAllText(readJSONPath);// �t�@�C���f�[�^�����ׂēǂݍ��ݕ�����^�̔z��ŕԂ�
            InputJSON inputJson = JsonUtility.FromJson<InputJSON>(result);
            foreach (string p in inputJson.process)
            {
                cnt++;
            }
            aryCnt = cnt - 1;
        }

        //�ς܂ꂽ�ςݖ؂̐����i�[���Ă���JSON�t�@�C���̓ǂݍ���
        //�ς܂ꂽ�ςݖ؂̐����i�[���Ă���JSON�t�@�C���܂ł̃p�X
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
            numberResult = File.ReadAllText(numberFilepath);// �t�@�C���f�[�^�����ׂēǂݍ��ݕ�����^�̔z��ŕԂ�
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
