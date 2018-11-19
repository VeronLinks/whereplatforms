using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    public GameObject bullet;
    public Transform firePoint;
    public Transform center;
    public Transform respawn;

    private float time = 0;
    private float endtime;
    

    private bool canFire = true;
    private int ammo = 0;
    private int score = 0;
    private int lives = 3;
    private string door = "Closed";

    private CharController playerChar;

    void Fire()
    {
        GameObject bulletClone = Instantiate(bullet, firePoint.transform.position, firePoint.transform.rotation);
    }

    void Start()
    {


        playerChar = GetComponent<CharController>();
        InvokeRepeating("Count", 0.0f, 1.0f);
    }

    void Update()
    {
        playerChar.VerticalAxis = Input.GetAxisRaw("Vertical");
        playerChar.HorizontalAxis = Input.GetAxisRaw("Horizontal");
        playerChar.JumpTrigger = Input.GetKey(KeyCode.Space);

        if (Input.GetMouseButton(0) && ammo > 0) //fires if the mouse button is clicked and you have ammo, 
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
        if(lives == 0)
        {
            SceneManager.LoadScene(0);
            
        }
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "enemBullet")
        {
            transform.position = respawn.position;
        }
        if (other.gameObject.tag == "Finish")
        {
            PlayerPrefs.SetFloat("Timer", time);
            
            SceneManager.LoadScene(3);
           
        }
        if (other.gameObject.tag == "bouncyS")
        {
            playerChar.moveDirection.y = 15;
        }
        if (other.gameObject.tag == "bouncyB")
        {
            playerChar.moveDirection.y = 30;
        }
        if (other.gameObject.tag == "Lava")
        {
            lives--;
        }
        if (other.gameObject.tag == "Paint") //if player collides with the paint prefab
        {
            
            Destroy(other.gameObject);
            ammo += 5;
            if (ammo > 25) //limits ammo to 25
            {
                ammo = 25;
            }
        }
        if (other.gameObject.tag == "Collectable") //if player collides with the collectable prefab
        {

            Destroy(other.gameObject);
            score++;
        }
        if (other.gameObject.tag == "Key") //if player collides with the collectable prefab
        {

            door = "Opened";
        }
    }
    void Count()
    {
        time++;
    }
   


    void OnGUI() //prints HUD out to the screen
    {
        GUI.Box(new Rect(10, 10, 100, 30), "Door: " + door);
        GUI.Box(new Rect(120, 10, 100, 30), "Score: " + score);
        GUI.Box(new Rect(230, 10, 100, 30), "Lives: " + lives);
        GUI.Box(new Rect(340, 10, 100, 30), "Ammo: " + ammo);
        GUI.Box(new Rect(450, 10, 100, 30), "timer: " + time);
    }
}