using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{
    [SerializeField]
    private GameObject spark;
    [SerializeField]
    private GameObject redBomb;
    private bool explosionJudgement = false;
    private bool isGameOver = false;
    private float fadeTime = 1.0f;
    private float currentRemainTime;
    private float alpha;
    private Color color;
    private SpriteRenderer render;
    private Vector2 bombVector2;
    [SerializeField]
    private ExplosionEnd explosionEnd;
    public ExplosionProcess explosionProcess;
    public StageManager stageManager;

    private void Start()
    {
        //「currentRemainTime」に「fadeTime」を代入
        currentRemainTime = fadeTime;
        //SpriteRendererのコンポーネントを取得
        render = GetComponent<SpriteRenderer>();
        //このオブジェクトの子オブジェクトである「ExplosionEffect」オブジェクトの「ExplosionEnd」スクリプトを取得
        explosionEnd = transform.Find("ExplosionEffect").gameObject.GetComponent<ExplosionEnd>();
        //このオブジェクトのローカルスケールを取得
        bombVector2 = this.transform.localScale;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        //「explosionJudgement」がfalseなら
        if (!explosionJudgement)
        {
            //接触したオブジェクトがボールか爆弾なら
            if (collision.gameObject.tag == "BlueBall" || collision.gameObject.tag == "GreenBall" || collision.gameObject.tag == "LightBlueBall" || collision.gameObject.tag == "OrangeBall" || collision.gameObject.tag == "PinkBall" || collision.gameObject.tag == "PurpleBall" || collision.gameObject.tag == "RedBall" || collision.gameObject.tag == "YellowBall" || collision.gameObject.tag == "Bomb")
            {
                //ExplosionStart関数を呼び出して、「explosionJudgement」をtrueにする
                ExplosionStart();
                explosionJudgement = true;
            }
        }
    }

    public void ExplosionStart()
    {
        //導火線の火花のオブジェクトをアクティブにする
        spark.SetActive(true);
        //StateChangeコルーチンを呼び出す
        StartCoroutine(StateChange());
    }

    private IEnumerator StateChange()
    {
        //爆弾の元のテクスチャを徐々に透明にし、爆弾の大きさを徐々に大きくする
        for (float i = 0; i < fadeTime; i += 0.1f)
        {
            currentRemainTime -= 0.1f;

            alpha = currentRemainTime / fadeTime;
            color = render.color;
            color.a = alpha;
            render.color = color;

            this.transform.localScale = new Vector2(bombVector2.x + i / 10, bombVector2.y + i / 10);

            yield return new WaitForSeconds(0.1f);

        }

        //「currentRemainTime」が0以下になったら爆発エフェクトとSEを表示し、0.1秒後に爆弾の火花と赤くなった爆弾のオブジェクトを非アクティブにし、ExplosionForceを呼び出す
        if (currentRemainTime <= 0f)
        {
            explosionEnd.particle.Play();
            SoundManager.instance.PlaySE(5);

            yield return new WaitForSeconds(0.1f);

            spark.SetActive(false);
            redBomb.SetActive(false);

            explosionProcess.ExplosionForce();
        }
    }

    public IEnumerator GameOverJudgement()
    {
        //「explosionProcess.collisionList」がnullでなかったら「isGameOver」をtrueにする
        for (int i = 0; i < explosionProcess.collisionList.Count; i++)
        {
            if (explosionProcess.collisionList != null)
            {
                isGameOver = true;
            }
        }

        yield return new WaitForSeconds(0.5f);

        //「isGameOver」がtureかつ「stageManager.clearFlag」がfalseだったら
        if (isGameOver && !stageManager.clearFlag)
        {
            //爆弾自体を非アクティブにしてGameOver関数を呼び出す
            this.gameObject.SetActive(false);
            stageManager.GameOver();
        }
        else
        {
            //そうでなければ爆弾を破壊する
            Destroy(this.gameObject);
        }
    }

}
