using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class contactDisappearing : MonoBehaviour {

    public float waitTime;
    float timer;

    public Renderer rend;
    Collider p_col;
    Material mat;

    // Use this for initialization
    void Start()
    {
        timer = waitTime + 1;

        rend = GetComponent<Renderer>();//get the platform renderer
        p_col = GetComponent<Collider>();//get the platform collider
        mat = GetComponent<Renderer>().material;

        Reset();
    }

    // Update is called once per frame
    void Update()
    {
        //Checking for range to change colour
        float third = waitTime / 3;
        float twoThirds = third * 2;

        if(timer <= twoThirds && timer > third)
        {
            //set colour to yellow
            mat.color = Color.yellow;
        }
        else if(timer <= third)
        {
            //set colour to red
            mat.color = Color.red;
        }

        //decrease timer
        if(timer < waitTime +1)
        {
            Debug.Log("Timer counting down");
            timer -= Time.deltaTime;
        }
        
        //disable platform when timer reaches 0
        if (timer <= 0)
        {
            rend.enabled = false;//enable or disable renderer
            p_col.enabled = false;//enable or disable collider
            timer = waitTime + 1; //reset timer
          
        }

        Debug.Log(timer);

    }

    //start countdown timer upon player landing on platform 
    private void OnTriggerEnter(Collider col)
    {
        Debug.Log("On Platform");
        if (col.gameObject.tag == "Player")
        {
            timer--;
            Debug.Log("Timer started");
        }
            
    }

    //Reset timer, reset colour, and reactivate platform upon leaving 
    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            timer = waitTime + 1;
            Reset();
        }
    }


    private void Reset()
    {
        rend.enabled = true;
        p_col.enabled = true;
        mat.color = Color.green;
    }
}
