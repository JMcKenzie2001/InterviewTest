using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// Used for storing Temporary data
/// </summary>
public static class GameData
{

    [SerializeField] TMP_Text pizzaCollectedTxt;
    [SerializeField] TMP_Text starCollectedTxt;

    public static int pizzasCollected = 0;
    public static int starsCollected = 0;

    public static bool isPaused = true;

    void Update()
    {
        pizzaCollectedTxt.text = pizzasCollected.ToString();
        starCollectedTxt.text = starsCollected.ToString();
    }

    public static void ResetData()
    {
        pizzasCollected = 0;
        starsCollected = 0;
        pizzaCollectedTxt.text = pizzasCollected.ToString();
        starCollectedTxt.text = starsCollected.ToString();
    }
}
