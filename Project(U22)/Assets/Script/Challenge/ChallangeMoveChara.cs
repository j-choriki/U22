using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChallangeMoveChara : MonoBehaviour
{
    //=====変数宣言部=======================================================================
    private const string key_isWalk = "walk";
    private const string key_isJump = "jump";

    //Rigidbody用の変数
    private Rigidbody rb;

    //animator用の変数
    private Animator animator;

    // ��]�̑��x�𒲐�
    private float turnSpeed;

    //GmaeManagerの宣言
    private ChallengeGameManager gm;

    //梯子を上る管理をしている変数
    public bool crimeFlag;

    public AudioClip walkSound; // 歩行効果音のAudioSource
    public AudioClip jumpSound; // ジャンプ効果音のAudioSource
    public AudioClip crimeSound; // ジャンプ効果音のAudioSource



    //===ココからStart()=====================================================================
    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Rigidbodyコンポーネントの参照を取得して代入
        gm = FindObjectOfType<ChallengeGameManager>();//GameManagerのインスタス生成
        crimeFlag = false;//梯子をのぼるための変数
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.aryCnt >= -1)//GameManegerのmoveCntのカウントが０でない時
        {
            if (gm.charaAction == "walk")//キャラクターの指示がwalkの時
            {
                StartCoroutine(Advance());
            }
            else if (gm.charaAction == "jump")//キャラクターの指示がjumpの時
            {
                StartCoroutine(Jump());
            }
            else if (gm.charaAction == "climb")//キャラクターの指示がcrimeの時
            {
                if (crimeFlag)
                {
                    StartCoroutine(Up());
                }
            }
        }
    }

    //====コルーチン関数を定義==============================================================
    public IEnumerator Advance()//一歩進む
    {
        animator.SetBool(key_isWalk, true);
        rb.velocity = new Vector3(3.46f, 0, 0);//Vector3(横移動, 上下移動, 奥行移動)
        AudioSource.PlayClipAtPoint(walkSound, transform.position); // 歩行効果音を再生
        yield return new WaitForSeconds(0.3f);
        animator.SetBool(key_isWalk, false);
    }

    public IEnumerator Jump()// ジャンプするための関数
    {
        animator.SetBool(key_isJump, true);
        yield return new WaitForSeconds(1.5f); // 1.5秒待機
        rb.velocity = new Vector3(1.4f, 6.0f, 0f);//Vector3(横移動, 上下移動, 奥行移動
        AudioSource.PlayClipAtPoint(jumpSound, transform.position); // ジャンプ効果音を再生
        yield return null;//1フレーム待機
        animator.SetBool(key_isJump, false);
    }

    //Up,OneWalk,TurnBackは梯子をのぼるためのコルーチン
    public IEnumerator Up() //梯子を上る
    {
        float t = 0f;
        Quaternion startRotation = transform.rotation;
        Quaternion endRotation = Quaternion.Euler(0, 0f, 0);//回転用
        //梯子方向へ向きを変更
        while (t < 1.0f)
        {
            t += Time.deltaTime * 2.0f;
            transform.rotation = Quaternion.Lerp(startRotation, endRotation, t);
            yield return null;
        }

        rb.velocity = new Vector3(0f, 0f, 3.0f);//梯子方向に移動
        yield return new WaitForSeconds(1.0f); // 1.5秒待機
        rb.velocity = new Vector3(0, 5.0f, 0);//上昇の記述
        AudioSource.PlayClipAtPoint(crimeSound, transform.position); // ジャンプ効果音を再生
        rb.useGravity = false;//重力の無効化
        yield return null;
    }

    public IEnumerator OneWalk()// ステージへ上がる
    {
        rb.velocity = new Vector3(0f, 0f, -3.0f);
        yield return null;
    }


    public IEnumerator TurnBack()//進行方向に向きを変える
    {
        float t = 0f;
        Quaternion startRotation = transform.rotation;
        Quaternion endRotation = Quaternion.Euler(0, 90f, 0);//進行方向の向きへ
        while (t < 1f)
        {
            t += Time.deltaTime * 1.0f;
            transform.rotation = Quaternion.Lerp(startRotation, endRotation, t);
            yield return null;
        }
        yield return new WaitForSeconds(2.0f); // 1.5秒待機
    }

    //====以下関数============================================================================
    private void OnTriggerEnter(Collider other)
    {
        //梯子を上るかの判断
        if (other.gameObject.tag == "crime" && !crimeFlag)
        {
            crimeFlag = true;
        }
        else if (other.gameObject.tag == "crimeEnd" && crimeFlag)
        {
            StartCoroutine(TurnBack());
            StartCoroutine(OneWalk());
            crimeFlag = false;
            rb.useGravity = true;
        }
        else if (other.gameObject.tag == "crimeCancel" && crimeFlag)
        {
            crimeFlag = false;
        }

        //ステージ外などに行ったときの処理
        if (other.gameObject.tag == "gameOver")
        {
            gm.gameOverFlag = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "boxShow")
        {
            gm.boxShow = "show";
        }
    }
}
