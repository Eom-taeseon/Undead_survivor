using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed; // 속도 변수
    public Rigidbody2D target; // 목표 변수

    bool isLive = true;// 생존여부 변수

    Rigidbody2D rigid;
    SpriteRenderer spriter;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
    }
    
    private void FixedUpdate() // 물리적인 이동이므로
    {
        if (!isLive) // isLive가 False라면
            return; // 바로 return, 즉 아무것도 안한다.

        Vector2 dirVec = target.position - rigid.position; //player의 rigid body.position - enenmy.position 
        Vector2 nextVec = dirVec.normalized * speed * Time.fixedDeltaTime;

        // 방향 * 위치
        rigid.MovePosition(rigid.position + nextVec); // 순간이동처럼 위치만 이동함
        rigid.velocity = Vector2.zero; // 물리 속도가 이동에 영향을 주지 않도록 조치해준다.

    }

    private void LateUpdate()
    {
        if (!isLive) // isLive가 False라면
            return; // 바로 return, 즉 아무것도 안한다.

        spriter.flipX = target.position.x < rigid.position.x;
    }
}
