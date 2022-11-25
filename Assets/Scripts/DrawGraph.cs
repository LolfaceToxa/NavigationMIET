using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathing;
using Node = LoadGraph.NamedNode;

public class DrawGraph : MonoBehaviour
{
    Graph<Node> graph;
    LineRenderer liner;

    public DrawGraph()
    {
        liner = gameObject.AddComponent<LineRenderer>();
    }

    public void Draw(Graph<Node> _graph)
    {
        graph = _graph;

    }

    void DrawLink()
    {

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
