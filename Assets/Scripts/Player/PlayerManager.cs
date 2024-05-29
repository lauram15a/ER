using System.Collections;
using System.Collections.Generic;
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
    [SerializeField] private int numLives = 3;
    [SerializeField] private int numDiamonds = 0;

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

    [Header("Game")]
    [SerializeField] private bool isStarted = false;
    [SerializeField] private bool isGameOver = false;

    public static GameObject playerObject { get; private set; }

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
        runningType = RunningType.Normal;
        speed = normalSpeed;
        stepsDelay = normalStepsDelay;
        playerAudioSource.Play();
    }

    void Update()
    {
        AddSteps();
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
        speed = normalSpeed;
        stepsDelay = normalStepsDelay;
        runningType = RunningType.Normal;
        playerAudioSource.Play();
        playerObject.GetComponent<Animator>().Play("Medium Run");
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

    #region Add collectables
    public static void AddCoin()
    {
        Instance.numCoins++;
    }

    public static void AddLife()
    {
        Instance.numLives++;
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

    public static bool IsStarted()
    {
        return Instance.isStarted;
    }

    public static void SetIsStarted(bool v)
    {
        Instance.isStarted = v;
    }

    public static bool IsGameOver()
    {
        return Instance.isGameOver;
    }

    public static void SetIsGameOver(bool v)
    {
        Instance.isGameOver = v;
    }
    #endregion
}
