using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public StageManager StageManager; 
    private bool tubeContactBlue = false;
    private bool tubeContactGreen = false;
    private bool tubeContactOrange = false;
    private bool tubeContactPurple = false;
    private bool addList = false;

    // Update is called once per frame
    void Update()
    {
        //Tube�I�u�W�F�N�g���ł̃{�[���̔��˂ɂ���Ģball����X�g�ɓ���̏�񂪓o�^����Ȃ��悤�ɁutubeContact�����v��true���uaddList�v��false�̂Ƃ���
        //�{�[���̃^�O����ball����X�g��o�^���AClearJudgement�֐����Ăяo���A�uaddListCount�v��1�����āA�uaddList�v��true�ɂ���B
        if (tubeContactBlue == true && !addList)
        {
            StageManager.ball.Add("BlueBall");
            StageManager.ClearJudgement();
            StageManager.addListCount++;
            addList = true;
        }
        else if (tubeContactGreen == true && !addList)
        {
            StageManager.ball.Add("GreenBall");
            StageManager.ClearJudgement();
            StageManager.addListCount++;
            addList = true;
        }
        else if (tubeContactOrange == true && !addList)
        {
            StageManager.ball.Add("OrangeBall");
            StageManager.ClearJudgement();
            StageManager.addListCount++;
            addList = true;
        }
        else if (tubeContactPurple == true && !addList)
        {
            StageManager.ball.Add("PurpleBall");
            StageManager.ClearJudgement();
            StageManager.addListCount++;
            addList = true;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        //Tube�I�u�W�F�N�g�Ƀ{�[�����G�ꂽ�Ƃ�
        if (collision.gameObject.tag == "Tube")
        {
            //�uballTag�v�Ƀ{�[���ɂ��Ă���^�O���i�[
            string ballTag = this.gameObject.tag;

            //�uballTag�v�Ɋi�[���ꂽ�^�O���ɂ���đΉ�����utubeContact�����v�̕ϐ���true�ɂ���B
            switch (ballTag)
            {
                case "BlueBall":
                    tubeContactBlue = true;
                    break;
                case "GreenBall":
                    tubeContactGreen = true;
                    break;
                case "OrangeBall":
                    tubeContactOrange = true;
                    break;
                case "PurpleBall":
                    tubeContactPurple = true;
                    break;
                default:
                    Debug.Log("�G���[");
                    break;
            }
        }

    }



}
