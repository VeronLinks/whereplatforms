using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightStickLook : MonoBehaviour
{

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update()
        {
            var angH = Input.GetAxis("Rhorizontal") * 60;
            var angV = Input.GetAxis("Rverticle") * 45;
            transform.localEulerAngles = new Vector3(angV, angH, 0);
        }
}
