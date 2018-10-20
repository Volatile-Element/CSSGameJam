using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Customer : MonoBehaviour
{
    public UnityEventFor<float> OnSuspicionChange = new UnityEventFor<float>();

    private const float ANIMATION_TIME = 3;

    public bool LookingAwayFromPlate { get; set; }
    public float SuspicionPercentage { get; set; }

    private int foodItemsToBeShockedAbout = 0;

    private void Start()
    {
        StartCoroutine(RandomlyLookAway());
        StartCoroutine(CheckPlayerDistance());
    }

    public void FoodItemTaken()
    {
        if (!LookingAwayFromPlate)
        {
            Debug.Log("Stealing Unsuccessful");

            SceneManager.LoadSceneAsync("Game View");

            return;
        }

        foodItemsToBeShockedAbout++;

        Debug.Log("Successfully Stolen");
    }

    public void LookAwayFromPlate()
    {
        if (LookingAwayFromPlate)
        {
            return;
        }

        StartCoroutine(LookAwayFromPlateCoroutine());
    }

    public void ChangeSuspicion(float amount)
    {
        SuspicionPercentage += amount;

        if (SuspicionPercentage < 0)
        {
            SuspicionPercentage = 0;
        }

        if (SuspicionPercentage > 100)
        {
            SuspicionPercentage = 100;
        }

        OnSuspicionChange.Invoke(SuspicionPercentage);
    }

    private IEnumerator LookAwayFromPlateCoroutine()
    {
        LookingAwayFromPlate = true;

        GetComponentInChildren<DEBUG_SetHeadRotation>().LookAway();

        yield return new WaitForSeconds(ANIMATION_TIME);
        
        GetComponentInChildren<DEBUG_SetHeadRotation>().ResetHead();

        LookingAwayFromPlate = false;

        ChangeSuspicion(foodItemsToBeShockedAbout * 10);
        foodItemsToBeShockedAbout = 0;
    }

    private IEnumerator RandomlyLookAway()
    {
        yield return new WaitForSeconds(Random.Range(0, 60));

        if (LookingAwayFromPlate)
        {
            StartCoroutine(RandomlyLookAway());

            yield return null;
        }

        StartCoroutine(LookAwayFromPlateCoroutine());

        yield return new WaitForSeconds(ANIMATION_TIME);

        StartCoroutine(RandomlyLookAway());
    }

    private IEnumerator CheckPlayerDistance()
    {
        var player = FindObjectOfType<Interactor>();

        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            
            if (Vector3.Distance(transform.position, player.transform.position) < 5)
            {
                if (LookingAwayFromPlate)
                {
                    continue;
                }

                ChangeSuspicion(5);
            }
            else
            {
                ChangeSuspicion(-2.5f);
            }
        }
    }
}