using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Author: Jack
 * this disables the mesh renderer making the platforms invisible.
 * it enables the renderer when the player touches the platforms making them visible while the player is standing on it.
 */

public class invisiblePlatforms : MonoBehaviour {

    public MeshRenderer rend;

    // Use this for initialization
    void Start () {
        rend = GetComponent<MeshRenderer>();
        rend.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {}

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("Player on platform");
            rend.enabled = true;
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("Player left platform");
            rend.enabled = false;
        }
    }

}
