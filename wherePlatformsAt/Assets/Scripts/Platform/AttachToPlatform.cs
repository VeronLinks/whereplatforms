using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachToPlatform : MonoBehaviour
{
    public GameObject Player;
    public GameObject Enemy;

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject == Player)
        {
            //The player has the same speed and direction as the platform
            other.transform.parent  = gameObject.transform;
        }

        if(other.gameObject == Enemy)
        {
            other.transform.parent = gameObject.transform;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Player)
        {
            other.transform.parent = null;
        }

        if (other.gameObject == Enemy)
        {
            other.transform.parent = null;
        }
    }
}
