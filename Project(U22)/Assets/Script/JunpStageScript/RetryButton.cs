using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryButton : MonoBehaviour
{
    // ���g���C�{�^�����N���b�N���ꂽ�Ƃ��ɌĂ΂�郁�\�b�h
    public void OnRetryButtonClick()
    {
        // ���݂̃V�[�����ēǂݍ���
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
