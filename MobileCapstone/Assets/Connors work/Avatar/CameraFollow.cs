using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset;
    public float cameraSpeed;

    private bool following;

    // Start is called before the first frame update
    void Start()
    {
        following = true;
        transform.position = player.transform.position + player.transform.rotation * Quaternion.AngleAxis(0, Vector3.up) * offset;
        transform.LookAt(player.transform);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (following)
        {
            transform.position = Vector3.Lerp(transform.position, player.transform.position + player.transform.rotation * Quaternion.AngleAxis(0, Vector3.up) * offset, cameraSpeed * Time.deltaTime);
            transform.LookAt(player.transform);
        }
        
    }

    public void OnDeath()
    {
        following = false;
    }

    public void OnRespawn()
    {
        following = true;
    }
}
