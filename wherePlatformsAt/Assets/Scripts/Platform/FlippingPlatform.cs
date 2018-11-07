using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: Javier Verón
 * 
 * This controlls the platform making it rotate the number of degrees asked in differenceAngle. 
 * The platform will rotate that much in the axis set in axis during the time set in rotDuration. 
 * It can rotate the times set in platformNumberOfFaces.
 */

public class FlippingPlatform : MonoBehaviour {

    public int platformNumberOfFaces = 2;
    public float rotDuration = 5.0f;   //duration of the rotation
    public float secondsBetweenRotations = 2.0f;
    public float differenceAngle = 180.0f;
    public char axis = 'X';

    private float rotTime = 0.0f;   //time rotating
    private Quaternion[] rotations;

    private State state = State.Idle;

    enum State
    {
        Idle,
        Rotating
    }

    private int currentRot = 0;
    private bool trigger = false;

    // Use this for initialization
    void Start()
    {
        rotations = new Quaternion[platformNumberOfFaces];
        rotations[0] = transform.rotation;

        switch (axis)
        {
            case 'X':
                for (int i = 1; i < platformNumberOfFaces; ++i)
                {
                    rotations[i] = rotations[i - 1] * Quaternion.Euler(differenceAngle, 0.0f, 0.0f);
                }
                break;
            case 'Y':
                for (int i = 1; i < platformNumberOfFaces; ++i)
                {
                    rotations[i] = rotations[i - 1] * Quaternion.Euler(0.0f, differenceAngle, 0.0f);
                }
                break;
            default:
                for (int i = 1; i < platformNumberOfFaces; ++i)
                {
                    rotations[i] = rotations[i - 1] * Quaternion.Euler(0.0f, 0.0f, differenceAngle);
                }
                break;
        }

        if (rotDuration >= 0)
        {
            trigger = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (trigger) //Trigger
        {
            Invoke("ActivateRotation", secondsBetweenRotations);
            trigger = false;
        }
    }

    void FixedUpdate()
    {
        float dt = Time.fixedDeltaTime;
        float t;
        Quaternion newRot;
        //if the mouse has been released
        switch (state)
        {
            case (State.Idle):
                //nothing
                break;
            case (State.Rotating):  //returning to base rotation dragin the hub
                //calculate the next rotation with an interpolation
                rotTime += dt;
                t = rotTime / rotDuration;
                newRot = Quaternion.Slerp(transform.localRotation, rotations[currentRot], t);
                if (Quaternion.Angle(transform.localRotation, newRot) <= Mathf.Epsilon)
                {
                    transform.localRotation = rotations[currentRot];
                    //if it was returning we end the rotation and set the time of the next rotation to the adjust time
                    state = State.Idle;
                    trigger = true;
                }
                else
                {
                    /*Quaternion offset = newRot * Quaternion.Inverse(transform.rotation);
                    this.transform.Rotate(offset.eulerAngles, Space.World);*/
                    transform.localRotation = newRot;
                }
                break;
        }
    }

    private void ActivateRotation()
    {
        rotTime = 0.0f;
        currentRot = (currentRot + 1) % platformNumberOfFaces;
        state = State.Rotating;
    }
}
