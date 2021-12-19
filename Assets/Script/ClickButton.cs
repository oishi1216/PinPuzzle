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
        //Buttonコンポーネントを取得
        button = GetComponent<Button>();

        if (this.tag == "ClearUI")
        {
            //クリックしたときにGameManagerのLoadSceneStage()を呼び出して次のステージへ遷移
            button.onClick.AddListener(GameManager.instance.LoadSceneStage);
        }
        else if (this.tag == "GameOverUI")
        {
            //クリックしたときにGameManagerのOnResetButton()を呼び出してステージを再読み込み
            button.onClick.AddListener(GameManager.instance.OnResetButton);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
