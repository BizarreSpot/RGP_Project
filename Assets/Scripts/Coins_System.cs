using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Coins_System : MonoBehaviour
{
    public GameObject Next_Level;

    public GameObject Panel_Knifes, Panel_PEDs, Panel_Enemys;
    public TMP_Text Text_Points_Knifes, Text_Points_PEDs, Text_Points_Enemys;
    private int Points_Knifes, Points_PEDs, Points_Enemys;
    public int Max_Points_Knifes, Max_Points_PEDs, Max_Points_Enemys;

    public bool Knifes, PEDs, Enemys;

    private void Start()
    {
        Points_Knifes = 0;
        Points_PEDs = 0;
        Points_Enemys = 0;
        Update_Text();
    }

    private void Update()
    {
        Panel_Knifes.gameObject.SetActive(Knifes);
        Panel_PEDs.gameObject.SetActive(PEDs);
        Panel_Enemys.gameObject.SetActive(Enemys);


        if (Points_Knifes >= Max_Points_Knifes && Points_PEDs >= Max_Points_PEDs && Points_Enemys >= Max_Points_Enemys)
        {
            Next_Level.gameObject.SetActive(true);
        }
    }

    public void Add_Points(int Point_Status, int cantidad)
    {
  

        switch (Point_Status)
        {
            case 1:
                Points_Knifes += cantidad; ;
                break;
            case 2:
                Points_PEDs += cantidad;
                break;
            case 3:
                Points_Enemys += cantidad; ;
                break;
        }
        Update_Text();
    }

    private void Update_Text()
    {
        Text_Points_Knifes.text = Max_Points_Knifes + "/" + Points_Knifes.ToString();
        Text_Points_PEDs.text = Max_Points_PEDs+ "/" + Points_PEDs.ToString();
        Text_Points_Enemys.text = Max_Points_Enemys + "/" + Points_Enemys.ToString();
    }
}
