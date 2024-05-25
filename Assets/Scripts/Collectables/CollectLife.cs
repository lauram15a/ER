using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectLife : MonoBehaviour
{
    [SerializeField] private AudioSource lifeFX;

    private void OnTriggerEnter(Collider other)
    {
        lifeFX.Play();
        gameObject.SetActive(false);
    }
}
