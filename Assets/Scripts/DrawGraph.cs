using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathing;
using Node = LoadGraph.NamedNode;

public class DrawGraph : MonoBehaviour
{
    Graph<Node> graph;
    LineRenderer liner;

    int currentNode = 0;

    private void Awake()
    {
        liner = gameObject.AddComponent<LineRenderer>();
        liner.material = new Material(Shader.Find("Sprites/Default"));
        liner.startColor = Color.cyan;
        liner.endColor = Color.cyan;
        liner.widthMultiplier = 0.8f;
        liner.positionCount = 0;

    }


    private void ResetDrawer()
    {
        liner.positionCount = 0;
        currentNode = 0;
    }


    public Node FindNodeByName(string name)
    {
        foreach (Node node in graph.Nodes)
        {
            if (node.Name == name) return node;
        }
        return null;
    }

    public void Draw(string start, string end)
    {
        Node startNode = FindNodeByName(start);
        Node endNode = FindNodeByName(end);
        if (startNode is not null && endNode is not null)
        {
            var path = Dijkstra<Node>.FindPath(graph, startNode, endNode);
            Draw(path);
        }
    }

    public void Draw(List<Node> path)
    {
        ResetDrawer();
        liner.positionCount = path.Count;
        for (int i = 1; i < path.Count; i++)
        {
            DrawLink(path[i - 1], path[i]);
        }
    }

    private void DrawLink(Node n1, Node n2)
    {
        liner.SetPosition(currentNode, n1.GameObject.transform.position);
        currentNode++;
        liner.SetPosition(currentNode, n2.GameObject.transform.position);
        currentNode++;
    }


    private void OnDrawGizmos()
    {
        var nodes = GameObject.FindGameObjectsWithTag("GraphNode");
        Gizmos.color = Color.red;
        foreach (var node in nodes)
        {
            var nodeLinks = node.GetComponent<NodeLink>();
            foreach (var linkedNode in nodeLinks.nodes)
            {
                if (linkedNode != null)
                    Gizmos.DrawLine(linkedNode.transform.position, node.transform.position);
            }
        }

    }

}
