using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *  Author: Javier Verón
 *  
 *  Makes the enemy shoot the player (which can be disabled from the editor turning to false "shoot").
 *  Makes the enemy die if Death() is called from anywhere. This enables the ragdoll and destroys everything in the corpse that may cause troubles to the ragdoll.
 */

public class EnemyController : MonoBehaviour
{
    public bool shoot = true;
    public float startTimeBtwShots;
    public GameObject bullet;
    public GameObject firePosition;
    public Rigidbody[] ragdollRB;

    private PlayerController thePlayer;
    private float timeBtwShots;
    private float distToHitPlayer;
    // Bit shift the index of the layer to get a bit mask
    int layerMask;
    private State state = State.NotShooting;

    enum State
    {
        //Alive,
        Shooting,
        NotShooting,
        Dead
    }

    private bool alive;

    public bool Alive
    {
        set { alive = value; }
        get { return alive; }
    }

    private void Awake()
    {
        thePlayer = FindObjectOfType<PlayerController>();
        alive = true;
        timeBtwShots = startTimeBtwShots;
        if (ragdollRB != null)
        {
            foreach (Rigidbody r in ragdollRB)
            {
                r.detectCollisions = false;
                r.isKinematic = true;
            }
        }
    }

    private void Start()
    {
        layerMask = (1 << 0) + (1 << 1) + (1 << 2) + (1 << 4) + (1 << 5);
        EnemyBulletController bulletController = bullet.GetComponent<EnemyBulletController>();
        distToHitPlayer = bulletController.speed * bulletController.seconds;
    }

    void Update ()
    {
        switch(state)
        {
            //As Alive state did the same as NotShooting I chose to leave NotShooting and delete Alive state.
            /*case State.Alive:
                switch (shoot)
                {
                    case true:
                        state = State.Shooting;
                        break;
                    case false:
                        state = State.NotShooting;
                        break;
                }
                break;*/ 

            case State.Shooting:
                Vector3 firePos = firePosition.transform.position;
                Vector3 dir = (thePlayer.gameObject.transform.position + new Vector3(0.0f, 1.19f, 0.0f)) - firePos;
                RaycastHit hit;
                if (Physics.Raycast(firePos, dir, out hit, distToHitPlayer, 1 << 8))
                {
                    if (!Physics.Raycast(firePos, dir, hit.distance, layerMask))
                    {
                        if (timeBtwShots <= 0)
                        {
                            Instantiate(bullet.transform, firePos, Quaternion.identity);
                            timeBtwShots = startTimeBtwShots;
                        }
                    }
                }
                timeBtwShots -= Time.deltaTime;

                switch (shoot)
                {
                    case true:
                        state = State.Shooting;
                        break;
                    case false:
                        state = State.NotShooting;
                        break;
                }
                break;

            case State.NotShooting:
                switch (shoot)
                {
                    case true:
                        state = State.Shooting;
                        break;
                    case false:
                        state = State.NotShooting;
                        break;
                }
                break;

            case State.Dead:
                if (alive)
                {
                    Death();
                }
                //else do nothing
                break;
        }
	}

    public void Death()
    {
        alive = false;
        state = State.Dead;
        if (ragdollRB != null)
        {
            foreach (Rigidbody r in ragdollRB)
            {
                r.detectCollisions = true;
                r.isKinematic = false;
            }
        }
        Destroy(this.gameObject.GetComponent<Animator>());
        Destroy(this.gameObject.GetComponent<CharController>());
        Destroy(this.gameObject.GetComponent<CharacterController>());
        Destroy(this.gameObject.GetComponent<CapsuleCollider>());
    }
}
