using UnityEngine;

public class StartMusic : MonoBehaviour
{
    public AudioSource audioSource; // Inspector�Őݒ肷��AudioSource

    void Start()
    {
        // AudioSource���ݒ肳��Ă��邱�Ƃ��m�F
        if (audioSource == null)
        {
            Debug.LogError("AudioSource���ݒ肳��Ă��܂���B");
        }
    }

    void Update()
    {
        if (!audioSource.isPlaying)
        {
            PlayAudio();
        }
    }

    // �������Đ�����֐�
    void PlayAudio()
    {
        // AudioSource���Đ�
        audioSource.Play();
    }
}
