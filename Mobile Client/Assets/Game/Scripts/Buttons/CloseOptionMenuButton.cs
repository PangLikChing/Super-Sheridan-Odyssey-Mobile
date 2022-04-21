using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseOptionMenuButton : MonoBehaviour
{
    [SerializeField] GameObject optionMenuBackground;
    [SerializeField] Button openOptionMenuButton;

    public void CloseOptionMenu()
    {
        // Enable the menu button
        openOptionMenuButton.GetComponent<Button>().interactable = true;

        // Set optionMenuBackground to inactive
        optionMenuBackground.SetActive(false);
    }
}
