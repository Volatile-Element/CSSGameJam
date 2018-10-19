using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseGenerator<T> : Singleton<T> where T : MonoBehaviour
{
    public abstract string ResourceFolder { get; set; }

    public GameObject Generate()
    {
        var resources = Resources.LoadAll<GameObject>(ResourceFolder);

        return resources[Random.Range(0, resources.Length)];
    }
}