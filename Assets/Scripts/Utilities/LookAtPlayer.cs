using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    Transform target;

    private void Start()
    {
        target = FindObjectOfType<Interactor>().transform;
    }

    private void FixedUpdate()
    {
        Vector3 targetPostition = new Vector3(target.position.x,
                                        this.transform.position.y,
                                        target.position.z);
        this.transform.LookAt(targetPostition);
    }
}