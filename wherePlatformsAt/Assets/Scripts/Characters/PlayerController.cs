using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public GameObject bullet;
    public GameObject Paint;
    public Transform firePoint;
    private bool canFire = true;
    private int ammo = 0;

    private CharController playerChar;

    void Fire()
    {
        // Instantiate a bullet on the screen
        GameObject bulletClone = Instantiate(bullet, firePoint.transform.position, firePoint.transform.rotation);
    }

    void Start()
    {
        playerChar = GetComponent<CharController>();
    }

    void Update()
    {
        playerChar.VerticalAxis = Input.GetAxisRaw("Vertical");
        playerChar.HorizontalAxis = Input.GetAxisRaw("Horizontal");
        playerChar.JumpTrigger = Input.GetKey(KeyCode.Space);

        //playerChar.Attacking = Input.GetButtonDown("Fire1");
        if (Input.GetMouseButton(0) && ammo > 0)
        {
            if (canFire)
            {
                canFire = false;
                Fire();
                ammo--;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            canFire = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Paint")
        {
            Destroy(other.gameObject);
            ammo += 5;
        }
    }
}