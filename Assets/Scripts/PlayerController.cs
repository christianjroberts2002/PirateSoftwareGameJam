using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float playerSpeedX;
    [SerializeField] private float playerSpeedY;

    [SerializeField] private float speedBonus;
    [SerializeField] private float speedMultiplier;


    private Rigidbody2D playerRB;

    private void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
            MovePlayer();
    }

    private void LateUpdate()
    {
         
    }

    private void MovePlayer()
    {
        float ySpeed = playerSpeedY * Input.GetAxis("Vertical");
        float xSpeed = playerSpeedY * Input.GetAxis("Horizontal");
        float paintCoverage = PaintCoverageScript.Instance.GetPlayerPercentCovered();
        speedBonus = speedMultiplier * (paintCoverage / 100) + 1;
        
        //Up
        if (Input.GetAxis("Vertical") > 0)
        {
            transform.position += Vector3.up * ySpeed * speedBonus * Time.deltaTime;
        }

        //Down
        if (Input.GetAxis("Vertical") < 0)
        {
            transform.position += Vector3.down * -ySpeed * speedBonus * Time.deltaTime;

        }


        //Right
        if (Input.GetAxis("Horizontal") > 0)
        {
            transform.position += Vector3.right * xSpeed * speedBonus * Time.deltaTime;

        }

        //Left
        if (Input.GetAxis("Horizontal") < 0)
        {
            transform.position += Vector3.left * -xSpeed * speedBonus * Time.deltaTime;

        }

    }


    public void SetSpeedMultiplier(float speedBonus)
    {
        this.speedBonus = speedBonus;
    }
}
