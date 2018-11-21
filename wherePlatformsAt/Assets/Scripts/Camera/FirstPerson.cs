using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: Javier Verón
 * 
 * This camera works for first person.
 */

public class FirstPerson : MonoBehaviour
{
    public float sensitivity = 1.0f;
    public float smoothing = 2.0f;

    Vector2 mouseLook;
    Vector2 smoothV;
    GameObject character;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        character = this.transform.parent.gameObject;
    }

    void Update()
    {
        //mouse delta
        if (Cursor.lockState == CursorLockMode.Locked)
        {

            if (mouseLook.y >= -90.0f && mouseLook.y <= 90.0f)
            {
                var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
                md = Vector2.Scale(md, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
                smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1f / smoothing);
                smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1f / smoothing);
                mouseLook += smoothV;
                transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
                character.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, character.transform.up);

            }
            else
            {
                mouseLook.y = 90.0f * Mathf.Sign(mouseLook.y);
            }
        }
    }
    public void SetMouseLookX(float newLookX)
    {
        mouseLook.x = newLookX;
    }
}

