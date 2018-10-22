using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowWithinSpecifiedDistance : MonoBehaviour {
    
    public float maxDist = 15.0f;
    public float minDist = 3.0f;

    private PlayerController thePlayer;
    private EnemyController eController;
    private CharController cController;

    // Use this for initialization
    void Awake ()
    {
        cController = GetComponent<CharController>();
        thePlayer = FindObjectOfType<PlayerController>();
        eController = GetComponent<EnemyController>();
    }

    private void Update()
    {
        if (eController.Alive)
        {
            Vector3 player = thePlayer.transform.position;
            transform.LookAt(player);
            transform.rotation = Quaternion.Euler(0.0f, transform.eulerAngles.y, 0.0f);

            float currDistance = Vector3.Distance(transform.position, player);
            if (currDistance < maxDist && currDistance > minDist)
            {
                cController.VerticalAxis = 1;
            }
            else
            {
                cController.VerticalAxis = 0;
            }
        }
    }
}
