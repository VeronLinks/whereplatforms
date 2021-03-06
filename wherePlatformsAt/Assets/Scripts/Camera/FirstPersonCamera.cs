﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: Javier Verón
 * 
 * This camera works for third person even if it was originally oriented to be for first person
 * It also needs the CameraController.
 */

public class FirstPersonCamera : MonoBehaviour {

    #region Public Attributes
    public float sensitivity = 5.0f;
    public float smoothing = 2.0f;
    public GameObject character;
    public GameObject characterReference;
    #endregion

    #region Private Attributes
    private Vector2 mouseLook;
    private Vector2 smoothV;
    #endregion

    #region Properties
    #endregion


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        /*var angH = Input.GetAxis("Rhorizontal") * 60;
        var angV = Input.GetAxis("Rverticle") * 45;
        transform.localEulerAngles = new Vector3(angV, angH, 0);
        */
        float dt = Time.deltaTime;
        //mouse delta
        if (Cursor.lockState == CursorLockMode.Locked)
        {

            /*if (mouseLook.y >= -90.0f && mouseLook.y <= 90.0f)
            {*/
            var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
            md = Vector2.Scale(md, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
            smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1f / smoothing);
            smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1f / smoothing);
            mouseLook += smoothV;
            //transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
            character.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, character.transform.up);

            if (mouseLook.y >= -30.0f && mouseLook.y <= 30.0f)
            {
                characterReference.transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, characterReference.transform.right);
            }
            else
            {
                mouseLook.y = 30.0f * Mathf.Sign(mouseLook.y);
            }

        }
    }

    #region Methods
    #endregion
}
