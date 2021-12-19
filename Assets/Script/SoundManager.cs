using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public AudioSource[] bgm;
    public AudioSource[] se;

    //シングルトン化
    void Awake()
    {
        //instanceに何も入ってなければ、SoundManagerを入れる。すでに入っている場合は新しく作成したinstanceを削除
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        //SoundManagerをシーン跨ぎで破壊しない
        DontDestroyOnLoad(gameObject);
    }

    /// <summary>
    /// SEを鳴らす[0]:タイトル画面でタップ[1]:ステージクリア[2]:ゲームオーバー[3]:ピンをタップ[4]:リセットボタンをタップ[5]:爆弾の爆発音
    /// </summary>
    /// <param name="x"></param>
    public void PlaySE(int x)
    {
        se[x].Stop();
        se[x].Play();
    }

    public void StopSE(int x)
    {
        se[x].Stop();
    }

    public void PlayBGM(int y)
    {
        bgm[y].Play();
    }

    public void StopBGM(int y)
    {
        bgm[y].Stop();
    }
}
