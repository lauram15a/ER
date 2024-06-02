using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Device;

public class GameManager : MonoBehaviour
{
    [Header("UI GameObjects")]
    [SerializeField] private GameObject uiScreenInstance;
    [SerializeField] private GameObject gameoverScreenInstance;

    [Header("Game")]
    [SerializeField] private static bool isStarted = false;
    [SerializeField] private static bool isGameOver = false;

    private static GameObject uiScreen;    
    private static GameObject gameoverScreen;

    public object Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            uiScreen = uiScreenInstance;
            gameoverScreen = gameoverScreenInstance;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        isStarted = false;
        isGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver)
        {
            uiScreen.SetActive(false);
            gameoverScreen.SetActive(true);
        }
    }

    #region Getters and Setters
    public static GameObject GetUIScreen()
    {
        return uiScreen;
    }

    public static GameObject GetGameOverScreen()
    {
        return gameoverScreen;
    }

    public static bool IsStarted()
    {
        return isStarted;
    }

    public static void SetIsStarted(bool v)
    {
        isStarted = v;
    }

    public static bool IsGameOver()
    {
        return isGameOver;
    }

    public static void SetIsGameOver(bool v)
    {
        isGameOver = v;
    }
    #endregion
}
