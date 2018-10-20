using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAwayPower : BasePower
{
    public Camera Camera;

    public override string Name { get; set; } = "Distract 1";
    public override float UseCost { get; set; } = 5;
    public override float RechargeAmount { get; set; } = 10;

    private void Awake()
    {
        Camera = FindObjectOfType<Interactor>().GetComponent<Camera>();
    }

    public override void UsePower()
    {
        var customer = LookForCustomer();

        if (customer == null)
        {
            Debug.Log("No hit customer");

            return;
        }

        Debug.Log("Hit customer");
        customer.LookAwayFromPlate();

        UseCharge();
    }

    public Customer LookForCustomer()
    {
        Ray ray = Camera.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        Debug.DrawRay(ray.origin, ray.direction * 5f, Color.blue);
        RaycastHit hit;
        var result = Physics.Raycast(ray, out hit, 5f);
        if (!result)
        {
            return null;
        }

        return hit.collider.gameObject.GetComponent<Customer>();
    }
}