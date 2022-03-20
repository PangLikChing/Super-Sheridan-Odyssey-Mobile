using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    public float damageValue = 1;
    private void OnTriggerEnter(Collider other)
    {
        PlayerStat stat = other.transform.parent.GetComponent<PlayerStat>();
        if (stat != null)
        {
            stat.TakeDamage(damageValue);
        }

    }
}
