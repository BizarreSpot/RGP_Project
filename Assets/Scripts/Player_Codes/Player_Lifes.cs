using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Lifes : MonoBehaviour
{
    public int health_Player;
    public Player_Controller Player;
    public Image[] Hearts;

    void Update()
    {

        if (health_Player == 0)
        {
            Player.Lock_Controls = true;
        }

        for (int i = 0; i < Hearts.Length; i++)
        {
            if (health_Player <= i)
            {
                Hearts[i].gameObject.SetActive(false);
            }
            else
            {
                Hearts[i].gameObject.SetActive(true);
            }

        }
    }


    public void Damage_Player()
    {
        health_Player -= 1;
    }

}
