using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Item : ScriptableObject
{
    public string name = "";

    public Transform art2dPrefeb;

    public int gridWidth = 0;

    public int gridHeight = 0;

    public List<Vector2Int> GetAllOccupiedGrid(Vector2Int origin)
    {
        // Initialize a temp List
        List<Vector2Int> occupiedGrid = new List<Vector2Int>();

        // For every grid on the x axis
        for (int x = 0; x < gridWidth; x++)
        {
            // For every grid on the y axis
            for (int y = 0; y < gridHeight; y++)
            {
                // Add that grid
                occupiedGrid.Add(origin + new Vector2Int(x, y));
            }
        }

        // Return the temp list
        return occupiedGrid;
    }
}
