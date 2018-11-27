using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderBoard : MonoBehaviour {
    public Text[] Highscore;
    float [] highscoreTime;
	// Use this for initialization
	void Start () {
        highscoreTime = new float[Highscore.Length];
        for (int x =0; x < Highscore.Length; x++)
        {
            highscoreTime[x] = PlayerPrefs.GetFloat("Timer" + x);
        }
        DrawTime();
	}

    internal void checkForTime(object timer)
    {
        throw new NotImplementedException();
    }

    void SaveTime()
    {
        for (int x = 0; x < Highscore.Length; x++)
        {
            PlayerPrefs.SetFloat("Timer" + x, highscoreTime[x]);
        }
    }
    public void checkForTime(float value)
    {
        for (int x = 0; x < Highscore.Length; x++)
        {
            if( value > highscoreTime [x])
            {
                for(int y = Highscore.Length -1; y > x; y--)
                {
                    highscoreTime[y] = highscoreTime[y - 1];

                }
                highscoreTime[x] = value;
                DrawTime();
                SaveTime();
            }
        }
    }
    void DrawTime()
    {
        for (int x = 0; x < Highscore.Length; x++)
        {
            Highscore[x].text = highscoreTime[x].ToString();
        }
    }
    // Update is called once per frame
    void Update () {
       
       

    }
}
