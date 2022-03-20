using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowLost : MonoBehaviour
{
    public void OnGameOver()
    {
        gameObject.SetActive(true);
    }
}
