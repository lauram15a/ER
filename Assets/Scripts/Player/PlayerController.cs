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
    [SerializeField] private bool comingDown = false;
    [SerializeField] private bool canJump = true;
    [SerializeField] private float upDistanceJump = 3f;
    [SerializeField] private float jumpDelay = 1f;
    private float originalYPosition;

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
                    playerObject.GetComponent<Animator>().Play("Jump");
                    StartCoroutine(JumpSequence());
                }
            }
        }

        if (isJumping)
        {
            if (!comingDown)
            {
                transform.Translate(Vector3.up * Time.deltaTime * upDistanceJump, Space.World);
            }

            if (comingDown)
            {
                transform.Translate(Vector3.down * Time.deltaTime * upDistanceJump, Space.World);
            }
        }
    }

    IEnumerator JumpSequence()
    {
        float startY = transform.position.y;
        yield return new WaitForSeconds(jumpDelay);
        comingDown = true;
        yield return new WaitForSeconds(jumpDelay);

        isJumping = false;
        comingDown = false;

        Vector3 currentPosition = transform.position;
        currentPosition.y = startY;
        transform.position = currentPosition;

        canJump = true;

        UpdateAnimation();
    }

    private void UpdateAnimation()
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
