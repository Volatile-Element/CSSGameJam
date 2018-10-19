using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Customer : MonoBehaviour
{
    public bool LookingAwayFromPlate { get; set; }

    public void FoodItemTaken()
    {
        if (!LookingAwayFromPlate)
        {
            
            Debug.Log("Stealing Unsuccessful");

            SceneManager.LoadSceneAsync("Game View");

            return;
        }

        Debug.Log("Successfully Stolen");
    }

    public void LookAwayFromPlate()
    {
        StartCoroutine(LookAwayFromPlateCoroutine());
    }

    private IEnumerator LookAwayFromPlateCoroutine()
    {
        LookingAwayFromPlate = true;

        yield return new WaitForSeconds(3);

        LookingAwayFromPlate = false;
    }
}