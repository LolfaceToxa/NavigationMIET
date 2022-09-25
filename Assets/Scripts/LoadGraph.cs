using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadGraph : MonoBehaviour
{

    private void Awake()
    {
        LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.startColor = Color.red;
        lineRenderer.endColor = Color.red;
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        //Gradient gradient = new();
        //var alpha = 1.0f;
        //gradient.SetKeys(
        //    new GradientColorKey[] { new GradientColorKey(Color.cyan, 0.0f), new GradientColorKey(Color.cyan, 1.0f) },
        //    new GradientAlphaKey[] { new GradientAlphaKey(alpha, 0.0f), new GradientAlphaKey(alpha, 1.0f) }
        //    );
        //lineRenderer.colorGradient = gradient;
        lineRenderer.startColor = Color.cyan;
        lineRenderer.endColor = Color.cyan;
        lineRenderer.SetPosition(1, new Vector3(0, 10, 0));
        lineRenderer.SetPosition(0, new Vector3(0, 0, 0));
        lineRenderer.widthMultiplier = 0.1f;

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
