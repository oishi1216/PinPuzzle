using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PinManager : MonoBehaviour
{
    public static PinManager instance;


    //ピンを飛ばすスピードを設定
    private float speed = 0.3f;
    private int frame = 100;

    //シングルトン化
    void Awake()
    {
        //instanceに何も入ってなければ、PinManagerを入れる。すでに入っている場合は新しく作成したinstanceを削除
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        //PinManagerをシーン跨ぎで破壊しない
        DontDestroyOnLoad(gameObject);
    }

    public void OnClickPin(PointerEventData eventData)
    {
        //クリックしたオブジェクトを取得
        GameObject clickedObject = eventData.pointerPress;

        //クリックしたオブジェクトがPinタグを持っていたらオブジェクトを飛ばす
        if (clickedObject.tag == "Pin")
        {
            //ピンを飛ばす効果音を鳴らす
            SoundManager.instance.PlaySE(3);
            //飛ばす方向を決定
            Vector3 velocity = clickedObject.transform.rotation * new Vector3(speed, 0, 0);
            //コルーチンで徐々にピンを移動させる
            StartCoroutine(movePin(clickedObject, velocity));
        }
    }

    private IEnumerator movePin(GameObject gameObject, Vector3 velocity)
    {
        //「i」が「frame」の値になるまでピンを徐々に動かす
        for (int i = 0; i < frame; i++)
        {
            yield return null;

            gameObject.transform.position -= velocity * i / 30;
        }
        //移動し終わったオブジェクトを破壊
        if(frame <= 0)
        {
            Destroy(gameObject);
        }
    }

}
