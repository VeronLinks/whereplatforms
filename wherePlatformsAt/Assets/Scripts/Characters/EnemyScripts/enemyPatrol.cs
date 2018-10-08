using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyPatrol : MonoBehaviour {

    private Rigidbody myRB;
    public float moveSpeed;
    public Transform[] movespots;
    private int randomSpot;

    public PlayerController thePlayer;

    private float waitTime;
    public float startTime;

    // Use this for initialization
    void Start () {
        myRB = GetComponent<Rigidbody>();
        thePlayer = FindObjectOfType<PlayerController>();

        randomSpot = Random.Range(0, movespots.Length);
        waitTime = startTime;
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.MoveTowards(transform.position, movespots[randomSpot].position, moveSpeed * Time.deltaTime);
        if (Vector3.Distance(transform.position, movespots[randomSpot].position) < 0.2f)
        {
            if (waitTime <= 0)
            {
                randomSpot = Random.Range(0, movespots.Length);
                waitTime = startTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }
}
