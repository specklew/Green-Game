using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomDraggable : MonoBehaviour
{
    private Vector3 mousePositionOffset;

    private Vector3 GetMousePosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseDown()
    {
        mousePositionOffset = gameObject.transform.position - GetMousePosition();
    }

    private void OnMouseDrag()
    {
        gameObject.transform.position = GetMousePosition() + mousePositionOffset;
    }

}
