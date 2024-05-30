using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    [Header("Audio")]
    [SerializeField] private AudioSource audioSource;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            audioSource.Play();
            gameObject.GetComponent<BoxCollider>().enabled = false;
            PlayerManager.Instance.CollisionManager();
        }
    }
}
