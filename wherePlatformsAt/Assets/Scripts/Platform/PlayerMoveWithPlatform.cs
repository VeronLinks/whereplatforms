using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveWithPlatform : MonoBehaviour
{
    public CharacterController charPlayer;
    public PlatformMovement pM;
    
    //void OnCollisionEnter(Collision other)
    //{
    //    charPlayer.Move(pM.direction.normalized * pM.speed * Time.deltaTime);
    //}


    void OnCollisionEnter(Collision other)
    {
        //charPlayer.Move(pM.direction.normalized * pM.speed * Time.deltaTime);
        if (other.gameObject.tag == "Player")
        {
            other.transform.parent = gameObject.transform;
        }
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.transform.parent = null;
        }
    }
}
