using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Next_Level : MonoBehaviour
{
    [SerializeField] private GameObject Portal_Mark;
    private bool isPlayerInRange;

    public int Level_Selector;
    void Update()
    {

        if (isPlayerInRange && Input.GetButtonDown("Fire1"))
        {
            Debug_Level();
        }

    }


    void Debug_Level()
    {
        SceneManager.LoadScene("Debug");
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isPlayerInRange = true;
            Portal_Mark.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isPlayerInRange = false;
            Portal_Mark.SetActive(false);
        }
    }
}
