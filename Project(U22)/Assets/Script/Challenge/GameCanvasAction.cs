using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCanvasAction : MonoBehaviour
{
    private ChallengeGameManager gm;
    public Canvas gameCanvas;
    private string score;
    public Text textObject; // Text�I�u�W�F�N�g�ւ̎Q��
   
    // Start is called before the first frame update
    void Start()
    {
        //GameManager�̃C���X�^�X����
        gm = FindObjectOfType<ChallengeGameManager>();
        gameCanvas = GetComponent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        score = gm.getItemCnt.ToString();
        ChangeText(score);
        if (gm.game == "fin")
        {
            //�E��X�R�A�̔�\����
            gameCanvas.enabled = false;
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
