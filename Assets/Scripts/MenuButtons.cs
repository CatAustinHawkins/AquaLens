using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuButtons : MonoBehaviour
{

    public void Update()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }

    }

    public void MainMenuOpen()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void GameOpen()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void CloseGame()
    {
        Application.Quit();
    }

}
