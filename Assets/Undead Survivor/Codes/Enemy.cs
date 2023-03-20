using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed; // �ӵ� ����
    public Rigidbody2D target; // ��ǥ ����

    bool isLive = true;// �������� ����

    Rigidbody2D rigid;
    SpriteRenderer spriter;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
    }
    
    private void FixedUpdate() // �������� �̵��̹Ƿ�
    {
        if (!isLive) // isLive�� False���
            return; // �ٷ� return, �� �ƹ��͵� ���Ѵ�.

        Vector2 dirVec = target.position - rigid.position; //player�� rigid body.position - enenmy.position 
        Vector2 nextVec = dirVec.normalized * speed * Time.fixedDeltaTime;

        // ���� * ��ġ
        rigid.MovePosition(rigid.position + nextVec); // �����̵�ó�� ��ġ�� �̵���
        rigid.velocity = Vector2.zero; // ���� �ӵ��� �̵��� ������ ���� �ʵ��� ��ġ���ش�.

    }

    private void LateUpdate()
    {
        if (!isLive) // isLive�� False���
            return; // �ٷ� return, �� �ƹ��͵� ���Ѵ�.

        spriter.flipX = target.position.x < rigid.position.x;
    }
}
