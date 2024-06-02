using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverManager : CanvasManager
{
    [Header("Personal Record")]
    [SerializeField] private TextMeshProUGUI personalStepsRecordText;
    [SerializeField] private TextMeshProUGUI personalCoinsRecordText;

    [Header("Audio")]
    [SerializeField] private AudioSource gameOverAudioSource;
    [SerializeField] private bool isAudioPlaying = false;

    private void Update()
    {
        if (GameManager.IsGameOver())
        {
            PlayAudioSource();

            numSteps = PlayerManager.GetSteps();
            numCoins = PlayerManager.GetCoins();
            numDiamonds = PlayerManager.GetDiamonds();

            StepsManager();
            CoinsManager();
            DiamondsManager();

            RecordManager.PersonalRecordManager();
            personalStepsRecordText.text = RecordManager.GetPersonalStepsRecord().ToString();
            personalCoinsRecordText.text = RecordManager.GetPersonalCoinsRecord().ToString();
        }
    }

    private void PlayAudioSource()
    {
        if (!isAudioPlaying)
        {
            gameOverAudioSource.Play();
            isAudioPlaying = true;
        }
    }
}
