using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    #region Public Attributes
    public Vector3 baseOffset = new Vector3(0.0f, 3.0f, -8.0f);
    public Vector3 lookAtOffset = new Vector3(0.0f, 0.0f, 8.0f);
    public Transform target;
    public float springK = 10.0f;
    public float damping = 5.0f;
    public float maxDistFromIdealPos = 2.5f;
    #endregion

    #region Private Attributes
    private Vector3 idealPosition;
    private Vector3 lookAtTarget;
    private Vector3 velocity;
    #endregion

    #region Properties
    #endregion

    void Start()
    {
        if (target != null)
        {
            Vector3 realOffset = baseOffset.x * target.right + baseOffset.y * target.up + baseOffset.z * target.forward;
            idealPosition = target.position + realOffset;
            transform.position = idealPosition;
        }
    }

    void Update()
    {
        float dt = Time.deltaTime;

        Vector3 pos = transform.position;
        lookAtTarget = target.TransformPoint(lookAtOffset);
        idealPosition = target.TransformPoint(baseOffset);

        float dampForce = Mathf.Min(1.0f, damping * dt);
        Vector3 dampVelOffset = -dampForce * velocity;

        Vector3 offset = idealPosition - pos;
        Vector3 accel = offset * springK;
        Vector3 accelOffset = dt * accel;

        velocity += accelOffset + dampVelOffset;

        pos += velocity * dt;

        Vector3 dirToPos = pos - idealPosition;
        float distFromIdealPosSq = dirToPos.sqrMagnitude;
        if (distFromIdealPosSq > maxDistFromIdealPos * maxDistFromIdealPos)
        {
            float distFromIdealPos = Mathf.Sqrt(distFromIdealPosSq);
            dirToPos *= maxDistFromIdealPos / distFromIdealPos;

            pos = idealPosition + dirToPos;
        }

        transform.position = pos;
        transform.LookAt(lookAtTarget, Vector3.up);

    }

    #region Methods
    #endregion
}
