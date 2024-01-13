using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float playerSpeedX;
    [SerializeField] private float playerSpeedY;

    [SerializeField] private bool rbMove;

    private Rigidbody2D playerRB;

    private void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(!rbMove)
        {
            MovePlayer();
        }
    }

    private void LateUpdate()
    {
        if(rbMove)
        {
            MovePlayerRigidBody();
        }
         
    }

    private void MovePlayer()
    {
        float ySpeed = playerSpeedY * Input.GetAxis("Vertical");
        float xSpeed = playerSpeedY * Input.GetAxis("Horizontal");

        //Up
        if (Input.GetAxis("Vertical") > 0)
        {
            transform.position += Vector3.up * playerSpeedY * Time.deltaTime;
        }

        //Down
        if (Input.GetAxis("Vertical") < 0)
        {
            transform.position += Vector3.down * playerSpeedY * Time.deltaTime;

        }


        //Right
        if (Input.GetAxis("Horizontal") > 0)
        {
            transform.position += Vector3.right * playerSpeedX * Time.deltaTime;

        }

        //Left
        if (Input.GetAxis("Horizontal") < 0)
        {
            transform.position += Vector3.left * playerSpeedX * Time.deltaTime;

        }

    }

    private void MovePlayerRigidBody()
    {
        //Up
        if (Input.GetKey(KeyCode.W))
        {

        }

        //Down
        if (Input.GetKey(KeyCode.W))
        {

        }


        //Right
        if (Input.GetKey(KeyCode.W))
        {

        }

        //Left
        if (Input.GetKey(KeyCode.W))
        {

        }

    }
}
