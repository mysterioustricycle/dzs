using System;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    public List<Node> FindPath(Vector3 start, Vector3 target)
    {
        Node startNode = new Node(start);
        Node targetNode = new Node(target);
        List<Node> openSet = new List<Node>();
        HashSet<Node> closedSet = new HashSet<Node>();
        openSet.Add(startNode);

        while (openSet.Count > 0)
        {
            Node currentNode = openSet[0];
            for (int i = 1; i < openSet.Count; i++)
            {
                if (openSet[i].fCost < currentNode.fCost || openSet[i].fCost == currentNode.fCost && openSet[i].hCost < currentNode.hCost)
                {
                    currentNode = openSet[i];
                }
            }

            openSet.Remove(currentNode);
            closedSet.Add(currentNode);

            if (currentNode == targetNode)
            {
                return RetracePath(startNode, targetNode);
            }

            foreach (Node neighbour in currentNode.GetNeighbours())
            {
                if (closedSet.Contains(neighbour)) continue;
                float newCostToNeighbour = currentNode.gCost + GetDistance(currentNode, neighbour);
                if (newCostToNeighbour < neighbour.gCost || !openSet.Contains(neighbour))
                {
                    neighbour.gCost = newCostToNeighbour;
                    neighbour.hCost = GetDistance(neighbour, targetNode);
                    neighbour.parent = currentNode;
                    if (!openSet.Contains(neighbour)) openSet.Add(neighbour);
                }
            }
        }
        return new List<Node>(); // return empty path if no path found
    }

    List<Node> RetracePath(Node startNode, Node endNode)
    {
        List<Node> path = new List<Node>();
        Node currentNode = endNode;
        while (currentNode != startNode)
        {
            path.Add(currentNode);
            currentNode = currentNode.parent;
        }
        path.Reverse();
        return path;
    }

    float GetDistance(Node a, Node b)
    {
        return Vector3.Distance(a.position, b.position);
    }
}

public class Node
{
    public Vector3 position;
    public float gCost;
    public float hCost;
    public Node parent;

    public Node(Vector3 pos)
    {
        position = pos;
        gCost = 0;
        hCost = 0;
    }

    public List<Node> GetNeighbours()
    {
        // Implement a method to get neighbor nodes based on your game grid logic
        return new List<Node>();
    }

    public float fCost { get { return gCost + hCost; } }
}