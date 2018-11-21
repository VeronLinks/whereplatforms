using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    /* Author: Jack
     * opens the doos and deletes the key object when the player collides with it.
     */
    public GameObject Door;
    public AudioClip unlock;

    private AudioSource source;

    // Use this for initialization
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update() { }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            source.PlayOneShot(unlock);
            Door.GetComponent<MeshRenderer>().enabled = false;
            Door.GetComponent<Collider>().enabled = false;
            //Destroy(this.gameObject);
            Invoke("delayDestroy", 1.5f);
        }
    }

    void delayDestroy()
    {
        Destroy(this.gameObject);
    }
}
