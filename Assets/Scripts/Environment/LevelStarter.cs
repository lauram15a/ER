using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStarter : MonoBehaviour
{
    [Header("Canvas")]
    [SerializeField] private GameObject countDown3;
    [SerializeField] private GameObject countDown2;
    [SerializeField] private GameObject countDown1;
    [SerializeField] private GameObject countDownGo;
    [SerializeField] private GameObject fadeIn;
    [SerializeField] private GameObject ui;

    [Header("Audios")]
    [SerializeField] private AudioSource countdownAudioSource;
    [SerializeField] private AudioSource bgmAudioSource;    

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CountDownSequence());
    }

    private void Update()
    {
        if (PlayerManager.IsGameOver())
        {
            bgmAudioSource.Stop();
        }
    }

    IEnumerator CountDownSequence()
    {
        yield return new WaitForSeconds(1.5f);
        countDown3.SetActive(true);
        countdownAudioSource.Play();
        yield return new WaitForSeconds(1);

        countDown2.SetActive(true);
        countDown3.SetActive(false);
        yield return new WaitForSeconds(1);

        countDown1.SetActive(true);
        countDown2.SetActive(false);
        yield return new WaitForSeconds(1);

        countDownGo.SetActive(true);
        countDown1.SetActive(false);
        yield return new WaitForSeconds(1);

        PlayerManager.SetIsStarted(true);
        ui.SetActive(true);
        bgmAudioSource.Play();
    }
}
