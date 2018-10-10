using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {

    private Transform target;
    private float speed1 = 14.0f;
    private Vector3 direction;

    // Use this for initialization
    void Start () {
        target = GameObject.FindGameObjectWithTag("Target").transform;
        direction = new Vector3(target.position.x, target.position.y, target.position.z);
    }
	
	// Update is called once per frame
	void Update () {

        transform.position = Vector3.MoveTowards(transform.position, direction, speed1 * Time.deltaTime);
    }
}
