using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody ballRb;
    private float directionForce = 80;
    private float horizontalLimit = 8.5f;
    private float bounce = 3;
    private float smallForce = 6.5f;
    private float mediumForce = 8.5f;
    private float largeForce = 10;
    private bool isRight;
    private bool isLeft;

    public Vector3 ballPos;

    void Start()
    {
        isLeft = true;
        ballRb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        ChangeDirection();
        ContinuousMovement();
        BallPosition();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground") && ballRb.gameObject.CompareTag("SmallBall"))
        {
            ballRb.AddForce(Vector3.up * smallForce, ForceMode.Impulse);
        }
        else if (collision.gameObject.CompareTag("Ground") && ballRb.gameObject.CompareTag("MediumBall"))
        {
            ballRb.AddForce(Vector3.up * mediumForce, ForceMode.Impulse);
        }
        else if (collision.gameObject.CompareTag("Ground") && ballRb.gameObject.CompareTag("LargeBall"))
        {
            ballRb.AddForce(Vector3.up * largeForce, ForceMode.Impulse);
        }
        else if (collision.gameObject.CompareTag("Bullet"))
        {
            ballPos = transform.position;
            Debug.Log(ballPos);
            Destroy(gameObject);
        }
    }

    void ChangeDirection()
    {
        if (transform.position.x < -horizontalLimit)
        {
            transform.position = new Vector3(-horizontalLimit, transform.position.y, transform.position.z);
            ballRb.AddForce(Vector3.right * bounce, ForceMode.Impulse);
            isRight = false;
            isLeft = true;
        }

        else if (transform.position.x > horizontalLimit)
        {
            transform.position = new Vector3(horizontalLimit, transform.position.y, transform.position.z);
            ballRb.AddForce(Vector3.left * bounce, ForceMode.Impulse);
            isLeft = false;
            isRight = true;
        }
    }

    void ContinuousMovement()
    {
        if (isLeft == true)
        {
            ballRb.AddForce(Vector3.right * directionForce * Time.deltaTime);
        }
        else if (isRight == true)
        {
            ballRb.AddForce(Vector3.left * directionForce * Time.deltaTime);
        }
    }

    void BallPosition()
    {
        ballPos = transform.position;
    }
}
