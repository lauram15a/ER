using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesManager : MonoBehaviour
{
    [SerializeField] private GameObject imageLife;
    [SerializeField] private GameObject imageLife1;
    [SerializeField] private GameObject imageLife2;
    [SerializeField] private GameObject imageLife3;
    [SerializeField] private GameObject imageNoLife;
    [SerializeField] private GameObject imageNoLife1;
    [SerializeField] private GameObject imageNoLife2;

    [SerializeField] private int lives = 2;

    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        if (lives == 0)
        {
            imageLife.SetActive(false);
            imageLife1.SetActive(false);
            imageLife2.SetActive(false);
            imageLife3.SetActive(false);
            imageNoLife.SetActive(true);
            imageNoLife1.SetActive(true);
            imageNoLife2.SetActive(true);
        }
        else if (lives  == 1) 
        {
            imageLife.SetActive(true);
            imageLife1.SetActive(false);
            imageLife2.SetActive(false);
            imageLife3.SetActive(false);
            imageNoLife.SetActive(false);
            imageNoLife1.SetActive(true);
            imageNoLife2.SetActive(true);
        }
        else if (lives == 2)
        {
            imageLife.SetActive(true);
            imageLife1.SetActive(true);
            imageLife2.SetActive(false);
            imageLife3.SetActive(false);
            imageNoLife.SetActive(false);
            imageNoLife1.SetActive(false);
            imageNoLife2.SetActive(true);
        }
        else if (lives == 3)
        {
            imageLife.SetActive(true);
            imageLife1.SetActive(true);
            imageLife2.SetActive(true);
            imageLife3.SetActive(false);
            imageNoLife.SetActive(false);
            imageNoLife1.SetActive(false);
            imageNoLife2.SetActive(false);
        }
        else if (lives >= 4)
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


}
