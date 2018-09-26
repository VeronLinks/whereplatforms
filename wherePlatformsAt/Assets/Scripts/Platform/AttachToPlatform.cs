using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachToPlatform : MonoBehaviour
{
    public CharacterController charPlayer;
    public PlatformMovement pM;
    public GameObject Player;
    
    //void OnCollisionEnter(Collision other)
    //{
    //    charPlayer.Move(pM.direction.normalized * pM.speed * Time.deltaTime);
    //}


    void OnTriggerEnter(Collider other)
    {
        //charPlayer.Move(pM.direction.normalized * pM.speed * Time.deltaTime);
        if (other.gameObject == Player)
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
    }
}
