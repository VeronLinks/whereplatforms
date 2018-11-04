using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disappearing : MonoBehaviour
{
    public float waitTime;
    float timer;
    int activeCheck = 1;

    public Renderer rend;
    Collider p_col;

    // Use this for initialization
    void Start ()
    {
        rend = GetComponent<Renderer>();//get the platform renderer
        p_col = GetComponent<Collider>();//get the platform collider

        rend.enabled = true;
    }
	
	// Update is called once per frame
	void Update ()
    {
        //check whether platform is active or inactive
        bool active = true;
        if(activeCheck % 2 == 0)
        {
            active = true;
        }
        else
        {
            active = false;
        }
      
   
        timer += Time.deltaTime;
        if (timer > waitTime)
        {
            rend.enabled = active;//enable or disable renderer
            p_col.enabled = active;//enable or disable collider
            timer = 0; //reset timer
            activeCheck++;
        }
        
    }
}
