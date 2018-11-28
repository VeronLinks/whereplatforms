using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PathFinder : MonoBehaviour {
    
    public Transform player;
    
    private EnemyController theE;
    private NavMeshAgent navAgent;
    private Animator anim;

    // Use this for initialization
    void Awake () {
        navAgent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        theE = GetComponent<EnemyController>();
    }

    // Update is called once per frame
    void Update ()
    {

        if (theE.alive)
        {
            transform.rotation = Quaternion.Euler(0.0f, transform.eulerAngles.y, 0.0f);
            navAgent.SetDestination(player.position);
            float vel = Mathf.Sqrt(navAgent.velocity.z * navAgent.velocity.z + navAgent.velocity.x * navAgent.velocity.x) * 2;

            anim.SetFloat("ZSpeed", vel);
            anim.SetFloat("AbsZSpeed", Mathf.Abs(vel));
            anim.SetFloat("YSpeed", 0);
            anim.SetBool("Grounded", true);

        }
        
	}
}
