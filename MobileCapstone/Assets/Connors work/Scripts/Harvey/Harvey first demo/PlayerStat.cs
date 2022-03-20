using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

/// <summary>
/// This script is for managing player's stat
/// </summary>

public class PlayerStat : MonoBehaviour
{
    public float maxHealth = 3;
    [SerializeField] float currentHealth;
    public bool isDead;
    public UnityEvent PlayerDead;
    public Transform respawnPoint;

    private GameObject playerAvatar;

    public Slider healthInsance;

    private AudioSource damageSoundSource;
    public AudioClip damageSoundClip;

    //private LevelManager levelManager;

    void Start()
    {
        // Initialize
        maxHealth = 3;
        currentHealth = maxHealth;
        playerAvatar = transform.GetChild(0).gameObject;
        damageSoundSource = GetComponent<AudioSource>();
        damageSoundSource.clip = damageSoundClip;
    }

    public void TakeDamage(float damage)
    {
        damageSoundSource.Play();
        // Player takes the damage
        //healthInsance = levelManager.GetHealthSliderInstance();
        currentHealth -= damage;
        healthInsance.value = currentHealth;
        Debug.Log("current health: " + currentHealth);

        // If the remaining health is less than or equal to 0
        if (currentHealth <= 0)
        {
            // Player is dead
            isDead = true;
            PlayerDead.Invoke();
            Debug.Log("Ah! I am dead!");

        }
    }

    public void Respawn()
    {
        isDead = false;
        currentHealth = maxHealth;
        //healthInsance = levelManager.GetHealthSliderInstance();
        healthInsance.value = currentHealth;
        playerAvatar.transform.position = respawnPoint.position+1.3f*Vector3.up;
        playerAvatar.transform.rotation = Quaternion.identity;
        playerAvatar.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        playerAvatar.GetComponent<PlayerController>().enabled = true;
    }
}
