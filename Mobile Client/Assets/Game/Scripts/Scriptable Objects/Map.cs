using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Map : ScriptableObject
{
    // width represents the amount of columns the map has
    public int width;

    // height represents the amount of rows the map has
    public int height;

    public Vector2Int[] gridCoord;

    public Item[] gridTile;

    public Vector2Int[] AICoords;

    public AI[] AITokens;
}
