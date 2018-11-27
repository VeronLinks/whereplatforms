using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    float time;
    public InputField playerName;
   // time = PlayerPrefs.GetFloat("Timer", 0);
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void IntialsEntered()
    {
        GetComponent<LeaderBoard>().checkForTime(time, playerName.text);
    }
}
