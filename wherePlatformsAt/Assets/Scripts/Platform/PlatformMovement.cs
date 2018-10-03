using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour {

    public float speed = 1.0f;
    public GameObject[] waypoints;
    public int waypointIndex = 0;

    // Use this for initialization
    void Start () {}
	
	// Update is called once per frame
	void Update () {

        float speedDelta = speed * Time.deltaTime;

        Vector3 platformPosition = transform.position;
        Vector3 target = waypoints[waypointIndex].transform.position;
        Vector3 rangeToClose = target - platformPosition;

        float distance = Mathf.Sqrt(rangeToClose.x * rangeToClose.x + rangeToClose.y * rangeToClose.y + rangeToClose.z* rangeToClose.z);

        float newx = rangeToClose.x / distance;
        float newy = rangeToClose.y / distance;
        float newz = rangeToClose.z / distance;

        Vector3 norm = new Vector3(newx, newy,newz);

        if (distance > speedDelta)
        {
            transform.Translate(norm * speedDelta);
        }
        else
        {
            waypointIndex++;
        }

        if (waypointIndex >= waypoints.Length)
        {
            waypointIndex = 0;
        }
    }
}
