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

    [Header("Speed")]
    [SerializeField] private float speed;
    [SerializeField] private float minSpeed = 2;
    [SerializeField] private float normalSpeed = 4;
    [SerializeField] private float maxSpeed = 6;
    [SerializeField] private float resetSpeedDelayInstance = 4f;
    [SerializeField] private RunningType runningType;

    [Header("Animator")]
    [SerializeField] private GameObject playerObjectInstance;
    public static GameObject playerObject { get; private set; }

    [Header("Audio Source")]
    public static AudioSource playerAudioSource;

    private Coroutine resetSpeedCoroutine;
    private float resetSpeedDelay;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            playerAudioSource = GetComponent<AudioSource>();
            playerObject = playerObjectInstance;
            resetSpeedDelay = resetSpeedDelayInstance;
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
        playerAudioSource.Play();
    }

    void Update()
    {

    }

    private IEnumerator ResetSpeedAfterDelay()
    {
        yield return new WaitForSeconds(resetSpeedDelay);
        ResetSpeed();
    }

    public void ResetSpeed()
    {
        speed = normalSpeed;
        runningType = RunningType.Normal;
        playerAudioSource.Play();
        playerObject.GetComponent<Animator>().Play("Medium Run");
    }

    public void SetSlowSpeed()
    {
        speed = minSpeed;
        runningType = RunningType.Slow;
        playerAudioSource.Stop();
        playerObject.GetComponent<Animator>().Play("Slow Run");
    }

    public void SetFastSpeed()
    {
        speed = maxSpeed;
        runningType = RunningType.Fast;
        playerObject.GetComponent<Animator>().Play("Fast Run");

        if (resetSpeedCoroutine != null)
        {
            StopCoroutine(resetSpeedCoroutine);
        }
        resetSpeedCoroutine = StartCoroutine(ResetSpeedAfterDelay());
    }

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

    #region Getters
    public static float GetSpeed()
    {
        return Instance.speed;
    }

    public static int GetCoins()
    {
        return Instance.numCoins;
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
