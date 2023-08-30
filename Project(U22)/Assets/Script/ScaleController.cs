using UnityEngine;

public class ScaleController : MonoBehaviour
{
    private Vector3 initialScale;

    private void Awake()
    {
        initialScale = transform.localScale;
    }

    private void Update()
    {
        // Scaleを常に初期スケールに保つ
        transform.localScale = initialScale;
    }
}
