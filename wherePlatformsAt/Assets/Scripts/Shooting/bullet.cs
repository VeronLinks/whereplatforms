using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {

    private GameObject player;
    private Transform target;
    private float speed1 = 10.0f;
    Vector3 direction;
    private Vector3 target2;

    // Use this for initialization
    void Start () {
        target = GameObject.FindGameObjectWithTag("Target").transform;
        target2 = new Vector3(target.position.x, target.position.y, target.position.z);
    }
	
	// Update is called once per frame
	void Update () {

        transform.Translate(transform.forward * speed1 * Time.deltaTime);

        //transform.Translate(player.transform.forward * speed1);
        transform.position = Vector3.MoveTowards(transform.position, target2, speed1 * Time.deltaTime);
    }
}
