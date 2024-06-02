using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum RunningType
{
    Slow,
    Normal,
    Fast
}

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance { get; private set; }

    [Header("Collectables")]
    [SerializeField] private int numCoins = 0;
    [SerializeField] private int numLives;
    [SerializeField] private int numDiamonds = 0;
    [SerializeField] private int maxNumLives = 3;

    [Header("Steps")]
    [SerializeField] private int numSteps = 0;
    [SerializeField] private bool canAddSteps = false;
    [SerializeField] private float stepsDelayInstance;
    [SerializeField] private float normalStepsDelayInstance = 0.5f;

    [Header("Speed")]
    [SerializeField] private float speed;
    [SerializeField] private float minSpeed = 2;
    [SerializeField] private float normalSpeed = 4;
    [SerializeField] private float maxSpeed = 6;
    [SerializeField] private float resetSpeedDelayInstance = 4f;
    [SerializeField] private RunningType runningType;

    [Header("Animator")]
    [SerializeField] private GameObject playerObjectInstance;

    [Header("Camera")]
    [SerializeField] private GameObject playerCamera;
    [SerializeField] private int collisionZPos = -2;

    private static GameObject playerObject;

    [Header("Audio Source")]
    public static AudioSource playerAudioSource;

    private Coroutine resetSpeedCoroutine;
    private float resetSpeedDelay;
    private float stepsDelay;
    private float normalStepsDelay;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            playerAudioSource = GetComponent<AudioSource>();
            playerObject = playerObjectInstance;
            resetSpeedDelay = resetSpeedDelayInstance;
            normalStepsDelay = normalStepsDelayInstance;
            stepsDelay = stepsDelayInstance;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        numLives = maxNumLives;
        runningType = RunningType.Normal;
        speed = normalSpeed;
        stepsDelay = normalStepsDelay;
        playerAudioSource.Play();
    }

    void Update()
    {
        if (!GameManager.IsGameOver())
        {
            if (GameManager.IsStarted())
            {
                AddSteps();
                CheckGameOver();
            }
        }
    }

    #region Steps
    private void AddSteps()
    {
        if (!canAddSteps)
        {
            canAddSteps = true;
            StartCoroutine(AddingSteps());
        }
    }

    IEnumerator AddingSteps()
    {
        numSteps++;
        yield return new WaitForSeconds(stepsDelay);
        canAddSteps = false;
    }

    #endregion

    #region Speed
    private IEnumerator ResetSpeedAfterDelay()
    {
        yield return new WaitForSeconds(resetSpeedDelay);
        ResetSpeed();
    }

    public void ResetSpeed()
    {
        if (!GameManager.IsGameOver())
        {
            speed = normalSpeed;
            stepsDelay = normalStepsDelay;
            runningType = RunningType.Normal;
            playerAudioSource.Play();
            playerObject.GetComponent<Animator>().Play("Medium Run");
        }   
    }

    public void SetSlowSpeed()
    {
        speed = minSpeed;
        stepsDelay = normalStepsDelay * 2;
        runningType = RunningType.Slow;
        playerAudioSource.Stop();
        playerObject.GetComponent<Animator>().Play("Slow Run");
    }

    public void SetFastSpeed()
    {
        speed = maxSpeed;
        stepsDelay = normalStepsDelay / 2;
        runningType = RunningType.Fast;
        playerObject.GetComponent<Animator>().Play("Fast Run");

        if (resetSpeedCoroutine != null)
        {
            StopCoroutine(resetSpeedCoroutine);
        }
        resetSpeedCoroutine = StartCoroutine(ResetSpeedAfterDelay());
    }

    #endregion

    #region Collision
    public void CollisionManager()
    {
        Die();
    }
    #endregion

    #region GameOver

    private void Die()
    {
        playerObject.GetComponent<Animator>().Play("Falling Back Death");

        playerCamera.GetComponent<Animator>().Play("CameraShake");

        Vector3 cameraPosition = playerCamera.transform.position;
        cameraPosition.z = cameraPosition.z + collisionZPos;
        playerCamera.transform.position = cameraPosition;

        numLives = 0;
        GameManager.SetIsGameOver(true);
    }

    private void CheckGameOver()
    {
        if (numLives == 0)
        {
            Die();
        }
    }
    #endregion

    #region Add collectables
    public static void AddCoin()
    {
        Instance.numCoins++;
    }

    public static void AddLife()
    {
        if (Instance.numLives < Instance.maxNumLives)
        {
            Instance.numLives++;
        }
    }

    public static void SubtractLife()
    {
        Instance.numLives--;
    }

    public static void AddDiamond()
    {
        Instance.numDiamonds++;
    }
    #endregion

    #region Getters y setters
    public static float GetSpeed()
    {
        return Instance.speed;
    }

    public static int GetCoins()
    {
        return Instance.numCoins;
    }

    public static int GetSteps()
    {
        return Instance.numSteps;
    }

    public static int GetLives()
    {
        return Instance.numLives;
    }

    public static int GetDiamonds()
    {
        return Instance.numDiamonds;
    }

    public static RunningType GetRunningType()
    {
        return Instance.runningType;
    }
    #endregion
}
