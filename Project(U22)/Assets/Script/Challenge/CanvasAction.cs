using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasAction : MonoBehaviour
{
    private ChallengeGameManager gm;
    private Canvas canvas;
    private string score;
    public Text textObject; // Text�I�u�W�F�N�g�ւ̎Q��

    // Start is called before the first frame update
    void Start()
    {
        //GameManager�̃C���X�^�X����
        gm = FindObjectOfType<ChallengeGameManager>();
        // Canvas���擾
        canvas = GetComponent<Canvas>();

    }

    // Update is called once per frame
    void Update()
    {
     
        //�Q�[�����I������Ε]����ʂ�\������
        if (gm.game == "fin")
        { 
            score = gm.getItemCnt.ToString();
            ChangeText(score);
            canvas.enabled = true;
        }
    }

    
    public void ChangeText(string newText)
    {
        if (textObject != null)
        {
            textObject.text = newText; // �e�L�X�g�̕ύX
        }
    }




}
