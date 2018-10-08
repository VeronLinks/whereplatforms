using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endlessFollow : MonoBehaviour
{

    private Rigidbody myRB;
    public float moveSpeed;
    public Transform[] movespots;
    private int randomSpot;

    public PlayerController thePlayer;

    private float waitTime;
    public float startTime;

    // Use this for initialization
    void Start()
    {
        myRB = GetComponent<Rigidbody>();
        thePlayer = FindObjectOfType<PlayerController>();

        randomSpot = Random.Range(0, movespots.Length);
        waitTime = startTime;
    }
    private void FixedUpdate()
    {
            myRB.velocity = (transform.forward * moveSpeed);

    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(thePlayer.transform.position);
    }

}
