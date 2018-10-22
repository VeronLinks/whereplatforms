using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public GameObject splatter;
    public float seconds;
    public float speed = 14.0f;

    private Transform target;
    private Vector3 direction;

    // Use this for initialization
    void Start () {
        //target = GameObject.FindGameObjectWithTag("Target").transform;
        //direction = new Vector3(target.position.x, target.position.y, target.position.z);
        direction = GameObject.FindGameObjectWithTag("Player").transform.forward;
        Destroy(gameObject, seconds);
    }
	
	// Update is called once per frame
	void Update ()
    {
        transform.position += direction * speed * Time.deltaTime; //Vector3.MoveTowards(transform.position, direction, speed1 * Time.deltaTime);
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
        else if (col.gameObject.tag == "Lava")
        {
            Destroy(this.gameObject);
        }
        else if (col.gameObject.tag == "Enemy")
        {
            col.gameObject.GetComponent<EnemyController>().Death();
            Destroy(this.gameObject);
        }
    }
}
