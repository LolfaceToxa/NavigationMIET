using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI.Extensions;
using static UnityEditor.Progress;

public class LoadItems : MonoBehaviour
{

    private void Awake()
    {
        Load(Camera.main.GetComponent<LoadGraph>().Names);
    }

    private void Load(List<string> names)
    {
        gameObject.GetComponent<AutoCompleteComboBox>().SetAvailableOptions(names);
    }


}
