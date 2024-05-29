using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevel : MonoBehaviour
{
    [SerializeField] private GameObject[] sections;
    [SerializeField] private int zPos = 50;
    [SerializeField] private int zVariation = 50;
    [SerializeField] private bool creatingSection = false;
    [SerializeField] private int sectionID;
    [SerializeField] private int numSections = 0;
    [SerializeField] private float generateLevelDelay;
    [SerializeField] private float normalGenerateLevelDelay = 5;
    [SerializeField] private float pauseGenerateLevelDelay = 20;

    // Update is called once per frame
    void Update()
    {
        if (!creatingSection)
        {
            creatingSection = true;
            StartCoroutine(GenerateSection());
        }
    }

    IEnumerator GenerateSection()
    {
        sectionID = Random.Range(0, sections.Length);
        Instantiate(sections[sectionID], new Vector3(0, 0, zPos), Quaternion.identity);
        zPos += zVariation;
        numSections++; 

        if (numSections % 5 == 0)
        {
            generateLevelDelay = pauseGenerateLevelDelay;
        }
        else
        {
            generateLevelDelay = normalGenerateLevelDelay;
        }

        yield return new WaitForSeconds(generateLevelDelay);
        creatingSection = false;
    }
}
