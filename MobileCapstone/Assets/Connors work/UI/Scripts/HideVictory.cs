using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideVictory : MonoBehaviour
{
    public void OnVictory()
    {
        gameObject.SetActive(false);
    }
}
