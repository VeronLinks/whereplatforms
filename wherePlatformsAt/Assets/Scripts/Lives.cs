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
        if (other.gameObject.name == "Ground(Lava)")
        {
            lives--;
        }

    }
    public void death()
    {
        if (lives < 2)
        {
            SceneManager.LoadScene("lose");
        }
    }
private void OnGUI()
    {
        GUI.Box(new Rect(10,50, 100, 30), "Lives: " +lives);
    }
}
