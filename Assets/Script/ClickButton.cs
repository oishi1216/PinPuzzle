using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ClickButton : MonoBehaviour
{
    private Button button;

    // Start is called before the first frame update
    void Start()
    {
        //Button�R���|�[�l���g���擾
        button = GetComponent<Button>();

        if (this.tag == "ClearUI")
        {
            //�N���b�N�����Ƃ���GameManager��LoadSceneStage()���Ăяo���Ď��̃X�e�[�W�֑J��
            button.onClick.AddListener(GameManager.instance.LoadSceneStage);
        }
        else if (this.tag == "GameOverUI")
        {
            //�N���b�N�����Ƃ���GameManager��OnResetButton()���Ăяo���ăX�e�[�W���ēǂݍ���
            button.onClick.AddListener(GameManager.instance.OnResetButton);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
