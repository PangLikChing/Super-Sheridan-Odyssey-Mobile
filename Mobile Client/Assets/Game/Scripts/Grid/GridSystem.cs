using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Grid system's base class
/// </summary>
public class GridSystem
{
    // width is the amount of columns that the grid map has
    // height is the amount of rows that the grid map has
    // gridsize is the actual size of a grid in terms of the world
    private int width, height;
    public float gridSize;
    private Vector3 origin;

    // if the int is 0, it means there is nothing there
    // if the int is 1, it means there is a tile there
    // if the int is 2, it means there is a pickup there
    private int[,] gridArray;

    //debug
    private TextMesh[,] debugTextArray;
    //debug

    public GridSystem(int width, int height, float gridSize, Vector2 origin)
    {
        // Initialize
        this.width = width;
        this.height = height;
        this.gridSize = gridSize;
        this.origin = origin;
        gridArray = new int[width, height];
    }

    public Vector2 GetWorldPosition(int x, int y)
    {
        // x, y times gridSize + origin's position
        return new Vector3(x * gridSize, y * gridSize) + origin;
    }

    // Method to convert world position to grid position
    public void GetGridXZ(Vector3 worldPosition, out int x, out int z)
    {
        // If grid size is 10, origin at (0, 0), world position (5, 5) will be in grid (0, 0)
        x = Mathf.FloorToInt((worldPosition - origin).x / gridSize);
        z = Mathf.FloorToInt((worldPosition - origin).z / gridSize);
    }

    public void SetValueWithMouse(Vector2 worldPosition, int value)
    {
        // intialize temp ints
        int x, z;

        // Get the x and y grid position
        GetGridXZ(worldPosition, out x, out z);

        // Set the grid's value
        SetGridValue(x, z, value);
    }

    public void SetGridValue(int x, int y, int value)
    {
        // Check if the value is valid
        // If x and y is positive
        // If x or y is bigger than there max value
        if (x >= 0 && y >= 0 && x < width && y < height)
        {
            // Set the value to that grid
            gridArray[x, y] = value;

            //debug
            //debugTextArray[x, y].text = gridArray[x, y].ToString();
            //debug
        }
    }

    public int GetValueWithMouse(Vector2 worldPosition)
    {
        // Intialize temp ints
        int x, z;

        // Get the x and y grid position
        GetGridXZ(worldPosition, out x, out z);

        // Return that grid's value
        return GetGridValue(x, z);
    }

    public int GetGridValue(int x, int z)
    {
        // Check if the value is valid
        // If x and y is positive
        // If x or y is bigger than there max value
        if (x >= 0 && z >= 0 && x < width && z < height)
        {
            // Return the value from that grid
            return gridArray[x, z];
        }
        else
        {
            // Error
            return -1;
        }
    }
}
