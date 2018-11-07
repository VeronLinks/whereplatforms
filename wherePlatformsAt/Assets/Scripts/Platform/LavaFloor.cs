using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaFloor : MonoBehaviour {

    public Transform player;
    public Transform respawn;
    PlayerController lives;

	void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Respawning");
            player.transform.position = respawn.position;
            
        }
        if (other.gameObject.name == "LavaBall(Clone)")
        {
            Destroy(other.gameObject);

        }
    }
}
