using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionProcess : MonoBehaviour
{
    public float speed;
    private bool explosionFlag = false;
    public List<GameObject> collisionList = new List<GameObject>();
    public List<Rigidbody2D> collisionRyList = new List<Rigidbody2D>();
    public List<string> collisionTagList = new List<string>();

    private void OnTriggerEnter2D(Collider2D collider)
    {
        //「explosionFlag」がfalseなら
        if (!explosionFlag)
        {
            //接触しているのがボールだったら
            if (collider.gameObject.tag == "BlueBall" || collider.gameObject.tag == "GreenBall" || collider.gameObject.tag == "LightBlueBall" || collider.gameObject.tag == "OrangeBall" || collider.gameObject.tag == "PinkBall" || collider.gameObject.tag == "PurpleBall" || collider.gameObject.tag == "RedBall" || collider.gameObject.tag == "YellowBall")
            {
                //collisionListに接触しているオブジェクトが無ければ
                if (!collisionList.Contains(collider.gameObject))
                {
                    //collisionListに接触しているオブジェクトを追加
                    collisionList.Add(collider.gameObject);
                }
                //collisionRyListに接触しているオブジェクトのRigidbodyが無ければ
                if (!collisionRyList.Contains(collider.GetComponent<Rigidbody2D>()))
                {
                    //collisionRyListに接触しているオブジェクトのRigidbodyを追加
                    collisionRyList.Add(collider.GetComponent<Rigidbody2D>());
                }
            }
        }

    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        //「explosionFlag」がfalseなら
        if (!explosionFlag)
        {
            //collisionList内に接触範囲内から外れたオブジェクトがあったら、collisionListからそのオブジェクトを削除
            for (int i = 0; i < collisionList.Count; i++)
            {
                if (collisionList[i] == collider.gameObject)
                {
                    collisionList.Remove(collisionList[i]);
                }
            }

            //collisionRyList内に接触範囲内から外れたオブジェクトのRigidbodyがあったら、collisionRyListからそのオブジェクトのRigidbodyを削除
            for (int i = 0; i < collisionRyList.Count; i++)
            {
                if (collisionRyList[i] == collider.GetComponent<Rigidbody2D>())
                {
                    collisionRyList.Remove(collisionRyList[i]);
                }
            }
        }
    }

    public void ExplosionForce()
    {
        //「explosionFlag」をtrueに変更
        explosionFlag = true;

        for (int i = 0; i < collisionList.Count; i++)
        {
            //ボールが吹き飛ぶ方向と力を決める
            Vector3 velocity = (collisionList[i].transform.position - transform.position).normalized * speed;

            //i番目のcollisionListがnullで無ければ
            if (collisionList[i] != null)
            {
                //i番目のcollisionRyListのRigidbodyに「velocity」の力を一瞬で加える
                collisionRyList[i].AddForce(velocity, ForceMode2D.Impulse);
            }

        }
    }
}
