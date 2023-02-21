using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector2 inputVec;
    public float speed;

    Rigidbody2D rigid;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        inputVec.x = Input.GetAxisRaw("Horizontal");
        inputVec.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        // 1. Get Forces
        //rigid.AddForce(inputVec);

        // 2. Control Velocity
        //rigid.velocity = inputVec;


        Vector2 nextVec = inputVec.normalized * speed * Time.fixedDeltaTime;

        // 3. Move Position
        rigid.MovePosition(rigid.position + nextVec);
    }
}