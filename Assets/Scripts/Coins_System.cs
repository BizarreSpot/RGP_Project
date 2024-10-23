using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Coins_System : MonoBehaviour
{
    public GameObject Next_Level;
    public TMP_Text Text_Points;
    private int Points;
    public int Max_Points;

    private void Start()
    {
        Points = 0; 
        Update_Text();
    }

    private void Update()
    {
        if (Points >= Max_Points)
        {
            Next_Level.gameObject.SetActive(true);
        }
    }

    public void Add_Points(int cantidad)
    {
        Points += cantidad;
        Update_Text();
    }

    private void Update_Text()
    {
        Text_Points.text = "Puntos: " + Points.ToString();
    }
}
