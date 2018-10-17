using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowWithinSpecifiedDistance : MonoBehaviour {

    public PlayerController thePlayer;
    public float moveSpeed;

    private int randomSpot;
    private Animator anim;
    private Rigidbody myRB;
    private EnemyController controller;
    private float finalSpeed;

    // Use this for initialization
    void Awake () {
        myRB = GetComponent<Rigidbody>();
        thePlayer = FindObjectOfType<PlayerController>();
        anim = GetComponent<Animator>();
        controller = GetComponent<EnemyController>();
    }

    private void FixedUpdate()
    {
        float currDistance = Vector3.Distance(transform.position, thePlayer.transform.position);
        if ((currDistance < 15.0f && currDistance > 3f) && controller.Alive)
        {
            finalSpeed = moveSpeed * Time.fixedDeltaTime;
            anim.SetFloat("ZSpeed", finalSpeed);
        }
        else
        {
            finalSpeed = 0;
            anim.SetFloat("ZSpeed", finalSpeed);
        }
        myRB.velocity = (transform.forward * finalSpeed);
    }
}
