﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Author: Jack
 * Allows the player to move with the platform by 
 * giving it the same speed and direction as the moving platform
 */

public class AttachToPlatform : MonoBehaviour
{
    public GameObject Player;

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject == Player)
        {
            //The player has the same speed and direction as the platform
            other.transform.parent  = gameObject.transform;
        }

        if(other.gameObject.tag == "Enemy")
        {
            other.transform.parent = transform;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Player)
        {
            other.transform.parent = null;
        }

        if (other.gameObject.tag == "Enemy")
        {
            other.transform.parent = null;
        }
    }
}
