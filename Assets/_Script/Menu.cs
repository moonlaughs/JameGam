using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void LoadScene()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitScene()
    {
        Application.Quit();
    }

    public void MainMenuScene()
    {
        SceneManager.LoadScene(0);
    }
}
