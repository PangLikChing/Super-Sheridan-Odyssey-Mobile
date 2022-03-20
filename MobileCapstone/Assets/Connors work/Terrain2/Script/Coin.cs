using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int coinValue;
    public LevelManager levelManager;

    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        levelManager.KeepScore(coinValue);
    }
}
