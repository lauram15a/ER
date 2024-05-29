using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteSection : MonoBehaviour
{
    [Header("Section")]
    [SerializeField] private GameObject section;

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(section);
        }
    }
}
