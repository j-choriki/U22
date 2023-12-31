using UnityEngine;

public class StartMusic : MonoBehaviour
{
    public AudioSource audioSource; // Inspectorで設定するAudioSource

    void Start()
    {
        // AudioSourceが設定されていることを確認
        if (audioSource == null)
        {
            Debug.LogError("AudioSourceが設定されていません。");
        }
    }

    void Update()
    {
        if (!audioSource.isPlaying)
        {
            PlayAudio();
        }
    }

    // 音声を再生する関数
    void PlayAudio()
    {
        // AudioSourceを再生
        audioSource.Play();
    }
}
