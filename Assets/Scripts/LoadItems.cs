using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI.Extensions;
using static UnityEditor.Progress;

public class LoadItems : MonoBehaviour
{
    [SerializeField]
    private GameObject[] comboBoxes;

    private List<string> _items;

    public void Add(List<string> items)
    {
        _items = items;
    }

    public void Load()
    {
        foreach (var comboBox in comboBoxes)
        {
            comboBox.GetComponent<AutoCompleteComboBox>().SetAvailableOptions(_items);
        }
    }


}
