using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    [Header("Coins")]
    [SerializeField] protected TextMeshProUGUI textNumCoins;

    [Header("Steps")]
    [SerializeField] protected TextMeshProUGUI textNumSteps;

    [Header("Diamonds")]
    [SerializeField] protected GameObject imageDiamond;
    [SerializeField] protected GameObject imageDiamond1;
    [SerializeField] protected GameObject imageDiamond2;
    [SerializeField] protected GameObject imageNoDiamond;
    [SerializeField] protected GameObject imageNoDiamond1;
    [SerializeField] protected GameObject imageNoDiamond2;

    protected int numCoins;
    protected int numSteps;
    protected int numDiamonds;

    protected void CoinsManager()
    {
        textNumCoins.text = "" + numCoins;
    }

    protected void StepsManager()
    {
        textNumSteps.text = "" + numSteps;
    }
    protected void DiamondsManager()
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
