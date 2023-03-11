using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public Vector2 inputVec;
    public float speed;

    Rigidbody2D rigid;
    SpriteRenderer spriter;
    Animator anim;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>(); // Rigidbody Collider
        spriter = GetComponent<SpriteRenderer>(); // Sprite 
        anim = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        // 1. Get Forces
        //rigid.AddForce(inputVec);

        // 2. Control Velocity
        //rigid.velocity = inputVec;


        Vector2 nextVec = inputVec * speed * Time.fixedDeltaTime;

        // 3. Move Position
        rigid.MovePosition(rigid.position + nextVec);
    }

    private void OnMove(InputValue value)
    {
        inputVec = value.Get<Vector2>();
    }

    private void LateUpdate()
    {
        anim.SetFloat("Speed", inputVec.magnitude);

        if (inputVec.x != 0) // 왼쪽과 오른쪽이 반대일 때
        {
            //spriter.flipX = true;
            spriter.flipX = inputVec.x < 0;
        }
    }

}