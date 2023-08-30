using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpStageJump : MonoBehaviour
{
    // GameManagerを格納するための変数
    private JumpStageManager gameManager;
    
    private Rigidbody rb;

    //ジャンプ力の数値が入る変数
    private float jumpPramater;
   
    // ジャンプに必要な変数
    private bool isJumping = false;

    //アニメーター関係の変数
    private Animator animator;
    private const string key_isJump = "jump";

    //audioSource
    public AudioClip sound1;
    AudioSource audioSource;

    //ジャンプのプログラムを一度だけにしたいだけの変数
    private int cnt; 


    // Start is called before the first frame update
    void Start()
    {
        // gameManagerのオブジェクトを代入
        gameManager = FindObjectOfType<JumpStageManager>();
        // Rigidbodyコンポーネントを取得
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

        //audioのComponentを取得
        audioSource = GetComponent<AudioSource>();

        cnt = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // ゲージが動き終わった後にジャンプする
        if (gameManager.jumpStart && !isJumping)
        {
            jumpPramater = gameManager.sendNum * 0.15f;//*以降の数値で横ののジャンプ力が変わる
            //cntで一度だけ処理させないと何度も呼び出される(ジャンプ音やジャンプモーションがバグる)
            if (cnt == 0)
            {
                StartCoroutine(Jump(jumpPramater));
                cnt++;//変数を更新して一だけの呼び出しにする
            }
        }
    }

    public IEnumerator Jump(float jumpPower)// ジャンプするための関数
    {
        animator.SetBool(key_isJump, true);
        yield return new WaitForSeconds(0.5f);
        rb.velocity = new Vector3(jumpPower, 20f, 0f);  //Vector3(横移動, 上下移動, 奥行移動
        audioSource.PlayOneShot(sound1);                //ジャンプ音
        isJumping = true;
        animator.SetBool(key_isJump, false);
    }

    //当たった物よってリザルトで表示する画像を変える
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
