using UnityEngine;
using UnityEngine.UI;

public class CircleSlider : MonoBehaviour
{
    [SerializeField] Transform handle;
    [SerializeField] Text valTxt;

    Vector3 mousePos;

    void Start()
    {
        // 開始時にテキストを "0" に設定
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

            // 値の範囲を0~100に変換して表示
            float normalizedValue = Mathf.InverseLerp(320f, 130f, angle);

            // 特別な処理を追加して0の時に100と表示されないようにする
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
            valTxt.text = "0"; // angleが130~320の範囲外の場合も0と表示する
        }
    }
}
