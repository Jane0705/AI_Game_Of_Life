using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOfLifeGrid : MonoBehaviour
{
    private Dictionary<Vector2Int, CellData> livingCells;

    [SerializeField]
    private List<Vector2Int> initialCells;

    // Start is called before the first frame update
    void Start()
    {
        livingCells = new();

        for(int i = 0; i < initialCells.Count; i++)
        {
            CellData cell = new CellData(initialCells[i], true);
            livingCells.Add(initialCells[i], cell);
        }

        StartCoroutine(UpdateRoutine());
    }

    private static readonly List<Vector2Int> NEIGHBOUR_DIRECTIONS = new()
    {
        new Vector2Int(0, 1), //North
        new Vector2Int(1, 0), //East
        new Vector2Int(0, -1), //South
        new Vector2Int(-1, 0), //West
        new Vector2Int(1, 1), //North East
        new Vector2Int(1, -1), //South East
        new Vector2Int(-1, -1), //South West
        new Vector2Int(-1, 1), //North West
    };

    List<CellData> GetNeighbours(Vector2Int coordinate)
    {
        List<CellData> neighbours = new List<CellData>();

        foreach (Vector2Int directions in NEIGHBOUR_DIRECTIONS)
        {
            Vector2Int neighbourCoord = coordinate + directions;

            if (livingCells.TryGetValue(neighbourCoord, out CellData cell) == true)
            {
                neighbours.Add(cell);
            }
            else
            {
                neighbours.Add(new CellData(neighbourCoord, false));
            }
                
        }

        return neighbours;
    }

    int GetLivingCount (List<CellData> neighbours)
    {
        int aliveCount = 0;

        foreach(CellData neighbour in neighbours)
        {
            if(neighbour.IsAlive == true)
            {
                aliveCount++;
            }
        }

        return aliveCount;
    }

    void SimulateNextStep()
    {
        //Part 1
        Dictionary<Vector2Int, CellData> relevantCells = new(livingCells);
        
        foreach(KeyValuePair<Vector2Int, CellData> kvp in livingCells)
        {
            List<CellData> neighbours = GetNeighbours(kvp.Key);

            foreach(CellData cell in neighbours)
            {
                if(!relevantCells.ContainsKey(cell.Coordinate))
                {
                    relevantCells.Add(cell.Coordinate, cell);
                }
            }
        }

        //Part 2
    }

    //IEnumerator UpdateRoutine()
    //{

    //}
}
