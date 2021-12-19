using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionEnd : MonoBehaviour
{
    public BombController bombController;
    public ParticleSystem particle;

    private void Start()
    {
        //ParticleSystem�̃R���|�[�l���g���擾
        particle = this.GetComponent<ParticleSystem>();
    }

    //�����G�t�F�N�g���I��������GameOverJudgement�֐����Ăяo��
    public void OnParticleSystemStopped()
    {
        StartCoroutine(bombController.GameOverJudgement());
    }


}
