using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassScript : MonoBehaviour
{

    private AudioSource grassAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        grassAudioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        grassAudioSource.Play();
    }
}
