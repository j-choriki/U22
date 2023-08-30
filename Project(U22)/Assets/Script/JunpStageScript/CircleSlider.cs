using UnityEngine;
using UnityEngine.UI;

public class CircleSlider : MonoBehaviour
{
    [SerializeField] Transform handle;
    [SerializeField] Text valTxt;

    Vector3 mousePos;

    void Start()
    {
        // �J�n���Ƀe�L�X�g�� "0" �ɐݒ�
        valTxt.text = "0";
    }

    public void OnHandleDrag()
    {
        mousePos = Input.mousePosition;
        Vector2 dir = mousePos - handle.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        angle = (angle <= 0) ? (360 + angle) : angle;

        if (angle >= 130 && angle <= 320)
        {
            Quaternion rotation = Quaternion.AngleAxis(angle + 135f, Vector3.forward);
            handle.rotation = rotation;
            angle -= 20;

            // �l�͈̔͂�0~100�ɕϊ����ĕ\��
            float normalizedValue = Mathf.InverseLerp(320f, 130f, angle);

            // ���ʂȏ�����ǉ�����0�̎���100�ƕ\������Ȃ��悤�ɂ���
            if (normalizedValue == 0f)
            {
                valTxt.text = "0";
            }
            else
            {
                int valueInRange = Mathf.RoundToInt(normalizedValue * 100f);
                valTxt.text = valueInRange.ToString();
            }
        }
        else
        {
            valTxt.text = "0"; // angle��130~320�͈̔͊O�̏ꍇ��0�ƕ\������
        }
    }
}
