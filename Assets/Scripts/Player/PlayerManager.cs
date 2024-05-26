using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    [SerializeField] private static int numCoins = 0;
    [SerializeField] private static int numLives = 3;
    [SerializeField] private static int numDiamonds = 0;

    [Header("Speed")]
    [SerializeField] private static float speed;
    [SerializeField] private static float minSpeed = 2;
    [SerializeField] private static float normalSpeed = 4;
    [SerializeField] private static float maxSpeed = 6;
    [SerializeField] private static float resetSpeedDelay = 6f;
    [SerializeField] private static RunningType runningtype;

    public static AudioSource playerAudioSource;

    private static Coroutine resetSpeedCoroutine;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            playerAudioSource = GetComponent<AudioSource>();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        runningtype = RunningType.Normal;
        speed = normalSpeed;
        playerAudioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        //CheckRunningType();
    }

    //private void CheckRunningType()
    //{
    //    if (runningtype == RunningType.Normal)
    //    {
    //        speed = normalSpeed;
    //    }
    //    else
    //    {
    //        if (runningtype == RunningType.Slow)
    //        {
    //            speed = minSpeed;
    //        }
    //        else if (runningtype == RunningType.Fast)
    //        {
    //            speed = maxSpeed;

    //            if (resetSpeedCoroutine != null)
    //            {
    //                StopCoroutine(resetSpeedCoroutine);
    //            }
    //            resetSpeedCoroutine = StartCoroutine(ResetSpeedAfterDelay());
    //        }
    //    }
    //}

    private static IEnumerator ResetSpeedAfterDelay()
    {
        yield return new WaitForSeconds(resetSpeedDelay);
        ResetSpeed();
    }

    public static void ResetSpeed()
    {
        speed = normalSpeed;
        runningtype = RunningType.Normal;
        playerAudioSource.Play();
    }

    public static void SetSlowSpeed()
    {
        speed = minSpeed;
        runningtype = RunningType.Slow;
        playerAudioSource.Stop();
    }

    public static void SetFastSpeed(MonoBehaviour monoBehaviour)
    {
        speed = maxSpeed;
        runningtype = RunningType.Fast;
        playerAudioSource.Stop();

        if (resetSpeedCoroutine != null)
        {
            monoBehaviour.StopCoroutine(resetSpeedCoroutine);
        }
        resetSpeedCoroutine = monoBehaviour.StartCoroutine(ResetSpeedAfterDelay());
    }

    public static void AddCoin()
    {
        numCoins++;
    }

    public static void AddLife()
    {
        numLives++;
    }

    public static void SubtractLife()
    {
        numLives--;
    }

    public static void AddDiamond()
    {
        numDiamonds++;
    }

    #region Getters
    public static float GetSpeed()
    {
        return speed;
    }

    public static int GetCoins()
    {
        return numCoins;
    }

    public static int GetLives()
    {
        return numLives;
    }

    public static int GetDiamonds()
    {
        return numDiamonds;
    }

    #endregion
}
