using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour {

    public float maxVel = 10.0f;
    public float accel = 20.0f;
    public float maxRotVel = 120.0f;
    public float accelAngular = 240.0f;
    //public GameObject lCollider;
    //public GameObject rCollider;

    //private Animator anim;
    private float velocityLinear = 0.0f;
    private float velocityAngular = 0.0f;
    private CharacterController controller;

    private float verticalAxis;
    private float horizontalAxis;
    private bool attacking = false;
    //private bool canMove = true;
    private bool alive = true;
    private Vector3 initialPos;

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
    public bool Attacking
    {
        get { return attacking; }
        set { attacking = value; }
    }
    /*public bool CanMove
    {
        get { return canMove; }
        set { canMove = value; }
    }*/
    public bool Alive
    {
        get { return alive; }
        set { alive = value; }
    }

    void Start()
    {
        //anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        initialPos = transform.position;
    }

    void Update()
    {
        float dt = Time.deltaTime;

        /*if (!canMove)
        {
            horizontalAxis = 0.0f;
            verticalAxis = 0.0f;
        }

        if (lCollider != null)
        {
            lCollider.SetActive(!canMove);
        }
        if (rCollider != null)
        {
            rCollider.SetActive(!canMove);
        }*/

        float vTarget = verticalAxis * maxVel;
        float voffset = vTarget - velocityLinear;
        velocityLinear += Mathf.Clamp(voffset, -accel * dt, accel * dt);

        float vTargetRot = horizontalAxis * maxRotVel;
        float voffsetRot = vTargetRot - velocityAngular;
        velocityAngular += Mathf.Clamp(voffsetRot, -2 * accelAngular * dt, 2 * accelAngular * dt);

        transform.eulerAngles += new Vector3(0.0f, velocityAngular * dt, 0.0f);
        controller.Move((velocityLinear * dt) * transform.forward);
        //anim.SetFloat("Input X", velocityLinear);

        if (attacking)
        {
            //anim.SetTrigger("Attack1Trigger");
            attacking = false;
        }

        if (!alive)
        {
            transform.position = initialPos;
            alive = true;
        }
    }
}
