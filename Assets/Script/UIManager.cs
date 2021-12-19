using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField]
    private GameObject stageTextObj;
    [SerializeField]
    private Text stageText;

    //�V���O���g����
    void Awake()
    {
        //instance�ɉ��������ĂȂ���΁AUIManager������B���łɓ����Ă���ꍇ�͐V�����쐬����instance���폜
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        //UIManager���V�[���ׂ��Ŕj�󂵂Ȃ�
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        SceneManager.activeSceneChanged += OnActiveSceneChanged;
    }

    public void OnActiveSceneChanged(Scene prevScene, Scene nextScene)
    {
        stageTextObj = GameObject.FindWithTag("StageText");
        stageText = stageTextObj.GetComponent<Text>();
        //���݂̃X�e�[�W��\������e�L�X�gUI�Ɍ��݂�stageNumber�̐���������
        stageText.text = "Stage" + GameManager.instance.stageNumber;
    }
}
