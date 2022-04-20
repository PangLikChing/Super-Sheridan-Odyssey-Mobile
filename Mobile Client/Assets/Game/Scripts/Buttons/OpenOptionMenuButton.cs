using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class OpenOptionMenuButton : MonoBehaviour
{
    [SerializeField] GameObject optionMenuBackground;

    public void OpenOptionMenu()
    {
        // Disable the menu button
        gameObject.GetComponent<Button>().interactable = false;

        // Set optionMenuBackground to active
        optionMenuBackground.SetActive(true);
    }
}
