using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIItem : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private RectTransform _rectTransform;
    private Canvas _canvas;
    private CanvasGroup _canvasGroup;

    void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
        _canvas = GetComponentInParent<Canvas>();
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!eventData.pointerEnter.transform.parent.transform.parent.CompareTag("DoingColumn"))
        {
            var newObject = Object.Instantiate(this, transform.position, transform.rotation);
            newObject.transform.SetParent(this.transform.parent);
            newObject.transform.localScale = Vector2.one;
        }

        var slotTransform = _rectTransform.parent;
        slotTransform.SetAsLastSibling();
        _canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        _rectTransform.anchoredPosition += eventData.delta / _canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (eventData.pointerEnter == null || eventData.pointerEnter.tag != "DoingColumn")
        {
            Destroy(eventData.pointerDrag);
            return;
        }

        transform.localPosition = Vector2.zero;
        _canvasGroup.blocksRaycasts = true;
    }
}
