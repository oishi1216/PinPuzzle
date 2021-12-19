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
        //Tubeオブジェクト内でのボールの反射によって｢ball｣リストに同一の情報が登録されないように「tubeContact○○」がtrueかつ「addList」がfalseのときに
        //ボールのタグ名を｢ball｣リストを登録し、ClearJudgement関数を呼び出し、「addListCount」を1足して、「addList」をtrueにする。
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
        //Tubeオブジェクトにボールが触れたとき
        if (collision.gameObject.tag == "Tube")
        {
            //「ballTag」にボールについているタグを格納
            string ballTag = this.gameObject.tag;

            //「ballTag」に格納されたタグ名によって対応する「tubeContact○○」の変数をtrueにする。
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
                    Debug.Log("エラー");
                    break;
            }
        }

    }



}
