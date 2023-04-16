using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UISlot : MonoBehaviour, IDropHandler
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnDrop(PointerEventData eventData)
    {
        var otherItem = eventData.pointerDrag;
        otherItem.transform.SetParent(transform);
        otherItem.transform.localPosition = Vector2.zero;

        var t = otherItem.GetComponentInChildren<Image>().sprite.name;
    }
}
