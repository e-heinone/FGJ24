using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTest : MonoBehaviour
{

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        // Get mouse position in screen space
        Vector3 mouseScreenPosition = Input.mousePosition;

        // Convert screen space to world space
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(new Vector3(mouseScreenPosition.x, mouseScreenPosition.y, Camera.main.nearClipPlane));

        // Update sprite's position (keep z-position unchanged or set it explicitly)
        transform.position = new Vector3(mouseWorldPosition.x, mouseWorldPosition.y, transform.position.z);
    }

    public void ChangeColor(MouseCursorState_Base newState)
    {
        if (newState is MouseCursorState_Default)
        {
            spriteRenderer.color = Color.white;
        }
        else if (newState is MouseCursorState_Draggable)
        {
            spriteRenderer.color = Color.red;
        }
        else if (newState is MouseCursorState_Selectable)
        {
            spriteRenderer.color = Color.blue;
        }
    }
}
