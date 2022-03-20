using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerStat stat = other.transform.parent.GetComponent<PlayerStat>();
        if (stat != null)
        {
            stat.TakeDamage(stat.maxHealth);
        }
    }
}
