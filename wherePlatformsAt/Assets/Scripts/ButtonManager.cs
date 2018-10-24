using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void startButton()
    {
        SceneManager.LoadScene(1);
    }

    public void quitButton()
    {
        Application.Quit();
    }

    public void controllsScreen()
    {
        SceneManager.LoadScene(2);
    }

   public void MainMenuButton()
    {
        SceneManager.LoadScene(0);
    }
    public void Restart()
    {
        SceneManager.LoadScene(1);
    }
}
