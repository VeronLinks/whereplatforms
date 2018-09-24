using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private CharController playerChar;

    void Start()
    {
        playerChar = GetComponent<CharController>();
    }

    void Update()
    {
        playerChar.VerticalAxis = Input.GetAxisRaw("Vertical"); ;
        playerChar.HorizontalAxis = Input.GetAxisRaw("Horizontal");
        //we will have to discuss the 1st or 3rd person in order to know how will the rotation be

        //playerChar.Attacking = Input.GetButtonDown("Fire1");
    }
}