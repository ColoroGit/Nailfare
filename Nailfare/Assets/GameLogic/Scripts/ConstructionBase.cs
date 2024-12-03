using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ConstructionBase : MonoBehaviour
{
    public int amountOfBMats = 0;
    static int goalAmountOfBMats;

    // Start is called before the first frame update
    void Start()
    {
        goalAmountOfBMats = FindObjectsByType<BuildMatBehavior>(FindObjectsSortMode.None).Length;
        HUDManager.instance.UpdateRemainingPieces(goalAmountOfBMats);
    }
    
    public void CheckVictory()
    {
        HUDManager.instance.UpdateRemainingPieces(goalAmountOfBMats - amountOfBMats);

        if (amountOfBMats == goalAmountOfBMats)
        {
            HUDManager.instance.SetText("Felicidades, Terminaste tu construcción");
            StartCoroutine(QuitGameAfterDelay(3f));
        }
    }

    IEnumerator QuitGameAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Application.Quit();
    }
}
