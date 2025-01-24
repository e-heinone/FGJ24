using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCursorStateController : MonoBehaviour
{
    [SerializeField]
    private MouseCursorState_Base currentState;
    public MouseCursorState_Base CurrentState { get => currentState; private set => currentState = value; }

    private MouseCursorState_Default mouseCursorState_Default = new();
    private MouseCursorState_Draggable mouseCursorState_Draggable = new();
    private MouseCursorState_Clickable mouseCursorState_Clickable = new();


    private void Start()
    {
        ChangeState(mouseCursorState_Default);
    }


    public void ChangeState(MouseCursorState_Base newState)
    {
        if (currentState != null)
        {
            currentState.OnExit();
        }
        currentState = newState;
        currentState.OnEnter();
    }

    private void Update()
    {
        // Ray from the camera to the mouse position
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // Perform the raycast
        if (Physics.Raycast(ray, out hit))
        {
            GameObject targetGO = hit.collider.gameObject;
            if(targetGO.tag == "MouseCursorDraggable")
            {

            }
            else if (targetGO.tag == "MouseCursorSelectable")
            {

            }
            else
            {

            }
        }
    }
}
