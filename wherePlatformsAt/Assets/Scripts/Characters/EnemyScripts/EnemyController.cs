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

    private PlayerController thePlayer;
    private float timeBtwShots;
    private Animator anim;
    private float distToHitPlayer;
    private bool hittingPlayer = true;
    // Bit shift the index of the layer to get a bit mask
    int layerMask;

    private bool alive;

    public bool Alive
    {
        set { alive = value; }
        get { return alive; }
    }

    private void Awake()
    {
        thePlayer = FindObjectOfType<PlayerController>();
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

    private void Start()
    {
        layerMask = (1 << 0) + (1 << 1) + (1 << 2) + (1 << 4) + (1 << 5);
        EnemyBulletController bulletController = bullet.GetComponent<EnemyBulletController>();
        distToHitPlayer = bulletController.speed * bulletController.seconds;
    }

    void Update ()
    {
        if (alive)
        {
            if (shoot)
            {   
                Vector3 firePos = firePosition.transform.position;
                Vector3 dir = (thePlayer.gameObject.transform.position + new Vector3(0.0f, 1.19f, 0.0f)) - firePos;
                RaycastHit hit;
                if (hittingPlayer = Physics.Raycast(firePos, dir, out hit, distToHitPlayer, 1 << 8) && !Physics.Raycast(firePos, dir, out hit, distToHitPlayer, layerMask))
                {
                    if (timeBtwShots <= 0)
                    {
                        Instantiate(bullet.transform, firePos, Quaternion.identity);
                        timeBtwShots = startTimeBtwShots;
                    }
                }
                timeBtwShots -= Time.deltaTime;
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
