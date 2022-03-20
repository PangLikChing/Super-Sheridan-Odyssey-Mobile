using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float mouseSensitivity = 500;
    public float speed = 5;
    public float jumpForce = 5;


    private float mouseX = 0;
    private float calibrateX = 0;
    private Rigidbody playerRb;

    AudioSource jumpSource;

    public AudioClip jumpClip;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        jumpSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime - calibrateX;
        //transform.Rotate(Vector3.up, mouseX);
        //transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * speed * Time.deltaTime);
        //transform.Translate(Vector3.forward * Input.GetAxis("Vertical") * speed * Time.deltaTime);
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        //    jumpSource.clip = jumpClip;
        //    jumpSource.Play();
        //}
    }

    public void Calibrate()
    {
        calibrateX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
    }

    public void OnDeath()
    {
        playerRb.constraints = RigidbodyConstraints.None;
        playerRb.AddForce(transform.forward, ForceMode.Impulse);
        this.enabled = false;
    }

    public void OnVictory()
    {
        this.enabled = false;
    }
}
