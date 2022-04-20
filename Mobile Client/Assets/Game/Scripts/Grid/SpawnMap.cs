using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is a component for creating the grid map on awake and spawning the game map at start
/// </summary>

public class SpawnMap : MonoBehaviour
{
    [HideInInspector] public GridSystem gridSystem;

    [SerializeField] Map map;
    [SerializeField] Vector2 origin;
    [SerializeField] float cellSize = 0;
    [SerializeField] Item waterItem;

    void Awake()
    {
        // Initialize
        gridSystem = new GridSystem(map.width, map.height, cellSize, origin);
    }
    void Start()
    {
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
                    new Vector3(gridSystem.GetWorldPosition(x, y).x + gridSystem.gridSize * waterItem.gridWidth * 0.5f, 0, gridSystem.GetWorldPosition(x, y).y + gridSystem.gridSize * waterItem.gridHeight * 0.5f),
                    Quaternion.Euler(90, 0, 0)
                );
            }
        }

        // Initialize the tiles and items on the map
        // For every grid that has a item in the map scripable object
        for (int i = 0; i < map.gridCoord.Length; i++)
        {
            try
            {
                // Cache the currentTile and currentTileCoord from the map
                Item currentTile = map.gridTile[i];
                Vector2Int currentTileCoord = map.gridCoord[i];

                // If that item is a tile
                if (currentTile.isTile == true)
                {
                    // The position is at the middle of the grid
                    // grid's world position * grid size * that item's grid width / height / 2
                    Instantiate(currentTile.art2dPrefeb,
                        new Vector3(gridSystem.GetWorldPosition(currentTileCoord.x, currentTileCoord.y).x + gridSystem.gridSize * currentTile.gridWidth * 0.5f, 0, gridSystem.GetWorldPosition(currentTileCoord.x, currentTileCoord.y).y + gridSystem.gridSize * currentTile.gridHeight * 0.5f),
                        Quaternion.Euler(90, 0, 0)
                    );

                    // Set that grid's value to 1
                    gridSystem.SetGridValue(currentTileCoord.x, currentTileCoord.y, 1);
                }
                // If the item is not a tile
                else
                {
                    // The position is at the middle of the grid
                    // grid's world position * grid size * that item's grid width / height / 2
                    Instantiate(map.gridTile[i].art2dPrefeb,
                        new Vector3(gridSystem.GetWorldPosition(currentTileCoord.x, currentTileCoord.y).x + gridSystem.gridSize * currentTile.gridWidth * 0.5f, 0, gridSystem.GetWorldPosition(currentTileCoord.x, currentTileCoord.y).y + gridSystem.gridSize * currentTile.gridHeight * 0.5f),
                        Quaternion.Euler(90, 0, 0)
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
}
