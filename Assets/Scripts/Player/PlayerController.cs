using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Move")]
    [SerializeField] private float speed;
    [SerializeField] private float leftRightSpeed;
    [SerializeField] private bool canMove = false;

    [Header("Jump")]
    [SerializeField] private bool isJumping = false;
    [SerializeField] private bool canJump = true;
    [SerializeField] private float jumpHeight = 3f;
    [SerializeField] private float jumpDuration = 1f;
    private float originalYPosition;
    private float jumpStartTime;

    [Header("Animator")]
    [SerializeField] private GameObject playerObject;
    [SerializeField] private string animationName;

    void Start()
    {
        originalYPosition = gameObject.transform.position.y;
    }

    void Update()
    {
        if (!GameManager.IsGameOver())
        {
            canMove = GameManager.IsStarted();
            speed = PlayerManager.GetSpeed();
            leftRightSpeed = speed;
            Movement();
            animationName = playerObject.GetComponent<Animator>().GetCurrentAnimatorClipInfo(0)[0].clip.name;
        }
    }

    private void Movement()
    {
        ForwardMovement();
        HorizontalMovement();
        Jump();
    }

    private void ForwardMovement()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed, Space.World);
    }

    private void HorizontalMovement()
    {
        if (canMove)
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                if (gameObject.transform.position.x > LevelBoundary.leftSide)
                {
                    transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed);
                }
            }

            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                if (gameObject.transform.position.x < LevelBoundary.rightSide)
                {
                    transform.Translate(Vector3.right * Time.deltaTime * leftRightSpeed);
                }
            }
        }
    }

    private void Jump()
    {
        if (canMove && canJump)
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Space))
            {
                if (!isJumping)
                {
                    isJumping = true;
                    canJump = false;
                    jumpStartTime = Time.time;
                    playerObject.GetComponent<Animator>().Play("Jump");
                }
            }
        }

        if (isJumping)
        {
            float elapsedTime = Time.time - jumpStartTime;
            if (elapsedTime < jumpDuration)
            {
                float normalizedTime = elapsedTime / jumpDuration;
                float height = 1.5f * jumpHeight * normalizedTime * (1 - normalizedTime); 
                Vector3 newPosition = transform.position;
                newPosition.y = originalYPosition + height;
                transform.position = newPosition;
            }
            else
            {
                isJumping = false;
                canJump = true;
                Vector3 newPosition = transform.position;
                newPosition.y = originalYPosition;
                transform.position = newPosition;
                UpdateAnimation();
            }
        }
    }

    private void UpdateAnimation()
    {
        if (!GameManager.IsGameOver())
        {
            if (PlayerManager.GetRunningType() == RunningType.Slow)
            {
                playerObject.GetComponent<Animator>().Play("Slow Run");
            }
            else if (PlayerManager.GetRunningType() == RunningType.Normal)
            {
                playerObject.GetComponent<Animator>().Play("Medium Run");
            }
            else if (PlayerManager.GetRunningType() == RunningType.Fast)
            {
                playerObject.GetComponent<Animator>().Play("Fast Run");
            }
        }
    }
}
