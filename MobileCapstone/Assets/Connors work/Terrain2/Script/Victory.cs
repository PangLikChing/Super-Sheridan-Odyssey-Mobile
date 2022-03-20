using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Victory : MonoBehaviour
{
    public UnityEvent victory;
    public float bounceForce;
    private void OnCollisionEnter(Collision collision)
    {
        victory.Invoke();
    }
}
