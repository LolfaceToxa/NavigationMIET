using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathing;
using Node = LoadGraph.NamedNode;




public class DrawGraph : MonoBehaviour
{

    public Graph<Node> Graph { get; set; }
    private LineRenderer liner;

    [SerializeField]
    private Color lineColor = Color.cyan;

    [SerializeField]
    private float lineWidth = 0.8f;



    private void Awake()
    {
        liner = gameObject.AddComponent<LineRenderer>();
        liner.material = new Material(Shader.Find("Sprites/Default"));
        liner.startColor = lineColor;
        liner.endColor = lineColor;
        liner.widthMultiplier = lineWidth;
        liner.sortingLayerID = SortingLayer.NameToID("Lines");
        liner.positionCount = 0;
    }

    private void ResetDrawer()
    {
        liner.positionCount = 0;
    }


    public Node FindNodeByName(string name)
    {
        foreach (Node node in Graph.Nodes)
        {
            if (node.Name.ToLower() == name.ToLower()) return node;
        }
        return null;
    }

    public void Draw(string start, string end)
    {
        Node startNode = FindNodeByName(start);
        Node endNode = FindNodeByName(end);

        if (startNode is null || endNode is null)
        {
            Debug.LogWarning($"start and end points are not found for {start} and {end}");
            return;
        }


        var path = Dijkstra<Node>.FindPath(Graph, startNode, endNode);
        Draw(path);
    }

    public void Draw(List<Node> path)
    {
        ResetDrawer();
        liner.positionCount = path.Count;
        for (int i = 0; i < path.Count; i++)
        {
            liner.SetPosition(i, path[i].GameObject.transform.position);
        }
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
