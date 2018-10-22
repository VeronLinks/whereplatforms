using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if (eController.Alive)
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
