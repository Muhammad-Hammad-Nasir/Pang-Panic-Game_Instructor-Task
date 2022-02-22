using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject bullet;
    private float horizontal;
    private float speed = 15;
    private float horizontalLimit = 8.5f;

    void Update()
    {
        Movement();
        Boundary();
    }

    void Movement()
    {
        horizontal = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.right * Time.deltaTime * horizontal * speed);
    }

    void Boundary()
    {
        if (transform.position.x > horizontalLimit)
        {
            transform.position = new Vector3(horizontalLimit, transform.position.y, transform.position.z);
        }
        else if (transform.position.x < -horizontalLimit)
        {
            transform.position = new Vector3(-horizontalLimit, transform.position.y, transform.position.z);
        }
    }
}
