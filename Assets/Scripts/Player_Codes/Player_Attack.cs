using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Attack : MonoBehaviour
{
    public Player_Controller Player;
    public float Attack_Range;
    public LayerMask Enemy_Layer;
    public Transform Attack_Point;


    // Update is called once per frame
    void Update()
    {
        if (!Player.Lock_Controls)
        {

            Attack_Point_Position();
            if (Input.GetButtonDown("Jump"))
            {
                Attack();
            }
            else
            {
                Player.Player_Animator.ResetTrigger("Attack");
            }
        }


    }

    void Attack()
    {

            Player.Player_Animator.SetTrigger("Attack");



        Collider2D[] hit_Enemies = Physics2D.OverlapCircleAll(Attack_Point.position, Attack_Range, Enemy_Layer);

    foreach (Collider2D enemy in hit_Enemies)
        {
            enemy.GetComponent<Enemy_Health>().Damage();
        }
    
    }


    void Attack_Point_Position()
    {
        Vector2 Ramon;

        switch (Input.GetAxisRaw("Vertical"))
        {
            case 1:
                Ramon = new Vector2(0, 1);
                Attack_Point.localPosition = Ramon;
                break;
            case -1:
                Ramon = new Vector2(0, -1);
                Attack_Point.localPosition = Ramon;
                break;
            default: break;
        }

        switch (Input.GetAxisRaw("Horizontal"))
        {
            case 1:
                Ramon = new Vector2(1, 0);
                Attack_Point.localPosition = Ramon;
                break;
            case -1:
                Ramon = new Vector2(-1, 0);
                Attack_Point.localPosition = Ramon;
                break;
            default: break;
        }


    }

    private void OnDrawGizmosSelected()
    {
        if (Attack_Point == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(Attack_Point.position, Attack_Range);
    }

}
