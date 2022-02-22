using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public BallController ballController;
    public BallController smallBalls;
    public GameObject bullet;
    public GameObject player;
    public GameObject mediumBall;
    public GameObject smallBall;
    public bool isLargeDestroyed;
    public bool isMediumDestroyed;

    private GameObject[] balls;
    private Vector3 newMediumBallPos;
    private Vector3 playerPos;
    private Vector3 offset = new Vector3(0, 0.79f, 0);
    private Vector3 newPos;
    
    void Update()
    {
        Shooter();
        BreakLargeBall();
        BreakMediumBall();
    }

    void Shooter()
    {
        playerPos = player.transform.position;
        newPos = playerPos + offset;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bullet, newPos, bullet.transform.rotation);
        }
    }

    void BreakLargeBall()
    {
        if (isLargeDestroyed == true)
        {
            Instantiate(mediumBall, ballController.ballPos + new Vector3(-0.4f, 0, 0), mediumBall.transform.rotation);
            Instantiate(mediumBall, ballController.ballPos + new Vector3(0.4f, 0, 0), mediumBall.transform.rotation);
            isLargeDestroyed = false;
        }
    }

    void BreakMediumBall()
    {
        balls = GameObject.FindGameObjectsWithTag("MediumBall");
        if (isMediumDestroyed == true)
        {
            if (GameObject.FindGameObjectWithTag("MediumBall").activeInHierarchy)
            {
                newMediumBallPos = GameObject.FindGameObjectWithTag("MediumBall").transform.position;
                Instantiate(smallBall, newMediumBallPos + new Vector3(-0.2f, 0, 0), smallBall.transform.rotation);
                Instantiate(smallBall, newMediumBallPos + new Vector3(0.2f, 0, 0), smallBall.transform.rotation);
                isMediumDestroyed = false;
            }
        }
    }
}
