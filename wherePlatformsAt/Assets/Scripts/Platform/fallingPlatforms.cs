using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingPlatforms : MonoBehaviour {

    public Rigidbody platform;

	// Use this for initialization
	void Start () {
        platform.useGravity = false;
    }
	
	// Update is called once per frame
	void Update () {}

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            platform.useGravity = true;
        }
        if (col.gameObject.tag == "PlayerBullet")
        {
            Destroy(col.gameObject);
        }
    }
}
