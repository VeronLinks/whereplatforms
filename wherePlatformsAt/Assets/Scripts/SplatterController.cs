using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplatterController : MonoBehaviour {

    public int seconds;

	// Use this for initialization
	void Start () {
        Destroy(gameObject, seconds);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
