using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: Javier Verón
 * 
 * This changes between first person and third person pressing K.
 */

public class Swap1And3rd : MonoBehaviour {

    public float fieldOfViewFP = 70.0f;
    public GameObject shadowMeshOfPlayer;

    private CameraController cController;
    private FirstPerson firstP;
    private FirstPersonCamera thirdP;
    private bool thirdPerson;
    private Vector3 headPosition;
    private float fieldOfViewTP;
    private Camera cam;

    // Use this for initialization
    private void Awake()
    {
        cController = GetComponent<CameraController>();
        firstP = GetComponent<FirstPerson>();
        thirdP = GetComponent<FirstPersonCamera>();
        cam = GetComponent<Camera>();
    }

    private void Start()
    {
        fieldOfViewTP = cam.fieldOfView;
        headPosition = new Vector3(0f, 1.65f, -.1f);
        thirdPerson = true;
    }

    // Update is called once per frame
    void Update () {
		if (Input.GetKeyDown(KeyCode.K))
        {
            thirdPerson = !thirdPerson;
            if (thirdPerson)
            {
                this.gameObject.transform.parent = null;
                cam.fieldOfView = fieldOfViewTP;
            }
            else
            {
                this.gameObject.transform.parent = cController.target;
                transform.localPosition = headPosition;
                cam.fieldOfView = fieldOfViewFP;

            }
            cController.enabled = thirdPerson;
            thirdP.enabled = thirdPerson;
            firstP.enabled = !thirdPerson;
            shadowMeshOfPlayer.SetActive(thirdPerson);
        }
	}
}
