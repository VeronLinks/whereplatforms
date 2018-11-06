using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaBalls : MonoBehaviour
{
    public float speed;
    private Vector3 direction;

    // Use this for initialization
    void Start()
    {
        direction = new Vector3(transform.position.x, transform.position.y + 30, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, direction, speed * Time.deltaTime);
    }
}
