using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class contactDisappearing : MonoBehaviour {

    public float waitTime;
    float timer;

    public Renderer rend;
    Collider p_col;

    // Use this for initialization
    void Start()
    {
        timer = waitTime + 1;

        rend = GetComponent<Renderer>();//get the platform renderer
        p_col = GetComponent<Collider>();//get the platform collider

        rend.enabled = true;
        p_col.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {

        //decrease timer
        if(timer <= waitTime)
        {
            Debug.Log("Timer counting down");
            timer -= Time.deltaTime;
        }
        
        //disable platform when timer reaches 0
        if (timer == 0)
        {
            rend.enabled = false;//enable or disable renderer
            p_col.enabled = false;//enable or disable collider
            timer = waitTime + 1; //reset timer
          
        }

    }

    //start countdown timer upon player landing on platform 
    private void OnCollisionEnter(Collision col)
    {
        Debug.Log("On Platform");
        if (col.gameObject.tag == "Player")
        {
            timer--;
            Debug.Log("Timer started");
        }
            
    }

    //Reset timer and reactivate platform upon leaving 
    private void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            timer = waitTime + 1;
        }

        rend.enabled = true;
        p_col.enabled = true;
    }
}
