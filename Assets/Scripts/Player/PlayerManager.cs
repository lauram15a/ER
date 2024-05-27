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
    [SerializeField] private float resetSpeedDelay = 4f;
    [SerializeField] private RunningType runningType;

    [Header("Animator")]
    [SerializeField] private GameObject playerObjectInstance;
    public static GameObject playerObject { get; private set; }

    [Header("Audio Source")]
    public static AudioSource playerAudioSource;

    [Header("Coroutine")]
    private static Coroutine resetSpeedCoroutine;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            playerAudioSource = GetComponent<AudioSource>();
            playerObject = playerObjectInstance;
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

    private static IEnumerator ResetSpeedAfterDelay()
    {
        yield return new WaitForSeconds(Instance.resetSpeedDelay);
        ResetSpeed();
    }

    public static void ResetSpeed()
    {
        Instance.speed = Instance.normalSpeed;
        Instance.runningType = RunningType.Normal;
        playerAudioSource.Play();
        playerObject.GetComponent<Animator>().Play("Medium Run");
    }

    public static void SetSlowSpeed()
    {
        Instance.speed = Instance.minSpeed;
        Instance.runningType = RunningType.Slow;
        playerAudioSource.Stop();
        playerObject.GetComponent<Animator>().Play("Slow Run");
    }

    public static void SetFastSpeed(MonoBehaviour monoBehaviour)
    {
        Instance.speed = Instance.maxSpeed;
        Instance.runningType = RunningType.Fast;
        playerObject.GetComponent<Animator>().Play("Fast Run");

        if (resetSpeedCoroutine != null)
        {
            monoBehaviour.StopCoroutine(resetSpeedCoroutine);
        }
        resetSpeedCoroutine = monoBehaviour.StartCoroutine(ResetSpeedAfterDelay());
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
