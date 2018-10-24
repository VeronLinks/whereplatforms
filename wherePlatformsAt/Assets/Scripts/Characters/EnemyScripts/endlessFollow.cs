using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *  Note from Javier: I haven't edited this code to work with the CharController because we already have EnemyFollowWithinSpecifiedDistance, 
 *  so this code is useless from my point of view.
 */

public class EndlessFollow : MonoBehaviour
{
    public PlayerController thePlayer;
    public float startTime;
    public float moveSpeed;
    public Transform[] movespots;
    public Transform playerCenter;

    private int randomSpot;
    private Rigidbody myRB;
    private float waitTime;
    private EnemyController controller;

    // Use this for initialization
    void Awake()
    {
        transform.LookAt(playerCenter.transform.position);
        transform.rotation = Quaternion.Euler(0.0f, transform.eulerAngles.y, 0.0f);

        controller = GetComponent<EnemyController>();
        myRB = GetComponent<Rigidbody>();
        thePlayer = FindObjectOfType<PlayerController>();

        randomSpot = Random.Range(0, movespots.Length);
        waitTime = startTime;
    }
    private void FixedUpdate()
    {
        if (controller.Alive)
        {
            myRB.velocity = (transform.forward * (moveSpeed * 250) * Time.fixedDeltaTime);
        }
        else
        {
            myRB.velocity = Vector3.zero;
        }
    }
}
