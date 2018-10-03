using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour {

    #region Public Attributes
    public float maxVel = 10.0f;
    public float accel = 20.0f;
    public float maxRotVel = 120.0f;
    public float accelAngular = 240.0f;
    [Range(0.0f, 1.0f)]
    public float horizontalVelMultiplier = 0.8f;
    public float jumpSpeed = 8.0f;
    public float jumpingSecondsSet = 1.0f;
    public float gravity = -9.8f;
    #endregion

    #region Private Attributes
    private float vvelocityLinear = 0.0f;
    private float hvelocityLinear = 0.0f;
    private Vector3 moveDirection = Vector3.zero;
    //private float velocityAngular = 0.0f;
    private CharacterController controller;
    private float jumpingCount = 0;
    private bool ableToJump = true;
    private Animator anim;
    private float cameraInitialY;
    private float cameraInitialZ;

    private float verticalAxis;
    private float horizontalAxis;
    private bool jumpTrigger = false;
    private bool attacking = false;
    private bool alive = true;
    private Vector3 initialPos;
    #endregion

    #region Properties
    public float VerticalAxis
    {
        get { return verticalAxis; }
        set { verticalAxis = value; }
    }
    public float HorizontalAxis
    {
        get { return horizontalAxis; }
        set { horizontalAxis = value; }
    }
    public Vector3 MoveDirection
    {
        get { return moveDirection; }
        set { moveDirection = value; }
    }
    public bool JumpTrigger
    {
        get { return jumpTrigger; }
        set { jumpTrigger = value; }
    }
    public bool Attacking
    {
        get { return attacking; }
        set { attacking = value; }
    }
    public bool Alive
    {
        get { return alive; }
        set { alive = value; }
    }
    #endregion

    void Start()
    {
        controller = GetComponent<CharacterController>();
        initialPos = transform.position;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        float dt = Time.deltaTime;

        float vTarget = verticalAxis * maxVel;
        float voffset = vTarget - vvelocityLinear;
        vvelocityLinear += Mathf.Clamp(voffset, -accel * dt, accel * dt);
        moveDirection.z = vvelocityLinear;

        float hTarget = horizontalAxis * maxVel * horizontalVelMultiplier;
        float hoffset = hTarget - hvelocityLinear;
        hvelocityLinear += Mathf.Clamp(hoffset, -accel * dt, accel * dt);
        moveDirection.x = hvelocityLinear;

        if (controller.isGrounded)
        {
            if (jumpTrigger && ableToJump)
            {
                moveDirection.y = jumpSpeed;
                anim.SetTrigger("Jump");
                ableToJump = false;
            }
            if (!jumpTrigger)
            {
                ableToJump = true;
            }
        }
        else
        {
            jumpingCount += Time.deltaTime;
            if (!jumpTrigger || jumpingCount >= jumpingSecondsSet)
            {
                moveDirection.y += 2 * gravity * dt;
                jumpingCount = 0;
            }
            moveDirection.y += gravity * dt;
            //apply gravity if you aren't grounded

        }

        //apply the movement to the controller
        //controller.Move(Vector3.right * moveDirection.x * dt + Vector3.up * moveDirection.y * dt + Vector3.forward * moveDirection.z * dt);

        moveDirection = transform.TransformDirection(moveDirection);

        controller.Move(moveDirection * dt);
        anim.SetFloat("ZSpeed", vvelocityLinear);
        anim.SetFloat("AbsZSpeed", Mathf.Abs(vvelocityLinear));
        anim.SetFloat("YSpeed", moveDirection.y);
        anim.SetFloat("XSpeed", hvelocityLinear);
        anim.SetFloat("AbsXSpeed", Mathf.Abs(hvelocityLinear));
        anim.SetBool("Grounded", controller.isGrounded);

        /* float vTargetRot = horizontalAxis * maxRotVel;
         float voffsetRot = vTargetRot - velocityAngular;
         velocityAngular += Mathf.Clamp(voffsetRot, -2 * accelAngular * dt, 2 * accelAngular * dt);*/

        //transform.eulerAngles += new Vector3(0.0f, velocityAngular * dt, 0.0f);


        /*if (attacking)
        {
            attacking = false;
        }*/

        if (!alive)
        {
            transform.position = initialPos;
            alive = true;
        }
    }

    #region Methods
    #endregion
}
