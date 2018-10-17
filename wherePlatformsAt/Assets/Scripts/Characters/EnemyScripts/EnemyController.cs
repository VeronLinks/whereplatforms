using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public float startTimeBtwShots;
    public GameObject bullet;
    public GameObject firePosition;
    public Transform playerCenter;
    public GameObject ragdollSkeleton;
    public GameObject skeleton;

    private float timeBtwShots;
    private Animator anim;
    private bool alive;

    public bool Alive
    {
        set { alive = value; }
        get { return alive; }
    }

    private void Awake()
    {
        anim = GetComponent<Animator>();
        alive = true;
        timeBtwShots = startTimeBtwShots;
    }
    
	void Update ()
    {
        if (alive)
        {
            transform.LookAt(playerCenter.transform.position);
            transform.rotation = Quaternion.Euler(0.0f, transform.eulerAngles.y, 0.0f);

            if (timeBtwShots <= 0)
            {
                Instantiate(bullet.transform, firePosition.transform.position, Quaternion.identity);
                timeBtwShots = startTimeBtwShots;
            }
            else
            {
                timeBtwShots -= Time.deltaTime;
            }
        }
        else
        {
            //ragdoll stuff
        }
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("PlayerBullet"))
        {
            Death();
            Destroy(collision.gameObject);
        }
    }

    private void Death()
    {
        alive = false;
        anim.SetBool("Dead", true);
        skeleton.SetActive(false);
        ragdollSkeleton.SetActive(true);

        /* 
         * HAVE TO:
         * -Redesign movement and everything in the enemy with CharacterController instead of Rigidbody.
         * -Make a ragdoll.
         * -Make a foreach loop in the awake of EnemyController for turning collisions to false and make kinematic all the rigidbodies of the components of the ragdoll.
         * -Make a foreach loop in Death() for turning collisions to true and make NOT kinematic all the rigidbodies of the components of the ragdoll.
         * -Make the animator desapear in Death().
         * -Maybe deactivate CharacterController in Death() if any trouble with collisions (before turning on the ragdoll collisions).
         */
    }
}
