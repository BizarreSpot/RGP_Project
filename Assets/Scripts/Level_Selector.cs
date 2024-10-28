using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_Selector : MonoBehaviour
{
    public void Load_Levels(string Level)
    {
        StartCoroutine(Load_Level(Level));
    }
   public IEnumerator Load_Level(string Level)
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(Level);

    }

}
