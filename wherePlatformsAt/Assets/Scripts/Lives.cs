using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lives : MonoBehaviour {
    private int lives = 3;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Lava")
        {
            lives--;
        }
        if (lives < 1)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            SceneManager.LoadScene(4);
        }
    }
    public void death()
    {
        
    }
private void OnGUI()
    {
        GUI.Box(new Rect(10,50, 100, 30), "Lives: " +lives);
    }
}
