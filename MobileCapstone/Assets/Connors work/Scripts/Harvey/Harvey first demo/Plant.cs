using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script is responsible for the plants' behaviour in the game scene
/// </summary>

public class Plant : MonoBehaviour
{
    // Initialize
    int health = 1;
    [SerializeField] float attackDistance = 10, bobyHitDamage = 1, attackInterval = 2;
    [SerializeField] Transform player, bulletPile;
    private float attackTimer = 0;

    private AudioSource plantShootSource;
    public AudioClip plantShootClip;

    private GameObject bulletPileObject;
    private GameObject playerObject;
    void Start()
    {
        // Initialize the stat at start
        health = 1;

        plantShootSource = GetComponent<AudioSource>();

        bulletPileObject = GameObject.Find("Bullet Pile");
        playerObject = GameObject.Find("Player Avatar");

        player = playerObject.transform;
        bulletPile = bulletPileObject.transform;
    }

    void FixedUpdate()
    {
        transform.LookAt(player);

        // Calculate the distance between the player and this walking enemy
        float distance = Vector3.Distance(player.position, transform.position);

        // If the distance between the player and this plant is less than the attacking distance and it's over the attack timer
        if (distance <= attackDistance && attackTimer >= attackInterval&& !player.transform.parent.GetComponent<PlayerStat>().isDead)
        {
            // Shoot the bullet
            Attack();
            // Reset the attack timer
            attackTimer = 0;
        }

        attackTimer += Time.deltaTime;
    }

    // Attacking
    void OnCollisionEnter(Collision collision)
    {
        // If the enemy hits the player
        if (collision.gameObject.GetComponent<PlayerStat>() != null)
        {
            // Player takes bobyHitDamage amount of damage
            gameObject.GetComponent<PlayerStat>().TakeDamage(bobyHitDamage);
        }
    }

    // Function to attack
    void Attack()
    {
        plantShootSource.clip = plantShootClip;
        plantShootSource.Play();

        // If the plant doesn't have any bullet
        if (transform.childCount == 0)
        {
            // Refill the bullet
            // If bulletPile still has bullet
            if (bulletPile.childCount != 0)
            {
                // Get a bullet from the bullet pile
                bulletPile.GetChild(0).transform.SetParent(gameObject.transform);
            }
        }

        // Shot the first bullet
        transform.GetChild(0).gameObject.SetActive(true);
        // Set the parent of that bullet to the bullet pile
        transform.GetChild(0).SetParent(bulletPile);
    }
}
