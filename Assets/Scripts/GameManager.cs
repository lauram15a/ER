using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("UI GameObjects")]
    [SerializeField] private GameObject uiInstance;
    [SerializeField] private GameObject gameoverUIInstance;

    [Header("Game")]
    [SerializeField] private static bool isStarted = false;
    [SerializeField] private static bool isGameOver = false;

    private static GameObject ui;    
    private static GameObject gameoverUI;

    public object Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            ui = uiInstance;
            gameoverUI = gameoverUIInstance;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver)
        {
            ui.SetActive(false);
            gameoverUI.SetActive(true);
        }
    }

    #region Getters and Setters
    public static GameObject GetUI()
    {
        return ui;
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
