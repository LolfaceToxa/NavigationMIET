using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeLink : MonoBehaviour
{

    [SerializeField]
    public GameObject[] nodes;

    void Awake()
    {
        Camera.main.GetComponent<LoadGraph>();
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
