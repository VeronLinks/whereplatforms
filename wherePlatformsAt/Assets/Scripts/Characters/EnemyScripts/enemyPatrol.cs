using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Authors: Cian Lennon & Javier Verón
 * 
 * Makes the enemy go to the waypoints introduced in the editor (movespots). 
 * The movement inputs are set for CharController.
 */

public class EnemyPatrol : MonoBehaviour {
  
    public Transform[] movespots;
    public float minDist = 1.0f;
    
    private int randomSpot;
    private EnemyController eController;
    private CharController cController;
    
    // Use this for initialization
    void Awake ()
    {
        cController = GetComponent<CharController>();
        eController = GetComponent<EnemyController>();

        randomSpot = Random.Range(0, movespots.Length);
    }

    // Update is called once per frame
    void Update () {
        if (eController.Alive && movespots.Length > 0)
        {
            cController.VerticalAxis = 1.0f;
            transform.LookAt(movespots[randomSpot].position);
            transform.rotation = Quaternion.Euler(0.0f, transform.eulerAngles.y, 0.0f);
            if (Vector3.Distance(transform.position, movespots[randomSpot].position) < minDist)
            {
                randomSpot = Random.Range(0, movespots.Length);
            }
        }
    }
}
