using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowResultCanvas : MonoBehaviour
{
    private Canvas canvas;

    // GameManager���i�[���邽�߂̕ϐ�
    private JumpStageManager gameManager;

    //�Q�[���I�����ɕ\������摜�̃I�u�W�F�N�g
    public GameObject RetryImg;
    public GameObject SuccessImg;

    // Start is called before the first frame update
    void Start()
    {
        // Canvas���擾
        canvas = GetComponent<Canvas>();
        // gameManager�̃I�u�W�F�N�g����
        gameManager = FindObjectOfType<JumpStageManager>();

        //�Q�[���I�����ɕ\������摜�̔񊈐���
        if (RetryImg != null)
        {
            RetryImg.SetActive(false);
        }
        if (SuccessImg != null)
        {
            SuccessImg.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.game == "fin")
        {
            float delay = 1.5f ; // �x�����ԁi�b�j
            Invoke("CanvasShow", delay);
        }
        else if (gameManager.jumpFlag && gameManager.sendNum < 20)
        {
            float delay = 6.0f; // �x�����ԁi�b�j
            Invoke("CanvasShow", delay);
        }


    }

    private void CanvasShow()
    {
        canvas.enabled = true;     

        if (gameManager.juge == "success")
        {
            SuccessImg.SetActive(true);
        }
        else if (gameManager.juge == "fail")
        {
            RetryImg.SetActive(true);
        }

    }
}
    