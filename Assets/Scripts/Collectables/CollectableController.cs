using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CollectableController : MonoBehaviour
{
    //[SerializeField] private int numCoins;
    //[SerializeField] private TextMeshProUGUI textNumCoins;

    public static int numCoins;
    public TextMeshProUGUI textNumCoins;

    void Update()
    {
        textNumCoins.text = "" + numCoins;
    }

    public int GetNumCoins()
    {
        return numCoins;
    }

    public void SetNumCoins(int n)
    {
        numCoins = n;
    }

}
