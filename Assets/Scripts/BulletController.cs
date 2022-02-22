using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private GameManager gameManager;
    private float verticalLimit = 11.5f;
    private float speed = 10;

    public Vector3 largeBallPos;
    public Vector3 mediumBallPos;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        MoveUp();
        BoundLimit();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("LargeBall"))
        {
            largeBallPos = gameObject.transform.position;
            gameManager.isLargeDestroyed = true;
            //Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("MediumBall"))
        {
            mediumBallPos = gameObject.transform.position;
            gameManager.isMediumDestroyed = true;
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("SmallBall"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

    void BoundLimit()
    {
        if (transform.position.y > verticalLimit)
        {
            Destroy(gameObject);
        }
    }

    void MoveUp()
    {
        transform.Translate(Vector3.up * Time.deltaTime * speed);
    }
}
