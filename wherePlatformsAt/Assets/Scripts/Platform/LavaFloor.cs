using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaFloor : MonoBehaviour {

    public Transform player;
    public Transform respawn;
    PlayerController lives;
    public AudioClip lavaBackground;
    public AudioClip lavaFall;

    private AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
        source.PlayOneShot(lavaBackground);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            source.PlayOneShot(lavaFall);
            Debug.Log("Respawning");
            player.transform.position = respawn.position;
            
        }
        if (other.gameObject.name == "LavaBall(Clone)")
        {
            Destroy(other.gameObject);

        }
        if (other.gameObject.tag == "falling")
        {
            Destroy(other.gameObject);

        }
    }
}
