using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Follow : MonoBehaviour
{

    public Animator Enemy_Animator;
    public float speed;
    public float stoppingDistance;
    public float Follow_Limit;

    public bool Attack;

    private Transform target;
    public Vector2 Orientation;
    
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    void Update()
    {

        orientation_Enemy();
        idle_Enemy();



        if (Vector2.Distance(transform.position, target.position) > stoppingDistance && Vector2.Distance(transform.position, target.position) < Follow_Limit)
        {
            Enemy_Animator.SetFloat("Vertical_Run", Orientation.y);
            Enemy_Animator.SetFloat("Horizontal_Run", Orientation.x);

            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            
            if (Vector2.Distance(transform.position, target.position) <= stoppingDistance)
            {
                Attack = true;
            }
        
        }
        else
        {
            Enemy_Animator.SetFloat("Vertical_Run", 0);
            Enemy_Animator.SetFloat("Horizontal_Run", 0);
        }

    }

    void orientation_Enemy()
    {
        Orientation = transform.position - target.transform.position;

        if (Orientation.x >= 1)
        {
            Orientation.x = -1;
        }
        else if (Orientation.x <= -1)
        {
            Orientation.x = 1;
        }

        if (Orientation.y >= 1)
        {
            Orientation.y = -1;
        }
        else if (Orientation.y <= -1)
        {
            Orientation.y = 1;
        }

    }

    public void idle_Enemy()
    {
        switch (Orientation.y)
        {
            case 1:
                Enemy_Animator.SetFloat("Vertical_Idle", 1);
                Enemy_Animator.SetFloat("Horizontal_Idle", 0);
                break;
            case -1:
                Enemy_Animator.SetFloat("Vertical_Idle", -1);
                Enemy_Animator.SetFloat("Horizontal_Idle", 0);
                break;
            default: break;
        }

        switch (Orientation.x)
        {
            case 1:
                Enemy_Animator.SetFloat("Horizontal_Idle", 1);
                Enemy_Animator.SetFloat("Vertical_Idle", 0);
                break;
            case -1:
                Enemy_Animator.SetFloat("Horizontal_Idle", -1);
                Enemy_Animator.SetFloat("Vertical_Idle", 0);
                break;
            default: break;
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, Follow_Limit);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, stoppingDistance);
    }

}
