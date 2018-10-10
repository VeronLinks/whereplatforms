using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{

    public void startButton()
    {
        Application.LoadLevel(1);
    }

    public void quitButton()
    {
        Application.Quit();
    }

    public void controllsScreen()
    {
        Application.LoadLevel(2);
    }

   public void MainMenuButton()
    {
        Application.LoadLevel(0);
    }
}
