using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {

    private Transform target;
    private float speed1 = 14.0f;
    private Vector3 direction;
    public GameObject splatter;
    public int seconds;

    // Use this for initialization
    void Start () {
        target = GameObject.FindGameObjectWithTag("Target").transform;
        direction = new Vector3(target.position.x, target.position.y, target.position.z);
        Destroy(gameObject, seconds);
    }
	
	// Update is called once per frame
	void Update () {

        transform.position = Vector3.MoveTowards(transform.position, direction, speed1 * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision col)
    {
        Vector3 pos = transform.position;
        pos.y += 0.1f;
        if (col.gameObject.tag == "Platform")
        {
            Instantiate(splatter, pos, transform.rotation);
            Destroy(this.gameObject);
        }
        if (col.gameObject.tag == "Lava")
        {
            Destroy(this.gameObject);
        }
    }
}
