using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class DraggableItem : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{

    private RectTransform rectTransform;

    private CanvasGroup canvasGroup;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Begin drag");
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("End drag");
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
    }
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
    }
}
