using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Author: Jack
 * this disables the mesh renderer making the platforms invisible.
 * has an array of platforms, makes 1 visible at a time.
 */

public class InvisiblePlatformPattern : MonoBehaviour {

    public GameObject[] platformArray;
    public int arrayIndex = 0;
    public float waitTime = 0;
    float timer;
    int activeCheck = 1;

    // Use this for initialization
    void Start () {

        for (int i = 0; i < platformArray.Length; i++)
        {
            platformArray[i].GetComponent<MeshRenderer>().enabled = false;
            platformArray[i].GetComponent<Collider>().enabled = false;
        }
    }
	
	// Update is called once per frame
	void Update () {

        for (int i = arrayIndex; i < platformArray.Length; i++)
        {
            bool active = true;
            if (activeCheck % 2 == 0)
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
                platformArray[i].GetComponent<MeshRenderer>().enabled = active;
                platformArray[i].GetComponent<Collider>().enabled = active;
                timer = 0; //reset timer
                activeCheck++;
            }
        }


        if (arrayIndex == platformArray.Length)
        {
            arrayIndex = 0;
        }
    }


}
