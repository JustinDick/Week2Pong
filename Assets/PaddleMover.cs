using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMover : MonoBehaviour
{
    public float movementPerSecond = 1f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float movementAxis = Input.GetAxis("Horizontal");

        Vector3 force = Vector3.forward * movementAxis * movementPerSecond * Time.deltaTime;

        Rigidbody rbody = GetComponent<Rigidbody>();
        LeftBumperProperties leftPaddle = GetComponent<LeftBumperProperties>();
        RightBumperProperties rightPaddle = GetComponent<RightBumperProperties>();
        if (Input.GetKey(KeyCode.W) && leftPaddle)
        {
            Transform transform = GetComponent<Transform>();
            transform.position += Vector3.forward * movementPerSecond * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S) && leftPaddle)
        {
            Transform transform = GetComponent<Transform>();
            transform.position += -Vector3.forward * movementPerSecond * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.UpArrow) && rightPaddle)
        {
            Transform transform = GetComponent<Transform>();
            transform.position += Vector3.forward * movementPerSecond * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow) && rightPaddle)
        {
            Transform transform = GetComponent<Transform>();
            transform.position += -Vector3.forward * movementPerSecond * Time.deltaTime;
        }
    }
}
