using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("Coins")]
    [SerializeField] private TextMeshProUGUI textNumCoins;

    [Header("Steps")]
    [SerializeField] private TextMeshProUGUI textNumSteps;

    [Header("Lives")]
    [SerializeField] private GameObject imageLife;
    [SerializeField] private GameObject imageLife1;
    [SerializeField] private GameObject imageLife2;
    [SerializeField] private GameObject imageLife3;
    [SerializeField] private GameObject imageNoLife;
    [SerializeField] private GameObject imageNoLife1;
    [SerializeField] private GameObject imageNoLife2;

    [Header("Diamonds")]
    [SerializeField] private GameObject imageDiamond;
    [SerializeField] private GameObject imageDiamond1;
    [SerializeField] private GameObject imageDiamond2;
    [SerializeField] private GameObject imageNoDiamond;
    [SerializeField] private GameObject imageNoDiamond1;
    [SerializeField] private GameObject imageNoDiamond2;

    private int numCoins;
    private int numSteps;
    private int numLives;
    private int numDiamonds;

    void Update()
    {
        numCoins = PlayerManager.GetCoins();
        numSteps = PlayerManager.GetSteps();
        numLives = PlayerManager.GetLives();
        numDiamonds = PlayerManager.GetDiamonds();

        CoinsManager();
        StepsManager();
        LivesManager();
        DiamondsManager();
    }

    private void CoinsManager()
    {
        textNumCoins.text = "" + numCoins;
    }

    private void StepsManager()
    {
        textNumSteps.text = "" + numSteps;
    }

    private void LivesManager()
    {
        if (numLives == 0)
        {
            imageLife.SetActive(false);
            imageLife1.SetActive(false);
            imageLife2.SetActive(false);
            imageLife3.SetActive(false);
            imageNoLife.SetActive(true);
            imageNoLife1.SetActive(true);
            imageNoLife2.SetActive(true);
        }
        else if (numLives == 1)
        {
            imageLife.SetActive(true);
            imageLife1.SetActive(false);
            imageLife2.SetActive(false);
            imageLife3.SetActive(false);
            imageNoLife.SetActive(false);
            imageNoLife1.SetActive(true);
            imageNoLife2.SetActive(true);
        }
        else if (numLives == 2)
        {
            imageLife.SetActive(true);
            imageLife1.SetActive(true);
            imageLife2.SetActive(false);
            imageLife3.SetActive(false);
            imageNoLife.SetActive(false);
            imageNoLife1.SetActive(false);
            imageNoLife2.SetActive(true);
        }
        else if (numLives == 3)
        {
            imageLife.SetActive(true);
            imageLife1.SetActive(true);
            imageLife2.SetActive(true);
            imageLife3.SetActive(false);
            imageNoLife.SetActive(false);
            imageNoLife1.SetActive(false);
            imageNoLife2.SetActive(false);
        }
        else if (numLives >= 4)
        {
            imageLife.SetActive(true);
            imageLife1.SetActive(true);
            imageLife2.SetActive(true);
            imageLife3.SetActive(true);
            imageNoLife.SetActive(false);
            imageNoLife1.SetActive(false);
            imageNoLife2.SetActive(false);
        }
    }

    private void DiamondsManager()
    {
        if (numDiamonds == 0)
        {
            imageDiamond.SetActive(false);
            imageDiamond1.SetActive(false);
            imageDiamond2.SetActive(false);
            imageNoDiamond.SetActive(true);
            imageNoDiamond1.SetActive(true);
            imageNoDiamond2.SetActive(true);
        }
        else if (numDiamonds == 1)
        {
            imageDiamond.SetActive(false);
            imageDiamond1.SetActive(false);
            imageDiamond2.SetActive(true);
            imageNoDiamond.SetActive(true);
            imageNoDiamond1.SetActive(true);
            imageNoDiamond2.SetActive(false);
        }
        else if (numDiamonds == 2)
        {
            imageDiamond.SetActive(false);
            imageDiamond1.SetActive(true);
            imageDiamond2.SetActive(true);
            imageNoDiamond.SetActive(true);
            imageNoDiamond1.SetActive(false);
            imageNoDiamond2.SetActive(false);
        }
        else if (numDiamonds == 3)
        {
            imageDiamond.SetActive(true);
            imageDiamond1.SetActive(true);
            imageDiamond2.SetActive(true);
            imageNoDiamond.SetActive(false);
            imageNoDiamond1.SetActive(false);
            imageNoDiamond2.SetActive(false);
        }
    }
}
