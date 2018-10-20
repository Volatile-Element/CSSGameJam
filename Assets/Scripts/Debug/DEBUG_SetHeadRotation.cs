using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DEBUG_SetHeadRotation : MonoBehaviour
{
    public void ResetHead()
    {
        transform.Rotate(new Vector3(0, 180, 0));
    }

    public void LookAway()
    {
        transform.Rotate(new Vector3(0, 180, 0));
    }
}
