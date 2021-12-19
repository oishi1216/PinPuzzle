using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManagaer_Title : MonoBehaviour
{
    [SerializeField]
    private Text startText;
    private float blinkTime;
    public float blinkSpeed = 4.0f;

    // Update is called once per frame
    void Update()
    {
        //startText.colorにBlinkStart関数で決められたcolorを代入
        startText.color = BlinkStart(startText.color);
    }

    //テキストを透過させたり元に戻したりする
    Color BlinkStart(Color color)
    {
        blinkTime += Time.deltaTime * blinkSpeed;
        color.a = Mathf.Sin(blinkTime);

        return color;
    }
}
