using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{

    InputField inputField;


    /// <summary>
    /// Start���\�b�h
    /// InputField�R���|�[�l���g�̎擾����я��������\�b�h�̎��s
    /// </summary>
    void Start()
    {

        inputField = GetComponent<InputField>();

        InitInputField();
    }



    /// <summary>
    /// Log�o�͗p���\�b�h
    /// ���͒l���擾����Log�ɏo�͂��A������
    /// </summary>


    public void InputLogger()
    {

        string inputValue = inputField.text;

        Debug.Log(inputValue);

        InitInputField();
    }



    /// <summary>
    /// InputField�̏������p���\�b�h
    /// ���͒l�����Z�b�g���āA�t�B�[���h�Ƀt�H�[�J�X����
    /// </summary>


    void InitInputField()
    {

        // �l�����Z�b�g
        inputField.text = "";

        // �t�H�[�J�X
        inputField.ActivateInputField();
    }

}