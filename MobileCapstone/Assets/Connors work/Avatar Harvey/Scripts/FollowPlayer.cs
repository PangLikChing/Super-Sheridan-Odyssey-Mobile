using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script is responsible for the camera following the player
/// </summary>

[RequireComponent(typeof(Camera))]
public class FollowPlayer : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] Vector3 CameraInitialPosition;

    void Update()
    {
        transform.position = Player.transform.position + CameraInitialPosition;
    }
}
