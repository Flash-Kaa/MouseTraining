using UnityEngine;
using UnityEngine.EventSystems;

public class UISlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerEnter.GetComponent<UISlot>() == null)
        {
            Destroy(eventData.pointerDrag);
            return;
        }

        var otherItem = eventData.pointerDrag;
        otherItem.transform.SetParent(transform);
        otherItem.transform.localPosition = Vector2.zero;
    }
}
