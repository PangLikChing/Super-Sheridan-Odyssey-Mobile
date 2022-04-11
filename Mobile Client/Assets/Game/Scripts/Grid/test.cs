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

    [SerializeField] Item testItem;

    void Start()
    {
        // test
        gridSystem = new GridSystem(4, 2, 10f, origin);
        // test
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
            List<Vector2Int> occupiedGrid = testItem.GetAllOccupiedGrid(new Vector2Int(x, y));

            // For every grid in the grids that are going to be occupied
            for (int i = 0; i < occupiedGrid.Count; i++)
            {
                // If any of them has a value of 1 aka has something there
                if (gridSystem.GetGridValue(occupiedGrid[i].x, occupiedGrid[i].y) == 1)
                {
                    // Set canBuild to false
                    canBuild = false;
                }
            }

            // If the grids are buildable
            if (canBuild)
            {
                // Put down the object

                // The position is at the middle of the grid
                // grid's world position * grid size * that item's grid width / height / 2
                Transform test = Instantiate(testItem.art2dPrefeb,
                    new Vector3(gridSystem.GetWorldPosition(x, y).x + gridSystem.gridSize * testItem.gridWidth * 0.5f, gridSystem.GetWorldPosition(x, y).y + gridSystem.gridSize * testItem.gridHeight * 0.5f, 0),
                    Quaternion.identity
                );

                // For every occupying grid
                for (int j = 0; j < occupiedGrid.Count; j++)
                {
                    // Change the grid's value to 1
                    gridSystem.SetGridValue(occupiedGrid[j].x, occupiedGrid[j].y, 1);
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
