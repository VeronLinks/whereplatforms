using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Lose : MonoBehaviour
{
    public Text timerText;
    public TimeLimit endTime;
    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
   
    public void Restart()
    {
        Application.LoadLevel(2);
    }
  
}



