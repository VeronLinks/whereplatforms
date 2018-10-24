﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Authors: Cian Lennon & Javier Verón
 * 
 * Makes the enemy follow the player within the specified distance which will be calculated for X and Z axis. 
 * The movement inputs are set for CharController.
 */

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
            Vector3 player = thePlayer.gameObject.transform.position;
            Vector3 position = transform.position;
            transform.LookAt(player);
            transform.rotation = Quaternion.Euler(0.0f, transform.eulerAngles.y, 0.0f);
            player.y = 0.0f;
            position.y = 0.0f;
            float currDistance = Vector3.Distance(position, player);
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
