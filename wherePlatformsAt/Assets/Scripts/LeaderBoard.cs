using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderBoard : MonoBehaviour {
    public Text[] Highscore;
    float [] highscoreTime;
    string[] highScoreNames;
    // Use this for initialization
    void Start () {
        highscoreTime = new float[Highscore.Length];
        highScoreNames = new string[Highscore.Length];
        for (int x =0; x < Highscore.Length; x++)
        {
            highscoreTime[x] = PlayerPrefs.GetFloat("Timer" + x);
            highScoreNames[x] = PlayerPrefs.GetString("highsScoreNames" + x);
        }
        DrawTime();
	}
    void SaveTime()
    {
        for (int x = 0; x < Highscore.Length; x++)
        {
            PlayerPrefs.SetFloat("Timer" + x, highscoreTime[x]);
            PlayerPrefs.SetString("highScoreNames" + x, highScoreNames[x]);


        }
    }
    public void checkForTime(float value, string username)
    {
        for (int x = 0; x < Highscore.Length; x++)
        {
            if( value > highscoreTime [x])
            {
                for(int y = Highscore.Length -1; y > x; y--)
                {
                    highscoreTime[y] = highscoreTime[y - 1];
                    highScoreNames[y] = highScoreNames[y - 1];
                }
                highscoreTime[x] = value;
                highScoreNames[x] = username;
                DrawTime();
                SaveTime();
            }
        }
    }
    void DrawTime()
    {
        for (int x = 0; x < Highscore.Length; x++)
        {
            Highscore[x].text = highScoreNames[x]+" "+ highscoreTime[x].ToString();
        }
    }
    // Update is called once per frame
    void Update () {
       
       

    }
}
