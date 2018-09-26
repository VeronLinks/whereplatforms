using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaFloor : MonoBehaviour {

    public Transform player;
    public Transform respawn;

	void OnTriggerEnter(Collider other)
    {
        player.transform.position = respawn.position;
    }
}
