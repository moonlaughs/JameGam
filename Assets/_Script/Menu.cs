using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }
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
