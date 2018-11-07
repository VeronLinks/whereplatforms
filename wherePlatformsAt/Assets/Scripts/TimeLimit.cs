using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;


public class TimeLimit : MonoBehaviour
{


    Lives life;
    private int time = 0;
    private bool gameOver = false;
    //public Text timerText;
    private int endTime;
    private bool timeGo = true;
    // Use this for initialization
    void Start()
    {
        InvokeRepeating("Count", 0.0f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        /* if (life.lives < 0)
         {
             timeGo = false;
             endTime = time;

         }
         timerText.text = " " + endTime;*/
    }
    void Count()
    {
        time++;
    }
    private void OnGUI()
    {

        GUI.Box(new Rect(200, 10, 100, 30), "timer: " + time);
    }

}
