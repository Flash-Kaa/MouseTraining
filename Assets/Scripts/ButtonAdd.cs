using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ButtonAdd : MonoBehaviour
{
    [SerializeField] private GameObject _flowChartContent;
    [SerializeField] private GameObject _cell;

    public void AddCell()
    {
        var end = _flowChartContent.transform.GetChild(_flowChartContent.transform.childCount - 1).gameObject;
        
        Instantiate(_cell, _flowChartContent.transform);
        Instantiate(end, _flowChartContent.transform);
        Destroy(end);
    }
}
