using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyPatrol : MonoBehaviour {

    public float startTime;
    public PlayerController thePlayer;
    public float moveSpeed;
    public Transform[] movespots;

    private int randomSpot;
    private Rigidbody myRB;
    private float waitTime;
    private Animator anim;

    // Use this for initialization
    void Start () {
        myRB = GetComponent<Rigidbody>();
        thePlayer = FindObjectOfType<PlayerController>();
        anim = GetComponent<Animator>();

        randomSpot = Random.Range(0, movespots.Length);
        waitTime = startTime;
    }
	
	// Update is called once per frame
	void Update () {
        float finalSpeed = moveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, movespots[randomSpot].position, finalSpeed);
        anim.SetFloat("ZSpeed", finalSpeed);
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
