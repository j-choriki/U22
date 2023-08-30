using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowCanvas : MonoBehaviour
{
    private Canvas canvas;

    // GameManager���i�[���邽�߂̕ϐ�
    private JumpStageManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        // Canvas���擾
        canvas = GetComponent<Canvas>();

        // gameManager�̃I�u�W�F�N�g����
        gameManager = FindObjectOfType<JumpStageManager>();

        //3�b��ɕϐ��̒l��ύX����
        float delay = 4.0f; // �x�����ԁi�b�j
        Invoke("CanvasShow", delay);
    }

    // Update is called once per frame
    void Update()
    {
        //�Q�[���I������΂P�b��Ƀp�����[�^�p�l�������
        if (gameManager.game == "fin")
        {
            float delay = 1.0f;
            Invoke("CanvasClose", delay);
        }
        else if (gameManager.jumpFlag && gameManager.game != "fin")//�p�����\�^�[20�ȉ��̎��̏���
        {
            float delay = 6.0f;//�W�����v���Ă���U�b���canvas�����
            Invoke("CanvasClose", delay);
        }
    }
    private void CanvasShow()
    {
        canvas.enabled = true;
    }

    private void CanvasClose()
    {
        canvas.enabled = false;
    }
}
