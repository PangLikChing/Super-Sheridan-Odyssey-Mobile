using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

/// <summary>
/// This is a component for identifying which item is selected by the player
/// </summary>

[RequireComponent(typeof(Button))]
public class TileButton : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] ItemSpawner itemSpawner;
    [SerializeField] Item holdItem;

    public void OnPointerDown(PointerEventData eventData)
    {
        // Set the spawnItem in itemSpawner to the holdItem
        // so that itemSpawner knows which item should it spawn
        itemSpawner.spawnItem = holdItem;
    }
}
