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
            switch (Level_Selector)
            {
                case 1:
                    SceneManager.LoadScene("Level_1");
                    break;
                case 2:
                    SceneManager.LoadScene("Level_2");
                    break;
                case 3:
                    SceneManager.LoadScene("Level_3");
                    break;
                default:
                    SceneManager.LoadScene("Debug");
                    break;
            }

        }

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
