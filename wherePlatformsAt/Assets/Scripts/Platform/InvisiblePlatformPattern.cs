﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Author: Jack
 * this disables the mesh renderer and collider for all platforms making the platforms invisible and the player falls through them.
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

        for (int i = 0; i < platformArray.Length; i++) //makes all the platforms invisisible
        {
            platformArray[i].GetComponent<MeshRenderer>().enabled = false;
            platformArray[i].GetComponent<Collider>().enabled = false;
        }

        StartCoroutine(Run());
    }
	
	// Update is called once per frame
	void Update () {}

    IEnumerator Run()
    {
        while(true)
        {
            for (int i = arrayIndex; i < platformArray.Length; i++)
            {
                yield return new WaitForSecondsRealtime(5);
                platformArray[i].GetComponent<MeshRenderer>().enabled = true;
                platformArray[i].GetComponent<Collider>().enabled = true;
                yield return new WaitForSecondsRealtime(5);
                platformArray[i].GetComponent<MeshRenderer>().enabled = false;
                platformArray[i].GetComponent<Collider>().enabled = false;
            }
            if (arrayIndex == platformArray.Length)
            {
                arrayIndex = 0;
            }
        } 
    }


}
