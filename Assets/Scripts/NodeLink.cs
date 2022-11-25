using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeLink : MonoBehaviour
{
    [SerializeField]
    public string Name = string.Empty;

    [SerializeField]
    public GameObject[] nodes;

    void Awake()
    {
        if (nodes is null) return;
        Debug.Assert(Camera.main is not null, "Camera is null!");
        var loader = Camera.main.GetComponent<LoadGraph>();
        foreach (var node in nodes)
        {
            loader.AddLink(gameObject, node);
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {

    }


   
    private void OnDrawGizmosSelected()
    {
        foreach (var node in nodes)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(node.transform.position, gameObject.transform.position);
        }
    }
}
