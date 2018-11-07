using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Lives : MonoBehaviour
{
    public int lives = 3;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Lava")
        {
            lives--;
        }
        if (other.gameObject.tag == "enemBullet")
        {
            lives--;
        }
        if (lives < 0)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Application.LoadLevel(4);
        }
    }



    private void OnGUI()
    {
        GUI.Box(new Rect(10, 50, 100, 30), "Lives: " + lives);


    }

}

