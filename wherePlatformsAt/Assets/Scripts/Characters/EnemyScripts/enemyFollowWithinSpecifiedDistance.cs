using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyFollowWithinSpecifiedDistance : MonoBehaviour {

    public PlayerController thePlayer;
    public float moveSpeed;

    private int randomSpot;
    private Animator anim;
    private Rigidbody myRB;

    // Use this for initialization
    void Start () {
        myRB = GetComponent<Rigidbody>();
        thePlayer = FindObjectOfType<PlayerController>();
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        float currDistance = Vector3.Distance(transform.position, thePlayer.transform.position);
        if (currDistance < 15.0f && currDistance > 3f)
        {
            myRB.velocity = (transform.forward * moveSpeed);
            anim.SetFloat("ZSpeed", moveSpeed);
        }
        else
        {
            myRB.velocity = Vector3.zero;
            anim.SetFloat("ZSpeed", 0);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
