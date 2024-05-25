using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectSkull : MonoBehaviour
{
    [SerializeField] private AudioSource skullFX;

    private void OnTriggerEnter(Collider other)
    {
        skullFX.Play();
        gameObject.SetActive(false);
    }
}
