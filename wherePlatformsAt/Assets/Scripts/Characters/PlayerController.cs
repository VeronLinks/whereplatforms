﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour {

    public GameObject bullet;
    public GameObject Paint;
    public Transform firePoint;
    public Transform center;
    public Transform respawn;

    private bool canFire = true;
    private int ammo = 0;
    private int lives = 3;

    private CharController playerChar;

    void Fire()
    {
        // Instantiate a bullet on the screen
<<<<<<< HEAD
        //GameObject bulletClone = 
        Instantiate(bullet, firePoint.transform.position, firePoint.transform.rotation);
=======
        GameObject bulletClone = Instantiate(bullet, firePoint.transform.position, firePoint.transform.rotation);
>>>>>>> a8a763dc3e6017c6377c087a891bf8a6b04deb74
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

        if (Input.GetMouseButton(0) && ammo > 0) //fires if the mouse button is clicked and you have ammo, 
        {
            if (canFire)
            {
                canFire = false;
                Fire();
                ammo--;
            }
        }
        /*if (lives == 2)
        {
            SceneManager.LoadScene("lose");
        }*/

        if (Input.GetMouseButtonUp(0))
        {
            canFire = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "enemBullet")
        {
            transform.position = respawn.position;
        }

<<<<<<< HEAD
        if (other.gameObject.tag == "bouncyPlatform")
        {
            playerChar.jumpSpeed += 1 / 4;
            playerChar.JumpTrigger = true;
        }
=======
>>>>>>> 3c97e3af86b69e600050b56a055d3646661ce827

        if (other.gameObject.tag == "Paint") //if player collides with the paint prefab
        {
            Destroy(other.gameObject);
            ammo += 5;
            if (ammo > 25) //limits ammo to 25
            {
                ammo = 25;
            }
        }
    }
    


    void OnGUI() //prints ammo out to the screen
    {
        GUI.Box(new Rect(10, 10, 100, 30), "Ammo: " + ammo);
        //GUI.Box(new Rect(10, 40, 100, 30), "Lives: " + lives);
    }
}