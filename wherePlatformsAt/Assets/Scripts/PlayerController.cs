using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public GameObject bullet;
    private bool canFire = true;

    private CharController playerChar;

    void Fire()
    {
        // Instantiate a bullet on the screen
        GameObject bulletClone = Instantiate(bullet, transform.position, transform.rotation);
    }

    void Start()
    {
        playerChar = GetComponent<CharController>();
    }

    void Update()
    {
        playerChar.VerticalAxis = Input.GetAxisRaw("Vertical");
        playerChar.HorizontalAxis = Input.GetAxisRaw("Horizontal");
        playerChar.JumpTrigger = Input.GetKeyDown(KeyCode.Space);

        //playerChar.Attacking = Input.GetButtonDown("Fire1");
        if (Input.GetMouseButton(0))
        {
            if (canFire)
            {
                canFire = false;
                Fire();
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            canFire = true;
        }
    }
}