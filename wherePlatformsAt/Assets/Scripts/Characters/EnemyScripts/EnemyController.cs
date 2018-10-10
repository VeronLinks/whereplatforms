using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public float startTimeBtwShots;
    public GameObject bullet;
    public GameObject firePosition;
    public Transform thePlayer;
    
    private float timeBtwShots;

    // Use this for initialization
    void Start ()
    {

        timeBtwShots = startTimeBtwShots;
	}
	// Update is called once per frame
	void Update ()
    {
        transform.LookAt(thePlayer.transform.position);
        transform.rotation = Quaternion.Euler(0.0f, transform.eulerAngles.y, 0.0f);

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
