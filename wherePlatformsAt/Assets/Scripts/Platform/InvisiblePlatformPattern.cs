using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Author: Jack
 * this disables the mesh renderer and collider for all platforms making the platforms invisible and the player falls through them.
 * has an array of platforms, makes 1 visible at a time.
 */

public class InvisiblePlatformPattern : MonoBehaviour {

    public GameObject[] platformArray;
    public int timeToSpawn;
    public int timeVisible;

    // Use this for initialization
    void Start () {

        for (int i = 0; i < platformArray.Length; i++) //makes all the platforms invisisible
        {
            platformArray[i].GetComponent<MeshRenderer>().enabled = false;
            platformArray[i].GetComponent<Collider>().enabled = false;
        }

        StartCoroutine(switchPlatform());
    }
	
	// Update is called once per frame
	void Update () {}

    IEnumerator Run(int index) //makes platform visible, waits then makes invisible
    {
        platformArray[index].GetComponent<MeshRenderer>().enabled = true;
        platformArray[index].GetComponent<Collider>().enabled = true;
        yield return new WaitForSecondsRealtime(timeVisible);
        platformArray[index].GetComponent<MeshRenderer>().enabled = false;
        platformArray[index].GetComponent<Collider>().enabled = false;
    }

    IEnumerator switchPlatform()
    {
        while (true)
        {
            for (int i = 0; i < platformArray.Length; i++) //goes through platform array.
            {
                StartCoroutine(Run(i)); //makes platform visible
                yield return new WaitForSecondsRealtime(timeToSpawn); 
                if (i == platformArray.Length)
                {
                    i = 0;
                }
            }
        }
    }


}
