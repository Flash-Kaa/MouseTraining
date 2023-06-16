using UnityEngine;
using UnityEngine.EventSystems;

public class UISlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        // Меняем местонахождение входящего объекта в иерархии
        var otherItem = eventData.pointerDrag;
        otherItem.transform.SetParent(transform);
        otherItem.transform.localPosition = Vector2.zero;
    }
}