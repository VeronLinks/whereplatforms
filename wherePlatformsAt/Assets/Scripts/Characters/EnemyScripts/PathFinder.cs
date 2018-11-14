using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PathFinder : MonoBehaviour {

    public float maxDist = 15.0f;
    public float minDist = 3.0f;

    public Transform player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        float currDistance = Vector3.Distance(this.transform.position, player.position);
        bool dist = currDistance < maxDist && currDistance > minDist;

        if (dist)
        {
            transform.GetComponent<NavMeshAgent>().destination = player.position;
        }
        
	}
}
