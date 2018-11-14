using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TimeLimit : MonoBehaviour
{


    private float endtime;
    public Text timerText;

   
    //playerScript.Health -= 10.0f;

    // Use this for initialization
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.GetFloat("Timer", endtime);
        
        timerText.text = " " + endtime;
    }
    


}
