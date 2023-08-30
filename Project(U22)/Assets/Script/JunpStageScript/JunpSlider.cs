using UnityEngine;
using UnityEngine.UI;

public class JunpSlider: MonoBehaviour
{
    [SerializeField] Transform needleTransform;

    //GameManagerを格納するための変数
    private JumpStageManager gameManager;

    // 初期角度
    private float initialAngle;

    private void Start()
    {
        // 初期角度を計算
        initialAngle = needleTransform.localEulerAngles.z;
        //gameManagerのオブジェクトを代入
        gameManager = FindObjectOfType<JumpStageManager>();
    }

    public void Update()
    {
        
        //0以外の数値の時に針を動かす
        if (gameManager.sendNum != 0)
        {
            UpdateMeter(gameManager.sendNum);

            //3秒後に変数の値を変更する
            float delay = 2.0f; // 遅延時間（秒）
            Invoke("ChangeValueAfterDelay", delay);
        }
        
    }

    //メ―ターの針を動かすための関数

    public float rotationSpeed = 2.0f; // 回転速度の調整用変数

    public void UpdateMeter(float value)
    {
        // valueの範囲を0から1に正規化
        float normalizedValue = Mathf.Clamp01(value / 100f);
      
        // 320f から 130f の範囲で targetAngle を計算
        float targetAngle = Mathf.Lerp(370f, 180.5f, normalizedValue);
        
        // 初期角度に追加して、針を回転
        float currentAngle = needleTransform.localEulerAngles.z;
        float newAngle = initialAngle + targetAngle;

        // 補間を使用してゆっくり回転
        currentAngle = Mathf.LerpAngle(currentAngle, newAngle, Time.deltaTime * rotationSpeed);

        // 新しい角度を設定
        Vector3 newRotation = new Vector3(0f, 0f, currentAngle);
        needleTransform.localEulerAngles = newRotation;
    }

    //遅延時間後に変更したい変数を関数の中で定義
    private void ChangeValueAfterDelay()
    {
        gameManager.jumpStart = true; 
    }
}
