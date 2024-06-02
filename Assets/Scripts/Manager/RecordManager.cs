using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RecordManager : MonoBehaviour
{
    private static int numSteps;
    private static int numCoins;
    private static int personalStepsRecord;
    private static int personalCoinsRecord;

    public static void PersonalRecordManager()
    {
        numSteps = PlayerManager.GetSteps();
        numCoins = PlayerManager.GetCoins();

        LoadPersonalRecord();

        if (numSteps > personalStepsRecord)
        {
            personalStepsRecord = numSteps;
            SavePersonalStepsRecord();
        }
        if (numCoins > personalCoinsRecord)
        {
            personalCoinsRecord = numCoins;
            SavePersonalCoinsRecord();
        }
    }

    private static void SavePersonalStepsRecord()
    {
        PlayerPrefs.SetInt("personalStepsRecord", personalStepsRecord);
        PlayerPrefs.Save();
    }

    private static void SavePersonalCoinsRecord()
    {
        PlayerPrefs.SetInt("personalCoinsRecord", personalCoinsRecord);
        PlayerPrefs.Save();
    }

    private static void LoadPersonalRecord()
    {
        if (PlayerPrefs.HasKey("personalStepsRecord"))
        {
            personalStepsRecord = PlayerPrefs.GetInt("personalStepsRecord");
        }
        else
        {
            personalStepsRecord = 0; 
        }

        if (PlayerPrefs.HasKey("personalCoinsRecord"))
        {
            personalCoinsRecord = PlayerPrefs.GetInt("personalCoinsRecord");
        }
        else
        {
            personalCoinsRecord = 0;
        }
    }

    public void ResetPersonalRecord()
    {
        PlayerPrefs.DeleteKey("personalStepsRecord");
        PlayerPrefs.DeleteKey("personalCoinsRecord");
        personalStepsRecord = 0;
        personalCoinsRecord = 0;
    }

    #region Getters
    public static int GetPersonalStepsRecord()
    {
        return personalStepsRecord;
    }

    public static int GetPersonalCoinsRecord()
    {
        return personalCoinsRecord;
    }
    #endregion
}
