using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform theOtherPad;
    private bool teleported = false;
    private AudioSource teleportAudioSource;

    void Start()
    {
        teleportAudioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!teleported)
        {
            other.transform.position = theOtherPad.position + Vector3.up;
            teleported = true;
            teleportAudioSource.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        teleported = false;
    }
}
