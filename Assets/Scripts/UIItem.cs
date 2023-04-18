using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIItem : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public bool CanDuplicated = true;

    private RectTransform _rectTransform;
    private Canvas _canvas;
    private CanvasGroup _canvasGroup;
    private Vector3 spawnPoint = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
        _canvas = GetComponentInParent<Canvas>();
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (CanDuplicated)
        {
            var newObject = Object.Instantiate(this, transform.position, transform.rotation);
            newObject.transform.SetParent(this.transform.parent);
            newObject.transform.localScale = Vector2.one;
        }

        CanDuplicated = false;

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
        transform.localPosition = Vector2.zero;

        _canvasGroup.blocksRaycasts = true;

        if (int.TryParse(eventData.pointerEnter.name, out var index))
        {
            CommandList.Add(GetComponentInChildren<Image>().sprite.name, index);
        }

    }
}
