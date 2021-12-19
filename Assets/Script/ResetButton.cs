using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetButton : MonoBehaviour
{
    private Button button;

    // Start is called before the first frame update
    void Start()
    {
        //Buttonコンポーネントを取得
        button = GetComponent<Button>();
        //クリックしたときにGameManagerのLoadSceneStage()を呼び出して次のステージへ遷移
        button.onClick.AddListener(GameManager.instance.OnResetButton);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
