using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBoundary : MonoBehaviour
{
    [SerializeField] public static float leftSide = -3.5f;
    [SerializeField] public static float rightSide = 3.5f;
    [SerializeField] private float internalLeft;
    [SerializeField] private float internalRiht;

    // Update is called once per frame
    void Update()
    {
        internalLeft = leftSide;
        internalRiht = rightSide;
    }
}
