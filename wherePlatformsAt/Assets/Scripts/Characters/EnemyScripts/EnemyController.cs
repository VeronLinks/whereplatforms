using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    private Rigidbody myRB;
    public float moveSpeed;

    public PlayerController thePlayer;

    private float timeBtwShots;
    public float startTimeBtwShots;
    public GameObject bullet;
    public GameObject firePosition;

	// Use this for initialization
	void Start ()
    {
        myRB = GetComponent<Rigidbody>();
        thePlayer = FindObjectOfType<PlayerController>();

        timeBtwShots = startTimeBtwShots;
	}
	private void FixedUpdate()
    {
        myRB.velocity = (transform.forward * moveSpeed);
    }

	// Update is called once per frame
	void Update ()
    {
        transform.LookAt(thePlayer.transform.position);

        if(timeBtwShots <= 0)
        {
            Instantiate(bullet.transform, firePosition.transform.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
	}

}
