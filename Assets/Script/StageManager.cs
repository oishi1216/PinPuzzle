using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StageManager : MonoBehaviour
{

    //このリストと同様の内容に「judgementBall」リストをするとステージクリア
    public List<string> sampleBall = new List<string>();
    public GameObject clearUI;
    public GameObject gameOverUI;

    public bool clearFlag = false;

    //ゲーム中にTubeオブジェクトに触れたボールのタグを格納する
    public List<string> ball = new List<string>();

    //「ball」リストが「sampleBall」と同じ内容であるか判定のために使うリスト
    [SerializeField]
    private List<string> judgementBall = new List<string>();
    public int addListCount = 0;

    public void ClearJudgement()
    {
        //「sampleBall」リストの「addListCount」番目と「ball」リストの「addListCount」番目が同じであったら
        if (sampleBall[addListCount] == ball[addListCount])
        {
            //「judgementBall」リストに「sampleBall」リストの「addListCount」番目の内容を追加
            judgementBall.Add(sampleBall[addListCount]);
        }

        //「sampleBall」リストと「ball」リストの長さが同じであったら
        if (sampleBall.Count == ball.Count)
        {
            //Clearコルーチンを呼び出す
            StartCoroutine(Clear());
        }
    }

    //ステージをクリアしたらクリアUIを表示してstageNumberに1をプラスする
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

    //ゲームオーバーになったらゲームオーバーUIを表示する
    public void GameOver()
    {
        SoundManager.instance.PlaySE(2);
        gameOverUI.SetActive(true);　　
    }

    //Clearコルーチンが呼び出されたら1.5秒後に
    private IEnumerator Clear()
    {

        yield return new WaitForSeconds(1.5f);

        //「judgementBall」リストと「sampleBall」リストの長さが同じであったら
        if (judgementBall.Count == sampleBall.Count)
        {
            //「clearFlag」をtrueにしてStageClear関数を呼び出す
            clearFlag = true;
            StageClear();
        }
        else
        {
            //「judgementBall」リストと「sampleBall」リストの長さが違ったらGameOver関数を呼び出す。
            GameOver();
        }
    }
}
