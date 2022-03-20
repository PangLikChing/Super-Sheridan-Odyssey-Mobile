using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class BreakOff : MonoBehaviour
{
    public float breakOffDelay = 2;
    private float breakOffCountDown;
    private Rigidbody rb;
    private bool isBreakingOff;

    public AudioClip woodCreekClip;
    private AudioSource woodCreekSource;

    private void Start()
    {
        isBreakingOff = false;
        breakOffCountDown = breakOffDelay;
        rb = GetComponent<Rigidbody>();
        woodCreekSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (isBreakingOff)
        {
            breakOffCountDown -= Time.deltaTime;
        }
        if (breakOffCountDown <= 0)
        {
            rb.useGravity = true;
            Destroy(gameObject,5);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isBreakingOff = true;
            woodCreekSource.clip = woodCreekClip;
            woodCreekSource.Play();
        }
    }
}
