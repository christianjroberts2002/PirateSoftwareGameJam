using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float playerSpeedX;
    [SerializeField] private float playerSpeedY;

    [SerializeField] private float speedBonus;
    [SerializeField] private float speedMultiplier;

    private Animator playerAnimator;

    private Rigidbody2D playerRB;

    private bool isWalking;

    private void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
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
        isWalking = false;
        //Up
        if (Input.GetAxis("Vertical") > 0)
        {
            transform.position += Vector3.up * ySpeed * speedBonus * Time.deltaTime;
            isWalking = true;
        }

        //Down
        if (Input.GetAxis("Vertical") < 0)
        {
            transform.position += Vector3.down * -ySpeed * speedBonus * Time.deltaTime;
            isWalking = true;
        }


        //Right
        if (Input.GetAxis("Horizontal") > 0)
        {
            transform.position += Vector3.right * xSpeed * speedBonus * Time.deltaTime;
            isWalking = true;
        }

        //Left
        if (Input.GetAxis("Horizontal") < 0)
        {
            transform.position += Vector3.left * -xSpeed * speedBonus * Time.deltaTime;
            isWalking = true;
        }

        playerAnimator.SetBool("IsWalking", isWalking);
    }


    public void SetSpeedMultiplier(float speedBonus)
    {
        this.speedBonus = speedBonus;
    }
}
