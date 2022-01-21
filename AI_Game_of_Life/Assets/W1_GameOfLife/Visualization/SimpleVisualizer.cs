using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleVisualizer : MonoBehaviour
{
    public GameObject vis;
    public Transform container;
    private readonly List<GameObject> currentClones = new List<GameObject>();

    private void UpdateVisualization(List<Vector2Int> coordinates)
    {
        ClearPrevious();

        foreach (var wp in coordinates)
        {
            var wp3 = new Vector3(wp.x, wp.y, 0);
            var go = InstantiateVisualElement(wp3);
            currentClones.Add(go);
        }
    }

    private GameObject InstantiateVisualElement(Vector3 localPosition)
    {
        var go = Instantiate(vis, container, false);

        go.transform.localPosition = localPosition;

        return go;
    }

    private void ClearPrevious()
    {
        foreach (var v in currentClones)
        {
            Destroy(v.gameObject);
        }

        currentClones.Clear();
    }
}