using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionEnd : MonoBehaviour
{
    public BombController bombController;
    public ParticleSystem particle;

    private void Start()
    {
        //ParticleSystemのコンポーネントを取得
        particle = this.GetComponent<ParticleSystem>();
    }

    //爆発エフェクトが終了したらGameOverJudgement関数を呼び出す
    public void OnParticleSystemStopped()
    {
        StartCoroutine(bombController.GameOverJudgement());
    }


}
