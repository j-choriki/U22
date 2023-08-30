using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpStageJump : MonoBehaviour
{
    // GameManager���i�[���邽�߂̕ϐ�
    private JumpStageManager gameManager;
    
    private Rigidbody rb;

    //�W�����v�͂̐��l������ϐ�
    private float jumpPramater;
   
    // �W�����v�ɕK�v�ȕϐ�
    private bool isJumping = false;

    //�A�j���[�^�[�֌W�̕ϐ�
    private Animator animator;
    private const string key_isJump = "jump";

    //audioSource
    public AudioClip sound1;
    AudioSource audioSource;

    //�W�����v�̃v���O��������x�����ɂ����������̕ϐ�
    private int cnt; 


    // Start is called before the first frame update
    void Start()
    {
        // gameManager�̃I�u�W�F�N�g����
        gameManager = FindObjectOfType<JumpStageManager>();
        // Rigidbody�R���|�[�l���g���擾
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

        //audio��Component���擾
        audioSource = GetComponent<AudioSource>();

        cnt = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // �Q�[�W�������I�������ɃW�����v����
        if (gameManager.jumpStart && !isJumping)
        {
            jumpPramater = gameManager.sendNum * 0.15f;//*�ȍ~�̐��l�ŉ��̂̃W�����v�͂��ς��
            //cnt�ň�x�������������Ȃ��Ɖ��x���Ăяo�����(�W�����v����W�����v���[�V�������o�O��)
            if (cnt == 0)
            {
                StartCoroutine(Jump(jumpPramater));
                cnt++;//�ϐ����X�V���Ĉꂾ���̌Ăяo���ɂ���
            }
        }
    }

    public IEnumerator Jump(float jumpPower)// �W�����v���邽�߂̊֐�
    {
        animator.SetBool(key_isJump, true);
        yield return new WaitForSeconds(0.5f);
        rb.velocity = new Vector3(jumpPower, 20f, 0f);  //Vector3(���ړ�, �㉺�ړ�, ���s�ړ�
        audioSource.PlayOneShot(sound1);                //�W�����v��
        isJumping = true;
        animator.SetBool(key_isJump, false);
    }

    //��������������ă��U���g�ŕ\������摜��ς���
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "success")
        {
            gameManager.juge = "success";
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "fail")
        {
            gameManager.juge = "fail";
        }
    }
}
