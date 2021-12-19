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
        //�uexplosionFlag�v��false�Ȃ�
        if (!explosionFlag)
        {
            //�ڐG���Ă���̂��{�[����������
            if (collider.gameObject.tag == "BlueBall" || collider.gameObject.tag == "GreenBall" || collider.gameObject.tag == "LightBlueBall" || collider.gameObject.tag == "OrangeBall" || collider.gameObject.tag == "PinkBall" || collider.gameObject.tag == "PurpleBall" || collider.gameObject.tag == "RedBall" || collider.gameObject.tag == "YellowBall")
            {
                //collisionList�ɐڐG���Ă���I�u�W�F�N�g���������
                if (!collisionList.Contains(collider.gameObject))
                {
                    //collisionList�ɐڐG���Ă���I�u�W�F�N�g��ǉ�
                    collisionList.Add(collider.gameObject);
                }
                //collisionRyList�ɐڐG���Ă���I�u�W�F�N�g��Rigidbody���������
                if (!collisionRyList.Contains(collider.GetComponent<Rigidbody2D>()))
                {
                    //collisionRyList�ɐڐG���Ă���I�u�W�F�N�g��Rigidbody��ǉ�
                    collisionRyList.Add(collider.GetComponent<Rigidbody2D>());
                }
            }
        }

    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        //�uexplosionFlag�v��false�Ȃ�
        if (!explosionFlag)
        {
            //collisionList���ɐڐG�͈͓�����O�ꂽ�I�u�W�F�N�g����������AcollisionList���炻�̃I�u�W�F�N�g���폜
            for (int i = 0; i < collisionList.Count; i++)
            {
                if (collisionList[i] == collider.gameObject)
                {
                    collisionList.Remove(collisionList[i]);
                }
            }

            //collisionRyList���ɐڐG�͈͓�����O�ꂽ�I�u�W�F�N�g��Rigidbody����������AcollisionRyList���炻�̃I�u�W�F�N�g��Rigidbody���폜
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
        //�uexplosionFlag�v��true�ɕύX
        explosionFlag = true;

        for (int i = 0; i < collisionList.Count; i++)
        {
            //�{�[����������ԕ����Ɨ͂����߂�
            Vector3 velocity = (collisionList[i].transform.position - transform.position).normalized * speed;

            //i�Ԗڂ�collisionList��null�Ŗ������
            if (collisionList[i] != null)
            {
                //i�Ԗڂ�collisionRyList��Rigidbody�Ɂuvelocity�v�̗͂���u�ŉ�����
                collisionRyList[i].AddForce(velocity, ForceMode2D.Impulse);
            }

        }
    }
}
