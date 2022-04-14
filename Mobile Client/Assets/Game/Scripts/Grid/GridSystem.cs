using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Grid system's base
/// </summary>
public class GridSystem
{
    // width is the amount of columns that the grid map has
    // height is the amount of rows that the grid map has
    // gridsize is the actual size of a grid in terms of the world
    private int width, height;
    public float gridSize;
    private Vector2 origin;

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

        //debug
        debugTextArray = new TextMesh[width, height];
        //debug

        // Loop through the x axis
        for (int x = 0; x < gridArray.GetLength(0); x++)
        {
            // Loop through the y axis
            for (int y = 0; y < gridArray.GetLength(1); y++)
            {
                //debug
                //debugTextArray[x, y] = CreateWorldText(Color.white, gridArray[x, y].ToString(), null, GetWorldPosition(x, y) + new Vector2(gridSize, gridSize) * 0.5f, 20, TextAnchor.MiddleCenter);
                Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x, y + 1), Color.black, 1000f);
                Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x + 1, y), Color.black, 1000f);
                //debug
            }
        }
        //debug
        Debug.DrawLine(GetWorldPosition(0, height), GetWorldPosition(width, height), Color.black, 1000f);
        Debug.DrawLine(GetWorldPosition(width, 0), GetWorldPosition(width, height), Color.black, 1000f);
        //debug
    }

    public Vector2 GetWorldPosition(int x, int y)
    {
        // x, y times gridSize + origin's position
        return new Vector2(x * gridSize, y * gridSize) + origin;
    }

    // Method to convert world position to grid position
    public void GetGridXY(Vector2 worldPosition, out int x, out int y)
    {
        // If grid size is 10, origin at (0, 0), world position (5, 5) will be in grid (0, 0)
        x = Mathf.FloorToInt((worldPosition - origin).x / gridSize);
        y = Mathf.FloorToInt((worldPosition - origin).y / gridSize);
    }

    public void SetValueWithMouse(Vector2 worldPosition, int value)
    {
        // intialize temp ints
        int x, y;

        // Get the x and y grid position
        GetGridXY(worldPosition, out x, out y);

        //debug
        Debug.Log($"x: {x}, y: {y}");
        //debug

        // Set the grid's value
        SetGridValue(x, y, value);
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
        int x, y;

        // Get the x and y grid position
        GetGridXY(worldPosition, out x, out y);

        // Return that grid's value
        return GetGridValue(x, y);
    }

    public int GetGridValue(int x, int y)
    {
        // Check if the value is valid
        // If x and y is positive
        // If x or y is bigger than there max value
        if (x >= 0 && y >= 0 && x < width && y < height)
        {
            // Return the value from that grid
            return gridArray[x, y];
        }
        else
        {
            // Error
            return -1;
        }
    }

    //debug
    public static TextMesh CreateWorldText(Color color, string text, Transform parent = null, Vector2 localPosition = default(Vector2), int fontSize = 40, TextAnchor textAnchor = TextAnchor.MiddleCenter, TextAlignment textAlignment = TextAlignment.Center, int sortingOrder = 1)
    {
        if (color == null)
        {
            color = Color.white;
        }
        return CreateWorldText(parent, text, localPosition, fontSize, (Color)color, textAnchor, textAlignment, sortingOrder);
    }

    public static TextMesh CreateWorldText(Transform parent, string text, Vector2 localPosition,
        int fontSize, Color color, TextAnchor textAnchor, TextAlignment textAlignment, int sortingOrder)
    {
        GameObject gameObject = new GameObject("World_Text", typeof(TextMesh));
        Transform transform = gameObject.transform;
        transform.SetParent(parent, false);
        transform.localPosition = localPosition;

        TextMesh textMesh = gameObject.GetComponent<TextMesh>();
        textMesh.anchor = textAnchor;
        textMesh.alignment = textAlignment;
        textMesh.text = text;
        textMesh.color = color;
        textMesh.GetComponent<MeshRenderer>().sortingOrder = sortingOrder;

        return textMesh;
    }
    //debug
}
