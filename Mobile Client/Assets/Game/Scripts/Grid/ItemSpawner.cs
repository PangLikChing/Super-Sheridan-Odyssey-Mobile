using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using Photon.Pun;

/// <summary>
/// This is a component for spawning items with mouse release
/// </summary>

public class ItemSpawner: MonoBehaviour
{
    GridSystem gridSystem;
    PlayerInput inputActions;

    [HideInInspector] public Item spawnItem;

    [SerializeField] SpawnMap spawnMap;
    [SerializeField] Camera mainCamera;
    [SerializeField] Image itemImage;

    void Awake()
    {
        // Initialize
        inputActions = new PlayerInput();
    }

    // Safety messure to ensure that the input will go through when the scene is active
    void OnEnable()
    {
        inputActions.Enable();
    }

    // Safety messure to ensure that the input won't go through when the scene isn't active
    void OnDisable()
    {
        inputActions.Disable();
    }

    void Start()
    {
        // Grab the gridSystem from SpawnMap
        gridSystem = spawnMap.gridSystem;
    }

    void Update()
    {
        #region Can keep this part on the real script

        // Read the touch input
        TouchState touchState = inputActions.MobileInput.Touch0.ReadValue<TouchState>();

        // Get the current mouse position
        Vector2 mousePos = inputActions.MobileInput.Touch0.ReadValue<TouchState>().position;

        switch (touchState.phase)
        {
            // If the touch begins
            case UnityEngine.InputSystem.TouchPhase.Began:

                // If there is a spawnItem
                if (spawnItem != null)
                {
                    // Set the sprite for the tile
                    itemImage.sprite = spawnItem.art2dPrefeb.GetChild(0).GetComponent<SpriteRenderer>().sprite;

                    // Set the alpha to 255 to "show" the image
                    itemImage.color = new Color(itemImage.color.r, itemImage.color.g, itemImage.color.b, 0.5f);
                }
                else
                {
                    // Reset the sprite for the tile
                    itemImage.sprite = null;

                    // Set the alpha to 0 to "hide" the image
                    itemImage.color = new Color(itemImage.color.r, itemImage.color.g, itemImage.color.b, 0);
                }

                // Set the Image position to where the mouse is at
                itemImage.rectTransform.position = mousePos;

                // Set the item Image to true
                itemImage.gameObject.SetActive(true);

                break;

            // If the touch is moving
            case UnityEngine.InputSystem.TouchPhase.Moved:

                // Set the Image position to where the mouse is at
                itemImage.rectTransform.position = mousePos;

                break;

            // If the touch is finished
            case UnityEngine.InputSystem.TouchPhase.Ended:

                // if I have a spawnItem
                if (spawnItem != null)
                {
                    // Initialize 2 temp ints
                    int x = -1, y = -1;

                    // Initilaize temp bool
                    bool canBuild = true;

                    // Cache the mouse current position
                    Vector3 currentMousePosition = Camera.main.ScreenToWorldPoint(inputActions.MobileInput.Touch0.ReadValue<TouchState>().position);

                    // Get the grid position that the player is targeting
                    gridSystem.GetGridXZ(currentMousePosition, out x, out y);

                    Debug.Log(currentMousePosition);

                    // Get the list that the item will occupy
                    List<Vector2Int> occupiedGrid = spawnItem.GetAllOccupiedGrid(new Vector2Int(x, y));

                    // For every grid in the grids that are going to be occupied
                    for (int i = 0; i < occupiedGrid.Count; i++)
                    {
                        // If the item is a tile
                        if (spawnItem.isTile == true)
                        {
                            // If any of them has a value of 1 aka there is a tile there or the player is not targeting an spot out of the grid
                            if (gridSystem.GetGridValue(occupiedGrid[i].x, occupiedGrid[i].y) == 1 || gridSystem.GetGridValue(occupiedGrid[i].x, occupiedGrid[i].y) < 0)
                            {
                                // Set canBuild to false
                                canBuild = false;
                            }
                        }
                        // If the item is not a tile
                        else
                        {
                            // If any of them has a value less than 1 aka there is nothing there
                            if (gridSystem.GetGridValue(occupiedGrid[i].x, occupiedGrid[i].y) < 1)
                            {
                                // Set canBuild to false
                                canBuild = false;
                            }
                        }
                    }

                    // If the grids are buildable
                    if (canBuild)
                    {
                        // Put down the object
                        Debug.Log(new Vector3(gridSystem.GetWorldPosition(x, y).x + gridSystem.gridSize * spawnItem.gridWidth * 0.5f, 0, gridSystem.GetWorldPosition(x, y).y + gridSystem.gridSize * spawnItem.gridHeight * 0.5f));

                        // If that item is a tile
                        if (spawnItem.isTile == true)
                        {

                            // The position is at the middle of the grid
                            // grid's world position * grid size * that item's grid width / height / 2
                            Transform spawnedItem = Instantiate(spawnItem.art2dPrefeb,
                                new Vector3(gridSystem.GetWorldPosition(x - gridSystem.origin.x / gridSystem.gridSize, y - gridSystem.origin.y / gridSystem.gridSize).x + gridSystem.gridSize * spawnItem.gridWidth * 0.5f, 0, gridSystem.GetWorldPosition(x - gridSystem.origin.x / gridSystem.gridSize, y - gridSystem.origin.y / gridSystem.gridSize).y + gridSystem.gridSize * spawnItem.gridHeight * 0.5f),
                                Quaternion.Euler(90, 0, 0)
                            );

                            // Save the occupying transform
                            gridSystem.occupyingItemArray[x, y] = spawnedItem;

                            // For every occupying grid
                            for (int j = 0; j < occupiedGrid.Count; j++)
                            {
                                // Change the grid's value to 1
                                gridSystem.SetGridValue(occupiedGrid[j].x, occupiedGrid[j].y, 1);
                            }
                        }
                        else
                        {
                            // The position is at the middle of the grid
                            // grid's world position * grid size * that item's grid width / height / 2
                            PhotonNetwork.Instantiate(spawnItem.art2dPrefeb.name,
                                new Vector3(gridSystem.GetWorldPosition(x - gridSystem.origin.x / gridSystem.gridSize, y - gridSystem.origin.y / gridSystem.gridSize).x + gridSystem.gridSize * spawnItem.gridWidth * 0.5f, 0, gridSystem.GetWorldPosition(x - gridSystem.origin.x / gridSystem.gridSize, y - gridSystem.origin.y / gridSystem.gridSize).y + gridSystem.gridSize * spawnItem.gridHeight * 0.5f),
                                Quaternion.Euler(90, 0, 0)
                            );

                            // For every occupying grid
                            for (int j = 0; j < occupiedGrid.Count; j++)
                            {
                                // Change the grid's value to 2
                                gridSystem.SetGridValue(occupiedGrid[j].x, occupiedGrid[j].y, 2);
                            }
                        }
                    }
                    // Else
                    else
                    {
                        // Throw a cannot build error message
                        Debug.Log($"Cannot build here dude.");
                    }

                    // Reset spawnItem to null
                    spawnItem = null;
                }

                // Hide the itemImage
                itemImage.gameObject.SetActive(false);

                break;

            // If the touch is canceled due to events such as force quit
            case UnityEngine.InputSystem.TouchPhase.Canceled:

                break;
        }

        // Debug
        //// When the right mouse button is clicked
        //if (Input.GetMouseButtonDown(1))
        //{
        //    // Get the targeted grid's value
        //    Debug.Log(gridSystem.GetValueWithMouse(Camera.main.ScreenToWorldPoint(Input.mousePosition)));
        //}
        // Debug
        #endregion
    }
}
