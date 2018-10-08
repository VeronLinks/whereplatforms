using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyFollowWithinSpecifiedDistance : MonoBehaviour {

    private Rigidbody myRB;
    public float moveSpeed;
    public Transform[] movespots;
    private int randomSpot;

    public PlayerController thePlayer;

    // Use this for initialization
    void Start () {
        myRB = GetComponent<Rigidbody>();
        thePlayer = FindObjectOfType<PlayerController>();
    }

    private void FixedUpdate()
    {
        if (Vector3.Distance(transform.position, thePlayer.transform.position) < 15.0f)
        {
            myRB.velocity = (transform.forward * moveSpeed);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
