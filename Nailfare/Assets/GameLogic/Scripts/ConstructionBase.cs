using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstructionBase : MonoBehaviour
{
    public static int amountOfBMats = 0;
    static int goalAmountOfBMats;

    // Start is called before the first frame update
    void Start()
    {
        goalAmountOfBMats = FindObjectsByType<BuildMatBehavior>(FindObjectsSortMode.None).Length;
    }

    public static void CheckVictory()
    {
        if (amountOfBMats == goalAmountOfBMats)
        {
            // Victory
        }
    }
}
