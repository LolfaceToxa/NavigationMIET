using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Pathing;
using Unity.VisualScripting;

public class LoadGraph : MonoBehaviour
{

    public class NamedNode : INode
    {
        public GameObject GameObject { get; }
        public string Name { get; set; }
        private int id;
        public NamedNode(GameObject gameObject, string name)
        {
            this.GameObject = gameObject;
            this.id = gameObject.GetInstanceID();
            this.Name = name;
        }

        public NamedNode(GameObject gameObject) : this(gameObject, string.Empty) { }

        public override bool Equals(object obj)
        {
            if (obj is NamedNode node)
            {
                return node.id == this.id;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return this.id;
        }

    }

    private Graph<NamedNode> graph;

    public LoadGraph()
    {
        graph = new Graph<NamedNode>();
    }


    public void AddLink(GameObject o1, GameObject o2, string name1, string name2)
    {
        Debug.Assert(o1 is not null, "o1 is a null!");
        Debug.Assert(o2 is not null, "o2 is a null!");
        this.graph.Add(new NamedNode(o1, name1), new NamedNode(o2, name2), Vector3.Distance(o1.transform.position, o2.transform.position));
        Debug.Log(string.Format(@"added object under id[{0}] with name ""{1}"" into graph", o1.GetInstanceID(), o1.name));
        Debug.Log(string.Format(@"added object under id[{0}] with name ""{1}"" into graph", o2.GetInstanceID(), o2.name));
    }


    private List<string> FormItemList()
    {
        List<string> items = new();
        Debug.Log("loadeding items");
        foreach (var node in graph.Nodes)
        {
            if (string.IsNullOrEmpty(node.Name)) continue;
            items.Add(node.Name);
            Debug.Log(node.Name);
        }
        return items;
    }


    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<LoadItems>().Add(FormItemList());
        this.gameObject.GetComponent<DrawGraph>().Draw(graph);
    }
}
