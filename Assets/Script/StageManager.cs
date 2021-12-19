using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StageManager : MonoBehaviour
{

    //���̃��X�g�Ɠ��l�̓��e�ɁujudgementBall�v���X�g������ƃX�e�[�W�N���A
    public List<string> sampleBall = new List<string>();
    public GameObject clearUI;
    public GameObject gameOverUI;

    public bool clearFlag = false;

    //�Q�[������Tube�I�u�W�F�N�g�ɐG�ꂽ�{�[���̃^�O���i�[����
    public List<string> ball = new List<string>();

    //�uball�v���X�g���usampleBall�v�Ɠ������e�ł��邩����̂��߂Ɏg�����X�g
    [SerializeField]
    private List<string> judgementBall = new List<string>();
    public int addListCount = 0;

    public void ClearJudgement()
    {
        //�usampleBall�v���X�g�́uaddListCount�v�ԖڂƁuball�v���X�g�́uaddListCount�v�Ԗڂ������ł�������
        if (sampleBall[addListCount] == ball[addListCount])
        {
            //�ujudgementBall�v���X�g�ɁusampleBall�v���X�g�́uaddListCount�v�Ԗڂ̓��e��ǉ�
            judgementBall.Add(sampleBall[addListCount]);
        }

        //�usampleBall�v���X�g�Ɓuball�v���X�g�̒����������ł�������
        if (sampleBall.Count == ball.Count)
        {
            //Clear�R���[�`�����Ăяo��
            StartCoroutine(Clear());
        }
    }

    //�X�e�[�W���N���A������N���AUI��\������stageNumber��1���v���X����
    public void StageClear()
    {
        SoundManager.instance.PlaySE(1);
        clearUI.SetActive(true);
        if (GameManager.instance.stageNumber == 10)
        {
            GameManager.instance.stageNumber = 1;
        }
        else
        {
            GameManager.instance.stageNumber++;
        }
        SaveManager.instance.SaveStage(GameManager.instance.stageNumber);
    }

    //�Q�[���I�[�o�[�ɂȂ�����Q�[���I�[�o�[UI��\������
    public void GameOver()
    {
        SoundManager.instance.PlaySE(2);
        gameOverUI.SetActive(true);�@�@
    }

    //Clear�R���[�`�����Ăяo���ꂽ��1.5�b���
    private IEnumerator Clear()
    {

        yield return new WaitForSeconds(1.5f);

        //�ujudgementBall�v���X�g�ƁusampleBall�v���X�g�̒����������ł�������
        if (judgementBall.Count == sampleBall.Count)
        {
            //�uclearFlag�v��true�ɂ���StageClear�֐����Ăяo��
            clearFlag = true;
            StageClear();
        }
        else
        {
            //�ujudgementBall�v���X�g�ƁusampleBall�v���X�g�̒������������GameOver�֐����Ăяo���B
            GameOver();
        }
    }
}
