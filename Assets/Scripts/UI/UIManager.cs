using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : CanvasManager
{
    [Header("Lives")]
    [SerializeField] private GameObject imageLife;
    [SerializeField] private GameObject imageLife1;
    [SerializeField] private GameObject imageLife2;
    [SerializeField] private GameObject imageNoLife;
    [SerializeField] private GameObject imageNoLife1;
    [SerializeField] private GameObject imageNoLife2;

    protected int numLives;

    void Update()
    {
        numLives = PlayerManager.GetLives();
        LivesManager();

        if (!GameManager.IsGameOver())
        {
            numCoins = PlayerManager.GetCoins();
            numSteps = PlayerManager.GetSteps();
            numDiamonds = PlayerManager.GetDiamonds();

            CoinsManager();
            StepsManager();
            DiamondsManager();
        }
    }

    private void LivesManager()
    {
        if (numLives == 0)
        {
            imageLife.SetActive(false);
            imageLife1.SetActive(false);
            imageLife2.SetActive(false);
            imageNoLife.SetActive(true);
            imageNoLife1.SetActive(true);
            imageNoLife2.SetActive(true);
        }
        else if (numLives == 1)
        {
            imageLife.SetActive(true);
            imageLife1.SetActive(false);
            imageLife2.SetActive(false);
            imageNoLife.SetActive(false);
            imageNoLife1.SetActive(true);
            imageNoLife2.SetActive(true);
        }
        else if (numLives == 2)
        {
            imageLife.SetActive(true);
            imageLife1.SetActive(true);
            imageLife2.SetActive(false);
            imageNoLife.SetActive(false);
            imageNoLife1.SetActive(false);
            imageNoLife2.SetActive(true);
        }
        else if (numLives == 3)
        {
            imageLife.SetActive(true);
            imageLife1.SetActive(true);
            imageLife2.SetActive(true);
            imageNoLife.SetActive(false);
            imageNoLife1.SetActive(false);
            imageNoLife2.SetActive(false);
        }
        else if (numLives >= 4)
        {
            imageLife.SetActive(true);
            imageLife1.SetActive(true);
            imageLife2.SetActive(true);
            imageNoLife.SetActive(false);
            imageNoLife1.SetActive(false);
            imageNoLife2.SetActive(false);
        }
    }

}
