using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetButton : MonoBehaviour
{
    private Button button;

    // Start is called before the first frame update
    void Start()
    {
        //Button�R���|�[�l���g���擾
        button = GetComponent<Button>();
        //�N���b�N�����Ƃ���GameManager��LoadSceneStage()���Ăяo���Ď��̃X�e�[�W�֑J��
        button.onClick.AddListener(GameManager.instance.OnResetButton);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
