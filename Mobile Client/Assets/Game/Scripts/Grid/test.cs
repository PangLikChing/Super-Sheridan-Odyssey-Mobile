using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is a component for testing only
/// </summary>
public class test : MonoBehaviour
{
    GridSystem gridSystem;
    [SerializeField] Vector2 origin;

    void Start()
    {
        // test
        gridSystem = new GridSystem(4, 2, 10f, origin);
        // test
    }

    void Update()
    {
        // When the left mouse button is clicked
        if (Input.GetMouseButtonDown(0))
        {
            // Change the targeted grid's value
            gridSystem.SetValueWithMouse(Camera.main.ScreenToWorldPoint(Input.mousePosition), 1);
        }
        // When the right mouse button is clicked
        if (Input.GetMouseButtonDown(1))
        {
            // Get the targeted grid's value
            Debug.Log(gridSystem.GetValueWithMouse(Camera.main.ScreenToWorldPoint(Input.mousePosition)));
        }
    }
}
