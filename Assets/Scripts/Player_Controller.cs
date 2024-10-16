using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    public float speed;
    public Animator Player_Animator;

    private Rigidbody2D RigidB;
    private Vector2 moveVel;
    void Start()
    {
        RigidB = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        idle_Player();
        Player_Animator.SetFloat("Vertical_Run", Input.GetAxisRaw("Vertical"));
        Player_Animator.SetFloat("Horizontal_Run", Input.GetAxisRaw("Horizontal"));
        Vector2 MoveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVel = MoveInput.normalized * speed;

    }

    void FixedUpdate()
    {
        RigidB.MovePosition(RigidB.position + moveVel * Time.fixedDeltaTime);    
    }


    public void idle_Player()
    {
        switch (Input.GetAxisRaw("Vertical"))
        {
            case 1:
                Player_Animator.SetFloat("Vertical_Idle", 1);
                Player_Animator.SetFloat("Horizontal_Idle", 0);
                break;
            case -1:
                Player_Animator.SetFloat("Vertical_Idle", -1);
                Player_Animator.SetFloat("Horizontal_Idle", 0);
                break;
            default: break;
        }

        switch (Input.GetAxisRaw("Horizontal"))
        {
            case 1:
                Player_Animator.SetFloat("Horizontal_Idle", 1);
                Player_Animator.SetFloat("Vertical_Idle", 0);
                break;
            case -1:
                Player_Animator.SetFloat("Horizontal_Idle", -1);
                Player_Animator.SetFloat("Vertical_Idle", 0);
                break;
            default: break;
        }
    }
}


