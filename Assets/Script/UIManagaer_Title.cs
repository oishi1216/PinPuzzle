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
        //startText.color��BlinkStart�֐��Ō��߂�ꂽcolor����
        startText.color = BlinkStart(startText.color);
    }

    //�e�L�X�g�𓧉߂������茳�ɖ߂����肷��
    Color BlinkStart(Color color)
    {
        blinkTime += Time.deltaTime * blinkSpeed;
        color.a = Mathf.Sin(blinkTime);

        return color;
    }
}
