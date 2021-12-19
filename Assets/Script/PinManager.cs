using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PinManager : MonoBehaviour
{
    public static PinManager instance;


    //�s�����΂��X�s�[�h��ݒ�
    private float speed = 0.3f;
    private int frame = 100;

    //�V���O���g����
    void Awake()
    {
        //instance�ɉ��������ĂȂ���΁APinManager������B���łɓ����Ă���ꍇ�͐V�����쐬����instance���폜
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        //PinManager���V�[���ׂ��Ŕj�󂵂Ȃ�
        DontDestroyOnLoad(gameObject);
    }

    public void OnClickPin(PointerEventData eventData)
    {
        //�N���b�N�����I�u�W�F�N�g���擾
        GameObject clickedObject = eventData.pointerPress;

        //�N���b�N�����I�u�W�F�N�g��Pin�^�O�������Ă�����I�u�W�F�N�g���΂�
        if (clickedObject.tag == "Pin")
        {
            //�s�����΂����ʉ���炷
            SoundManager.instance.PlaySE(3);
            //��΂�����������
            Vector3 velocity = clickedObject.transform.rotation * new Vector3(speed, 0, 0);
            //�R���[�`���ŏ��X�Ƀs�����ړ�������
            StartCoroutine(movePin(clickedObject, velocity));
        }
    }

    private IEnumerator movePin(GameObject gameObject, Vector3 velocity)
    {
        //�ui�v���uframe�v�̒l�ɂȂ�܂Ńs�������X�ɓ�����
        for (int i = 0; i < frame; i++)
        {
            yield return null;

            gameObject.transform.position -= velocity * i / 30;
        }
        //�ړ����I������I�u�W�F�N�g��j��
        if(frame <= 0)
        {
            Destroy(gameObject);
        }
    }

}
