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


    public void Draw(Graph<Node> _graph)
    {
        graph = _graph;
        liner.positionCount = graph.Links.Count * 2;
        foreach (var link in graph.Links)
        {
            DrawLink(link.A, link.B);
        }
    }

    void DrawLink(Node n1, Node n2)
    {
        liner.SetPosition(currentNode, n1.GameObject.transform.position);
        currentNode++;
        liner.SetPosition(currentNode, n2.GameObject.transform.position);
        currentNode++;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

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
