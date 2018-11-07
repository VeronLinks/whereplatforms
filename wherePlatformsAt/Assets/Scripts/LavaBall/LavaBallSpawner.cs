using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaBallSpawner : MonoBehaviour {

    public GameObject ball;
    public GameObject waypoint1;
    public GameObject waypoint2;

    float timer = 0;
    public float timeBetweenSpawns;
    public Vector3 pos1;
    public Vector3 pos2;

    // Use this for initialization
    void Start () {
        pos1 = waypoint1.transform.position;
        pos2 = waypoint2.transform.position;
    }
	
	// Update is called once per frame
	void Update () {

        timer += Time.deltaTime;
        if (timer > timeBetweenSpawns)
        {
            spawner();
            timer = 0;
        }
    }

    void spawner()
    {
        GameObject ballClone = Instantiate(ball, new Vector3(Random.Range(pos1.x, pos1.x), 3, -Random.Range(pos2.x, pos2.y)), Quaternion.identity);
    }
}
