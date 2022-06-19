using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class Utilities : MonoBehaviour
{
   public static int playerDeaths = 0;

    public static string UpdateDeathCount(ref int countReference)
    {
        countReference += 1;
        return "Następnym razem liczba śmierci gracza będzie wynosiła " + countReference;
    }

   public static void RestartLevel()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1.0f;

        Debug.Log("Liczba śmierci gracza: " + playerDeaths);
        string message = UpdateDeathCount(ref playerDeaths);
        Debug.Log("Liczba śmierci gracza: " + playerDeaths);
    }

    public static bool RestartLevel(int sceneIndex)
    {
        if (sceneIndex < 0)
        {
            throw new System.ArgumentException("Indeks sceny nie moe być ujemny");
        }
        SceneManager.LoadScene(sceneIndex);
        Time.timeScale = 1.0f;

        return true;
    }
}
