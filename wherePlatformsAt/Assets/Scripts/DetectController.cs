using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectController : MonoBehaviour
{
    public PlayerController thePlayer;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		//detect mouse input
        if(Input.GetMouseButton(1) || Input.GetMouseButton(2))
        {
            thePlayer.useController = false;
        }

        if (Input.GetKey(KeyCode.Joystick1Button5) || Input.GetKey(KeyCode.Joystick1Button0))
        {
            thePlayer.useController = true;
        }

    }
}
