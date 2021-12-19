using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int stageNumber = 0;
    private bool starFlag = false;

    public UIManagaer_Title uiManager_Title;

    //�V���O���g����
    void Awake()
    {
        //instance�ɉ��������ĂȂ���΁AGameManager������B���łɓ����Ă���ꍇ�͐V�����쐬����instance���폜
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        //GameManager���V�[���ׂ��Ŕj�󂵂Ȃ�
        DontDestroyOnLoad(gameObject);
    }

    public void LoadSceneStage()
    {
        //stageNumber��0(�^�C�g�����)�ł�������
        if (stageNumber == 0)
        {
            //�X�^�[�g��SE��炷
            SoundManager.instance.PlaySE(0);
            //TapToStart��blink�̃X�s�[�h���グ��
            uiManager_Title.blinkSpeed = 20.0f;
            //starFlag��true�ɕύX
            starFlag = true;

            //���݂̃N���A�X�e�[�W�����[�h
            SaveManager.instance.LoadStage();

            //�R���[�`����2�b��Ɏ��̃V�[���ɑJ�ڂ���
            StartCoroutine(StartGame());
        }
        //stageNumber��0(�^�C�g�����)�ȊO�ł�������
        else if(stageNumber != 0 && starFlag == false)
        {
            //���̃X�e�[�W�̃V�[���ɑJ�ڂ���
            SceneManager.LoadScene("Stage" + stageNumber);
            //�N���ASE���~�߂�
            SoundManager.instance.StopSE(1);
        }

         //���݂̃V�[����Stage�Z�ł���A����StageBGM���ĂȂ��Ȃ�StageBGM��炷
        if (SceneManager.GetActiveScene().name == "Stage" + stageNumber && !SoundManager.instance.bgm[1].isPlaying)
        {
            SoundManager.instance.PlayBGM(1);
        }
    }

    //Reset�{�^�����������Ƃ��ɃV�[�����ēǂݍ��݂���
    public void OnResetButton()
    {
        SoundManager.instance.PlaySE(4);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //2�b���Stage�Z�̃V�[���ɑJ�ڂ��ATitleBGM��������StageBGM��炷
    private IEnumerator StartGame()
    {

        yield return new WaitForSeconds(2.0f);

        SceneManager.LoadScene("Stage" + stageNumber);
        SoundManager.instance.StopBGM(0);
        SoundManager.instance.PlayBGM(1);
        starFlag = false;
    }


}
