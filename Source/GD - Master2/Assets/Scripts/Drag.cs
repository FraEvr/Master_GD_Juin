using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour, IDragHandler, IBeginDragHandler
{
    float dampingSpeed = .0f;

    private RectTransform draggingObject;
    private Vector3 velocity = Vector3.zero;
    private Vector3 dragOffset;

    private void Awake()
    {
        draggingObject = transform as RectTransform;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(draggingObject, eventData.position, eventData.pressEventCamera, out var globalMousePosition))
        {
            draggingObject.position = Vector3.SmoothDamp(draggingObject.position, globalMousePosition + dragOffset, ref velocity, dampingSpeed);
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        draggingObject.gameObject.transform.SetSiblingIndex(transform.parent.childCount);
        RectTransformUtility.ScreenPointToWorldPointInRectangle(draggingObject, eventData.position, eventData.pressEventCamera, out var globalMousePosition);
        dragOffset = draggingObject.position - globalMousePosition;
    }
}
