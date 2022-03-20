using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// This script is responsible for player movement
/// </summary>

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    Vector3 forward;
    Vector3 right;

    void Start()
    {
        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);

        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
    }

    void Update()
    {
        if(Input.anyKey)
        {
            Move();
        }
    }

    void Move()
    {
        Vector3 rightMovement = right * speed * Time.deltaTime * Input.GetAxis("Horizontal");

        Vector3 upMovement = forward * speed * Time.deltaTime * Input.GetAxis("Vertical");

        Vector3 heading = Vector3.Normalize(rightMovement + upMovement);
        //transform.forward = heading;
        transform.position += rightMovement;
        transform.position += upMovement; 
    }
}
