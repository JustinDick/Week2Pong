using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPhysics : MonoBehaviour
{
    public float movementPerSecond = 1.0f;
    public Rigidbody rbody;
    GameObject leftPaddle;
    GameObject rightPaddle;
    public int playerOneScore = 0;
    public int playerTwoScore = 0;
    // Start is called before the first frame update
    void Start()
    {
        leftPaddle = GameObject.Find("LeftPaddle");
        rightPaddle = GameObject.Find("RightPaddle");
        Vector3 force = (Vector3.forward + Vector3.right) * movementPerSecond;

        rbody = GetComponent<Rigidbody>();

        rbody.AddForce(force, ForceMode.Impulse);

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "LeftPaddle")
        {
            movementPerSecond += 1;
            rbody.AddForce(rbody.velocity, ForceMode.Impulse);
            GetComponent<Renderer>().material.color = Color.red;

        }

        if (collision.gameObject.name == "RightPaddle")
        {
            movementPerSecond += 1;
            rbody.AddForce(rbody.velocity, ForceMode.Impulse);
            GetComponent<Renderer>().material.color = Color.blue;
        }

        if (collision.gameObject.name == "LeftWall")
        {
            movementPerSecond = 5.0f;
            Vector3 force = (Vector3.forward + Vector3.right) * movementPerSecond;
            rbody.velocity = new Vector3(0.0f, 0.0f, 0.0f);
            rbody.transform.position = new Vector3(-3.5f, 0.2f, 0.0f);
            rbody.AddForce(force, ForceMode.Impulse);
            playerTwoScore++;
            if (playerTwoScore == 11)
            {
                Debug.Log("Game Over!, Right Paddle wins!");
                playerOneScore = 0;
                playerTwoScore = 0;
            }
            else
            {
                Debug.Log("Right Paddle scores!, Left Paddle: " + playerOneScore + ", Right Paddle: " + playerTwoScore);
            }
        }
        if (collision.gameObject.name == "RightWall")
        {
            movementPerSecond = 5.0f;
            Vector3 force = (Vector3.forward + Vector3.left) * movementPerSecond;
            rbody.velocity = new Vector3(0.0f, 0.0f, 0.0f);
            rbody.transform.position = new Vector3(3.5f, 0.2f, 0.0f);
            rbody.AddForce(force, ForceMode.Impulse);
            playerOneScore++;
            if (playerOneScore == 11)
            {
                Debug.Log("Game Over!, Left Paddle wins!");
                playerOneScore = 0;
                playerTwoScore = 0;
            }
            else
            {
                Debug.Log("Left Paddle scores!, Left Paddle: " + playerOneScore + ", Right Paddle: " + playerTwoScore);
            }
        }
    }
}
