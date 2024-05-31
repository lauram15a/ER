using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverManager : CanvasManager
{
    [Header("Audio")]
    [SerializeField] private AudioSource gameOverAudioSource;
    [SerializeField] private bool isaudioPlaying = false;

    private void Update()
    {
        if (GameManager.IsGameOver())
        {
            PlayaudioSource();

            numSteps = PlayerManager.GetSteps();
            numCoins = PlayerManager.GetCoins();
            numDiamonds = PlayerManager.GetDiamonds();

            CoinsManager();
            StepsManager();
            DiamondsManager();
        }
    }

    private void PlayaudioSource()
    {
        if (!isaudioPlaying)
        {
            gameOverAudioSource.Play();
            isaudioPlaying = true;
        }
    }
}
