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
    private int currentRot = 0;
    private bool trigger = false;

    private State state = State.Idle;

    enum State
    {
        Idle,
        Rotating
    }

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

        if (rotDuration < Mathf.Epsilon)
        {
            rotDuration = Mathf.Epsilon;
        }
    }
    
    void Update()
    {
        if (trigger)
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

        switch (state)
        {
            case (State.Idle):
                //nothing
                break;
            case (State.Rotating):
                //calculate the next rotation with an interpolation
                rotTime += dt;
                t = rotTime / rotDuration;
                newRot = Quaternion.Slerp(transform.localRotation, rotations[currentRot], t);
                
                if (Quaternion.Angle(newRot, rotations[currentRot]) <= Mathf.Epsilon)
                {
                    transform.localRotation = rotations[currentRot];
                    state = State.Idle;
                    trigger = true;
                }
                else
                {
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
