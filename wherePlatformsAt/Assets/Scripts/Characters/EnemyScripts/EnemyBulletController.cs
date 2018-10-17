using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour {

    public float speed = 10f;
    public float seconds = 3.0f;

    private Transform player;
    private Vector3 target;
    private Vector3 direction;
    private Vector3 initialPosition;
    
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().center.transform;
        target = new Vector3(player.position.x, player.position.y, player.position.z);
        Destroy(gameObject, seconds);
        initialPosition = transform.position;
    }
	
	void Update () {
        transform.position += (target - initialPosition).normalized * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        //if(other.CompareTag("Player") || other.CompareTag("Platform") || other.CompareTag("movingPlatform"))
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Platform" || other.gameObject.tag == "movingPlatform")
        {
            Destroy(this.gameObject);
        }

    }

}
