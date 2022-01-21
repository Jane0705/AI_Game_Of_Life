using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellData
{
    public Vector2Int Coordinate { get; private set; }
    public bool IsAlive { get; private set; }

    public CellData(Vector2Int coord, bool alive)
    {
        Coordinate = coord;
        IsAlive = alive;
    }
}
