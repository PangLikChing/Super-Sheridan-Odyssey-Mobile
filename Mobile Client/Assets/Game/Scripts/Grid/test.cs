using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is a component for testing only
/// </summary>
public class test : MonoBehaviour
{
    GridSystem gridSystem;
    [SerializeField] Vector2 origin;
    [SerializeField] float cellSize = 0;
    [SerializeField] Item spawnItem, waterItem;
    [SerializeField] Map map;

    void Start()
    {
        // Initialize
        gridSystem = new GridSystem(map.width, map.height, cellSize, origin);

        #region Initialize map
        // Initalize the background water
        // For every column
        for (int x = 0; x < map.width; x++)
        {
            // For every row
            for (int y = 0; y < map.height; y++)
            {
                // The position is at the middle of the grid
                // grid's world position * grid size * that item's grid width / height / 2
                Instantiate(waterItem.art2dPrefeb,
                    new Vector3(gridSystem.GetWorldPosition(x, y).x + gridSystem.gridSize * spawnItem.gridWidth * 0.5f, gridSystem.GetWorldPosition(x, y).y + gridSystem.gridSize * spawnItem.gridHeight * 0.5f, 0),
                    Quaternion.identity
                );
            }
        }

        // Initialize the tiles and items on the map
        // For every grid that has a item in the map scripable object
        for (int i = 0; i < map.gridCoord.Length; i++)
        {
            try
            {
                // If that item is a tile
                if (map.gridTile[i].isTile == true)
                {
                    // The position is at the middle of the grid
                    // grid's world position * grid size * that item's grid width / height / 2
                    Instantiate(map.gridTile[i].art2dPrefeb,
                        new Vector3(gridSystem.GetWorldPosition(map.gridCoord[i].x, map.gridCoord[i].y).x + gridSystem.gridSize * spawnItem.gridWidth * 0.5f, gridSystem.GetWorldPosition(map.gridCoord[i].x, map.gridCoord[i].y).y + gridSystem.gridSize * spawnItem.gridHeight * 0.5f, 0),
                        Quaternion.identity
                    );

                    // Set that grid's value to 1
                    gridSystem.SetGridValue(map.gridCoord[i].x, map.gridCoord[i].y, 1);
                }
                // If the item is not a tile
                else
                {
                    // The position is at the middle of the grid
                    // grid's world position * grid size * that item's grid width / height / 2
                    Instantiate(map.gridTile[i].art2dPrefeb,
                        new Vector3(gridSystem.GetWorldPosition(map.gridCoord[i].x, map.gridCoord[i].y).x + gridSystem.gridSize * spawnItem.gridWidth * 0.5f, gridSystem.GetWorldPosition(map.gridCoord[i].x, map.gridCoord[i].y).y + gridSystem.gridSize * spawnItem.gridHeight * 0.5f, 0),
                        Quaternion.identity
                    );
                }
            }
            catch (Exception e)
            {
                // Throw a debug message
                Debug.Log(e);

                // Break out of the loop
                break;
            }
        }
        #endregion
    }

    void Update()
    {
        #region Can keep this part on the real script

        // When the left mouse button is clicked
        if (Input.GetMouseButtonDown(0))
        {
            // Initialize 2 temp ints
            int x = -1, y = -1;

            // Initilaize temp bool
            bool canBuild = true;

            // Cache the mouse current position
            Vector3 currentMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Get the grid position that the player is targeting
            gridSystem.GetGridXY(currentMousePosition, out x, out y);

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

                // If that item is a tile
                if (spawnItem.isTile == true)
                {
                    // The position is at the middle of the grid
                    // grid's world position * grid size * that item's grid width / height / 2
                    Instantiate(spawnItem.art2dPrefeb,
                        new Vector3(gridSystem.GetWorldPosition(x, y).x + gridSystem.gridSize * spawnItem.gridWidth * 0.5f, gridSystem.GetWorldPosition(x, y).y + gridSystem.gridSize * spawnItem.gridHeight * 0.5f, 0),
                        Quaternion.identity
                    );

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
                    Instantiate(spawnItem.art2dPrefeb,
                        new Vector3(gridSystem.GetWorldPosition(x, y).x + gridSystem.gridSize * spawnItem.gridWidth * 0.5f, gridSystem.GetWorldPosition(x, y).y + gridSystem.gridSize * spawnItem.gridHeight * 0.5f, 0),
                        Quaternion.identity
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
                Debug.Log($"Cannot build here dude. There is something in the way");
            }
        }
        // When the right mouse button is clicked
        if (Input.GetMouseButtonDown(1))
        {
            // Get the targeted grid's value
            Debug.Log(gridSystem.GetValueWithMouse(Camera.main.ScreenToWorldPoint(Input.mousePosition)));
        }

        #endregion
    }
}
