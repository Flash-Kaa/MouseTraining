using UnityEngine;
using UnityEngine.EventSystems;

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
        // Перетаскиваем не из блок-схемы (из списка доступных действий)
        if (!eventData.pointerEnter.transform.parent.transform.parent.CompareTag("DoingColumn"))
        {
            // Копируем элемент
            var newObject = Object.Instantiate(this, transform.position, transform.rotation);
            newObject.transform.SetParent(transform.parent);
            newObject.transform.localScale = Vector2.one;
        }

        var slotTransform = _rectTransform.parent;
        slotTransform.SetAsLastSibling();
        _canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Изменяем позицию при перетаскивании с учётом размера экрана
        _rectTransform.anchoredPosition += eventData.delta / _canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Вставляем не в блок-схему
        if (eventData.pointerEnter == null || !eventData.pointerEnter.CompareTag("DoingColumn"))
        {
            Destroy(eventData.pointerDrag);
            return;
        }

        transform.localPosition = Vector2.zero;
        _canvasGroup.blocksRaycasts = true;
    }
}
