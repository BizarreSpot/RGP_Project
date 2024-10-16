using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Coins_System : MonoBehaviour
{
    public TMP_Text Text_Points;
    private int Points;

    private void Start()
    {
        Points = 0; // Inicializa los puntos
        Update_Text();
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
