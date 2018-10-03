using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {

    private float speed1 = 1.0f;
    // Use this for initialization
    void Start () {}
	
	// Update is called once per frame
	void Update () {

        transform.Translate(transform.forward * speed1 * Time.deltaTime);
    }
}
