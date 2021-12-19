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

    //シングルトン化
    void Awake()
    {
        //instanceに何も入ってなければ、UIManagerを入れる。すでに入っている場合は新しく作成したinstanceを削除
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        //UIManagerをシーン跨ぎで破壊しない
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
        //現在のステージを表示するテキストUIに現在のstageNumberの数字を入れる
        stageText.text = "Stage" + GameManager.instance.stageNumber;
    }
}
