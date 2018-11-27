using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    public GameObject bullet;
    public GameObject shield;
    public GameObject axe;
    public Transform firePoint;
    public Transform center;
    public Transform respawn;

    public AudioClip unlock;
    public AudioClip bounce;
    public AudioClip thrown;
    public AudioClip thud;
    public AudioClip hit;

    public bool useController;


    private float time = 0;
    private float endtime;


    private bool canFire = true;
    private bool hasShield = false;
    private int ammo = 0;
    private int score = 0;
    private int lives = 3;
    private string door = "Closed";
    private AudioSource source;

    private CharController playerChar;

    private void Awake()
    {
        playerChar = GetComponent<CharController>();
    }

    void Start()
    {
        shield.GetComponent<MeshRenderer>().enabled = false;
        axe.GetComponent<MeshRenderer>().enabled = false;

        source = GetComponent<AudioSource>();
        playerChar = GetComponent<CharController>();
        InvokeRepeating("Count", 0.0f, 1.0f);

        if (respawn == null)
        {
            respawn = transform;
        }
    }

    void Update()
    {
        playerChar.VerticalAxis = Input.GetAxisRaw("Vertical");
        playerChar.HorizontalAxis = Input.GetAxisRaw("Horizontal");
        playerChar.JumpTrigger = Input.GetKey(KeyCode.Space);

        if (!useController)
        {
            if (Input.GetMouseButton(0) && ammo > 0) //fires if the mouse button is clicked and you have ammo,
            {
                if (canFire)
                {
                    source.PlayOneShot(thrown);
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

        if (useController)
        {
            playerChar.JumpTrigger = Input.GetKey(KeyCode.Joystick1Button0) || Input.GetKey(KeyCode.Joystick1Button4);

            if (Input.GetKey(KeyCode.Joystick1Button5) && ammo > 0) //fires if the mouse button is clicked and you have ammo,
            {
                if (canFire)
                {
                    source.PlayOneShot(thrown);
                    canFire = false;
                    Fire();
                    ammo--;
                }
            }

            if (Input.GetKeyUp(KeyCode.Joystick1Button5))
            {
                canFire = true;
            }

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

        }

        if(lives == 0)
        {
            SceneManager.LoadScene(0);

        }

        if(ammo > 0)
        {
            axe.GetComponent<MeshRenderer>().enabled = true;
        }
        else
        {
            axe.GetComponent<MeshRenderer>().enabled = false;
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "enemBullet")
        {
            if(hasShield == true)
            {
                hasShield = false;
                shield.GetComponent<MeshRenderer>().enabled = false;
                source.PlayOneShot(thud);
            }
            else
            {
                source.PlayOneShot(hit);
                transform.position = respawn.position;
            }
        }
        if (other.gameObject.tag == "Finish")
        {
            source.PlayOneShot(unlock);
            PlayerPrefs.SetFloat("Timer", time);

            SceneManager.LoadScene(3);
        }
        if (other.gameObject.tag == "bouncyS")
        {
            source.PlayOneShot(bounce);
            playerChar.moveDirection.y = 15;
        }
        if (other.gameObject.tag == "bouncyB")
        {
            source.PlayOneShot(bounce);
            playerChar.moveDirection.y = 30;
        }
        if (other.gameObject.tag == "Lava")
        {
            lives--;
        }
        if (other.gameObject.tag == "Ammo") //if player collides with the ammo prefab
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
        if (other.gameObject.tag == "Key") //if player collides with the key
        {
            door = "Opened";
        }
        if (other.gameObject.tag == "Shield") //if player collides with the shield.
        {
            Destroy(other.gameObject);
            hasShield = true;
            shield.GetComponent<MeshRenderer>().enabled = true;
        }
    }
    void Count()
    {
        time++;
    }

    void Fire()
    {
        Instantiate(bullet, firePoint.transform.position, firePoint.transform.rotation);
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
