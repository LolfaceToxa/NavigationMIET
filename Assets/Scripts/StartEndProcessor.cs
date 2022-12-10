using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StartEndProcessor : MonoBehaviour
{

    private string _start = null;
    private string _end = null;


    public void OnStartSet(string start)
    {
        _start = start;
        Debug.Log(start);
        _Pass();
    }

    public void OnEndSet(string end)
    {
        _end = end;
        Debug.Log(end);
        _Pass();
    }

    private bool _Check()
    {
        return _start is not null && _end is not null;
    }

    private void _Pass()
    {
        if (_Check())
        {
            var drawGraph = gameObject.GetComponent<DrawGraph>();
            if (drawGraph is null)
            {
                Debug.LogError("Object doesnt have 'DrawGraph' component!");
                return;
            }
            Debug.Log(_start);
            Debug.Log(_end);

        }
    }
}
