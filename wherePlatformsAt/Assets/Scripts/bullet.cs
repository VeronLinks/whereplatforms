﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Author: Jack
 * makes the bullet move towards the target when it is instantiated.
 */

public class Bullet : MonoBehaviour {

    //public GameObject splatter;
    public float seconds;
    public float speed;

    private EnemyController theE;
    private Transform target;
    private Vector3 direction;

    // Use this for initialization
    void Start () {
        target = GameObject.FindGameObjectWithTag("Target").transform;
        direction = new Vector3(target.position.x, target.position.y, target.position.z);
        Destroy(gameObject, seconds);
    }
	
	// Update is called once per frame
	void Update ()
    {
        transform.Rotate(Vector3.right, 400f * Time.deltaTime, Space.World);
        transform.position = Vector3.MoveTowards(transform.position, direction, speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision col)
    {
        //ContactPoint contact = col.contacts[0];
        //Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
        //Vector3 pos = contact.point;
        //pos.y += 0.001f;
        //instantiates the splatter prefab and destroys the bullet when it collides with the platforms
        if (col.gameObject.tag == "Platform")
        {
            //Instantiate(splatter, pos, rot);
            Destroy(this.gameObject);
        }
        /*destroys the bullet when it collides with the lava
        */
        else if (col.gameObject.tag == "Lava")
        {
            Destroy(this.gameObject);
        }
        /*destroys the bullet when it collides with the enemy, kills the enemy.
        */
        else if (col.gameObject.tag == "Enemy")
        {
            col.gameObject.GetComponent<EnemyController>().Death();
            theE.alive = false;
            Destroy(this.gameObject);
        }
    }
}
