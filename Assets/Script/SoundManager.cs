using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public AudioSource[] bgm;
    public AudioSource[] se;

    //�V���O���g����
    void Awake()
    {
        //instance�ɉ��������ĂȂ���΁ASoundManager������B���łɓ����Ă���ꍇ�͐V�����쐬����instance���폜
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        //SoundManager���V�[���ׂ��Ŕj�󂵂Ȃ�
        DontDestroyOnLoad(gameObject);
    }

    /// <summary>
    /// SE��炷[0]:�^�C�g����ʂŃ^�b�v[1]:�X�e�[�W�N���A[2]:�Q�[���I�[�o�[[3]:�s�����^�b�v[4]:���Z�b�g�{�^�����^�b�v[5]:���e�̔�����
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
