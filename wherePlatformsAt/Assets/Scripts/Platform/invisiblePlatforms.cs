using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class invisiblePlatforms : MonoBehaviour {

    public MeshRenderer rend;

    // Use this for initialization
    void Start () {
        rend = GetComponent<MeshRenderer>();
        rend.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {}

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            rend.enabled = true;
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            rend.enabled = false;
        }
    }

}
