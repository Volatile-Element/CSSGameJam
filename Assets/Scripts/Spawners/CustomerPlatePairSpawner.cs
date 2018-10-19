using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CustomerPlatePairSpawner : Singleton<CustomerPlatePairSpawner>
{
    private void Start()
    {
        Spawn();
    }

    public void Spawn()
    {
        var customerMarkers = FindObjectsOfType<CustomerMarker>().ToList();
        var plateMarkers = FindObjectsOfType<PlateMarker>().ToList();

        while (customerMarkers.Count > 0)
        {
            var plateMarker = plateMarkers.FirstOrDefault(x => x.CustomerId == customerMarkers[0].PlateId);

            if (plateMarker == null)
            {
                customerMarkers.RemoveAt(0);

                continue;
            }

            var generatedCustomer = CustomerGenerator.Instance.Generate();
            var generatedPlate = PlateGenerator.Instance.Generate();

            var instantiatedCustomer = Instantiate(generatedCustomer, customerMarkers[0].transform.position, customerMarkers[0].transform.rotation);
            var instantiatedPlate = Instantiate(generatedPlate, plateMarker.transform.position, plateMarker.transform.rotation);

            foreach (var foodItemMarker in instantiatedPlate.GetComponentsInChildren<FoodItemMarker>())
            {
                var generatedFoodItem = FoodItemGenerator.Instance.Generate();
                var instantiatedFoodItem = Instantiate(generatedFoodItem, foodItemMarker.transform.position, foodItemMarker.transform.rotation);

                instantiatedFoodItem.transform.SetParent(instantiatedPlate.transform);
            }

            foreach (var interaction in instantiatedPlate.GetComponentsInChildren<OnInteractionNotifyCustomer>())
            {
                interaction.OwningCustomer = instantiatedCustomer.GetComponent<Customer>();
            }

            customerMarkers.RemoveAt(0);
        }
    }
}