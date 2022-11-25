using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Pathing;
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


    public void AddLink(GameObject o1, GameObject o2)
    {
        Debug.Assert(o1 is not null, "o1 is a null!");
        Debug.Assert(o2 is not null, "o2 is a null!");
        this.graph.Add(new NamedNode(o1), new NamedNode(o2), Vector3.Distance(o1.transform.position, o2.transform.position));
        Debug.Log(string.Format("added object under id[{0}] into graph", o1.GetInstanceID()));
        Debug.Log(string.Format("added object under id[{0}] into graph", o2.GetInstanceID()));
    }

    private void Awake()
    {

    }

    //private void Awake()
    //{
    //    for (int i = 0; i < 10; i++)
    //    {
    //        Instantiate(NodePrefab, Vector3.zero, Quaternion.identity);
    //        Debug.Log("Created node");
    //    }



    //    LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer>();
    //    lineRenderer.startColor = Color.red;
    //    lineRenderer.endColor = Color.red;
    //    lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
    //    //Gradient gradient = new();
    //    //var alpha = 1.0f;
    //    //gradient.SetKeys(
    //    //    new GradientColorKey[] { new GradientColorKey(Color.cyan, 0.0f), new GradientColorKey(Color.cyan, 1.0f) },
    //    //    new GradientAlphaKey[] { new GradientAlphaKey(alpha, 0.0f), new GradientAlphaKey(alpha, 1.0f) }
    //    //    );
    //    //lineRenderer.colorGradient = gradient;
    //    lineRenderer.startColor = Color.cyan;
    //    lineRenderer.endColor = Color.cyan;
    //    lineRenderer.SetPosition(1, new Vector3(0, 10, 0));
    //    lineRenderer.SetPosition(0, new Vector3(0, 0, 0));
    //    lineRenderer.widthMultiplier = 0.1f;

    //}
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<DrawGraph>().Draw(graph);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
