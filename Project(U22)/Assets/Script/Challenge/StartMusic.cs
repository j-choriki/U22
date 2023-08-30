using UnityEngine;

public class StartMusic : MonoBehaviour
{
    public AudioSource audioSource; // Inspector‚Åİ’è‚·‚éAudioSource

    void Start()
    {
        // AudioSource‚ªİ’è‚³‚ê‚Ä‚¢‚é‚±‚Æ‚ğŠm”F
        if (audioSource == null)
        {
            Debug.LogError("AudioSource‚ªİ’è‚³‚ê‚Ä‚¢‚Ü‚¹‚ñB");
        }
    }

    void Update()
    {
        if (!audioSource.isPlaying)
        {
            PlayAudio();
        }
    }

    // ‰¹º‚ğÄ¶‚·‚éŠÖ”
    void PlayAudio()
    {
        // AudioSource‚ğÄ¶
        audioSource.Play();
    }
}
