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
        //�ucurrentRemainTime�v�ɁufadeTime�v����
        currentRemainTime = fadeTime;
        //SpriteRenderer�̃R���|�[�l���g���擾
        render = GetComponent<SpriteRenderer>();
        //���̃I�u�W�F�N�g�̎q�I�u�W�F�N�g�ł���uExplosionEffect�v�I�u�W�F�N�g�́uExplosionEnd�v�X�N���v�g���擾
        explosionEnd = transform.Find("ExplosionEffect").gameObject.GetComponent<ExplosionEnd>();
        //���̃I�u�W�F�N�g�̃��[�J���X�P�[�����擾
        bombVector2 = this.transform.localScale;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        //�uexplosionJudgement�v��false�Ȃ�
        if (!explosionJudgement)
        {
            //�ڐG�����I�u�W�F�N�g���{�[�������e�Ȃ�
            if (collision.gameObject.tag == "BlueBall" || collision.gameObject.tag == "GreenBall" || collision.gameObject.tag == "LightBlueBall" || collision.gameObject.tag == "OrangeBall" || collision.gameObject.tag == "PinkBall" || collision.gameObject.tag == "PurpleBall" || collision.gameObject.tag == "RedBall" || collision.gameObject.tag == "YellowBall" || collision.gameObject.tag == "Bomb")
            {
                //ExplosionStart�֐����Ăяo���āA�uexplosionJudgement�v��true�ɂ���
                ExplosionStart();
                explosionJudgement = true;
            }
        }
    }

    public void ExplosionStart()
    {
        //���ΐ��̉ΉԂ̃I�u�W�F�N�g���A�N�e�B�u�ɂ���
        spark.SetActive(true);
        //StateChange�R���[�`�����Ăяo��
        StartCoroutine(StateChange());
    }

    private IEnumerator StateChange()
    {
        //���e�̌��̃e�N�X�`�������X�ɓ����ɂ��A���e�̑傫�������X�ɑ傫������
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

        //�ucurrentRemainTime�v��0�ȉ��ɂȂ����甚���G�t�F�N�g��SE��\�����A0.1�b��ɔ��e�̉ΉԂƐԂ��Ȃ������e�̃I�u�W�F�N�g���A�N�e�B�u�ɂ��AExplosionForce���Ăяo��
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
        //�uexplosionProcess.collisionList�v��null�łȂ�������uisGameOver�v��true�ɂ���
        for (int i = 0; i < explosionProcess.collisionList.Count; i++)
        {
            if (explosionProcess.collisionList != null)
            {
                isGameOver = true;
            }
        }

        yield return new WaitForSeconds(0.5f);

        //�uisGameOver�v��ture���ustageManager.clearFlag�v��false��������
        if (isGameOver && !stageManager.clearFlag)
        {
            //���e���̂��A�N�e�B�u�ɂ���GameOver�֐����Ăяo��
            this.gameObject.SetActive(false);
            stageManager.GameOver();
        }
        else
        {
            //�����łȂ���Δ��e��j�󂷂�
            Destroy(this.gameObject);
        }
    }

}
