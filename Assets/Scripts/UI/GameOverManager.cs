using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverManager : CanvasManager
{
    private void Update()
    {
        if (GameManager.IsGameOver())
        {
            numSteps = PlayerManager.GetSteps();
            numCoins = PlayerManager.GetCoins();
            numDiamonds = PlayerManager.GetDiamonds();

            CoinsManager();
            StepsManager();
            DiamondsManager();
        }
    }
}
