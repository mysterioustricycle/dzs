using UnityEngine;
using System.Collections.Generic;

public class PathFindingDemo : MonoBehaviour
{
    public GameObject redPointPrefab;
    public Transform startPoint;
    public Transform endPoint;
    public float pathSmoothness = 0.5f;

    private void Start()
    {
        List<Vector3> path = AStarPathfinding(startPoint.position, endPoint.position);
        RemoveRedPoints(path);
    }

    private List<Vector3> AStarPathfinding(Vector3 start, Vector3 end)
    {
        // A* Pathfinding implementation here
        return new List<Vector3>(); // Placeholder for path points
    }

    private void RemoveRedPoints(List<Vector3> path)
    {
        foreach (Vector3 point in path)
        {
            GameObject redPoint = Instantiate(redPointPrefab, point, Quaternion.identity);
            Destroy(redPoint, pathSmoothness); // Remove the red point after a certain time
        }
    }
}