using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerController : MonoBehaviour
{
    public IList<BasePower> Powers { get; set; }

    private void Awake()
    {
        Powers = GetPowers();
    }
    
	// Update is called once per frame
	void Update ()
    {
		for (int i = 0; i < Powers.Count; i++)
        {
            if (Input.GetKeyDown((KeyCode)(49 + i)))
            {
                if (Powers[i].CanUse())
                {
                    Powers[i].UsePower();
                }
            }
        }
	}

    private IList<BasePower> GetPowers()
    {
        var powersContainer = new GameObject("Powers Container");
        powersContainer.transform.SetParent(transform);

        return new List<BasePower>
        {
            powersContainer.AddComponent<LookAwayPower>()
        };
    }
}