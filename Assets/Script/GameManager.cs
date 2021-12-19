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

    //シングルトン化
    void Awake()
    {
        //instanceに何も入ってなければ、GameManagerを入れる。すでに入っている場合は新しく作成したinstanceを削除
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        //GameManagerをシーン跨ぎで破壊しない
        DontDestroyOnLoad(gameObject);
    }

    public void LoadSceneStage()
    {
        //stageNumberが0(タイトル画面)であったら
        if (stageNumber == 0)
        {
            //スタートのSEを鳴らす
            SoundManager.instance.PlaySE(0);
            //TapToStartのblinkのスピードを上げる
            uiManager_Title.blinkSpeed = 20.0f;
            //starFlagをtrueに変更
            starFlag = true;

            //現在のクリアステージをロード
            SaveManager.instance.LoadStage();

            //コルーチンで2秒後に次のシーンに遷移する
            StartCoroutine(StartGame());
        }
        //stageNumberが0(タイトル画面)以外であったら
        else if(stageNumber != 0 && starFlag == false)
        {
            //次のステージのシーンに遷移する
            SceneManager.LoadScene("Stage" + stageNumber);
            //クリアSEを止める
            SoundManager.instance.StopSE(1);
        }

         //現在のシーンがStage〇であり、かつStageBGM鳴ってないならStageBGMを鳴らす
        if (SceneManager.GetActiveScene().name == "Stage" + stageNumber && !SoundManager.instance.bgm[1].isPlaying)
        {
            SoundManager.instance.PlayBGM(1);
        }
    }

    //Resetボタンを押したときにシーンを再読み込みする
    public void OnResetButton()
    {
        SoundManager.instance.PlaySE(4);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //2秒後にStage〇のシーンに遷移し、TitleBGMを消してStageBGMを鳴らす
    private IEnumerator StartGame()
    {

        yield return new WaitForSeconds(2.0f);

        SceneManager.LoadScene("Stage" + stageNumber);
        SoundManager.instance.StopBGM(0);
        SoundManager.instance.PlayBGM(1);
        starFlag = false;
    }


}
