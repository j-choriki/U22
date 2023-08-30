using UnityEngine;
using UnityEngine.UI;

public class JunpSlider: MonoBehaviour
{
    [SerializeField] Transform needleTransform;

    //GameManager���i�[���邽�߂̕ϐ�
    private JumpStageManager gameManager;

    // �����p�x
    private float initialAngle;

    private void Start()
    {
        // �����p�x���v�Z
        initialAngle = needleTransform.localEulerAngles.z;
        //gameManager�̃I�u�W�F�N�g����
        gameManager = FindObjectOfType<JumpStageManager>();
    }

    public void Update()
    {
        
        //0�ȊO�̐��l�̎��ɐj�𓮂���
        if (gameManager.sendNum != 0)
        {
            UpdateMeter(gameManager.sendNum);

            //3�b��ɕϐ��̒l��ύX����
            float delay = 2.0f; // �x�����ԁi�b�j
            Invoke("ChangeValueAfterDelay", delay);
        }
        
    }

    //���\�^�[�̐j�𓮂������߂̊֐�

    public float rotationSpeed = 2.0f; // ��]���x�̒����p�ϐ�

    public void UpdateMeter(float value)
    {
        // value�͈̔͂�0����1�ɐ��K��
        float normalizedValue = Mathf.Clamp01(value / 100f);
      
        // 320f ���� 130f �͈̔͂� targetAngle ���v�Z
        float targetAngle = Mathf.Lerp(370f, 180.5f, normalizedValue);
        
        // �����p�x�ɒǉ����āA�j����]
        float currentAngle = needleTransform.localEulerAngles.z;
        float newAngle = initialAngle + targetAngle;

        // ��Ԃ��g�p���Ă�������]
        currentAngle = Mathf.LerpAngle(currentAngle, newAngle, Time.deltaTime * rotationSpeed);

        // �V�����p�x��ݒ�
        Vector3 newRotation = new Vector3(0f, 0f, currentAngle);
        needleTransform.localEulerAngles = newRotation;
    }

    //�x�����Ԍ�ɕύX�������ϐ����֐��̒��Œ�`
    private void ChangeValueAfterDelay()
    {
        gameManager.jumpStart = true; 
    }
}
