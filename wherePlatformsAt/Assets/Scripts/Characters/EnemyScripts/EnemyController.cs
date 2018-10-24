using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public bool shoot = true;
    public float startTimeBtwShots;
    public GameObject bullet;
    public GameObject firePosition;
    public GameObject ragdollSkeleton;
    public GameObject skeleton;
    public Rigidbody[] ragdollRB;

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
        if (ragdollRB != null)
        {
            foreach (Rigidbody r in ragdollRB)
            {
                r.detectCollisions = false;
                r.isKinematic = true;
            }
        }
    }
    
	void Update ()
    {
        if (alive)
        {
            if (shoot)
            {
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
        }
	}

    public void Death()
    {
        alive = false;
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
