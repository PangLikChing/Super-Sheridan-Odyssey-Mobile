using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    Quaternion rotation;

    void Start()
    {
        // Grab the initial rotation
        rotation = transform.rotation;
    }

    void LateUpdate()
    {
        // Return to original rotation
        transform.rotation = rotation;
    }
}
