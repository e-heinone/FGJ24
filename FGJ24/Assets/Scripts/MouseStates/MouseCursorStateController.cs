using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCursorStateController : MonoBehaviour
{
    // See MouseStateGuide.txt in MouseStates folder
    [SerializeField]
    private MouseCursorState_Base currentState;
    public MouseCursorState_Base CurrentState { get => currentState; private set => currentState = value; }

    private MouseCursorState_Default mouseCursorState_Default = new();
    private MouseCursorState_Draggable mouseCursorState_Draggable = new();
    private MouseCursorState_Selectable mouseCursorState_Selectable = new();


    private void Start()
    {

        ChangeState(mouseCursorState_Default);
    }

    private void Update()
    {
        RaycastMousePositionAndChangeState();
    }

    private void RaycastMousePositionAndChangeState()
    {
        // Ray from the camera to the mouse position
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // Perform the raycast
        if (Physics.Raycast(ray, out hit))
        {
            GameObject targetGO = hit.collider.gameObject;
            if (targetGO.tag == "MouseCursorDraggable")
            {
                if (currentState == mouseCursorState_Draggable)
                {
                    return;
                }

                ChangeState(mouseCursorState_Draggable);
            }
            else if (targetGO.tag == "MouseCursorSelectable")
            {
                if (currentState == mouseCursorState_Selectable)
                {
                    return;
                }
                ChangeState(mouseCursorState_Selectable);
            }
            //If (TargetGO.tag = "MouseTargetTag")
            //  if(current state == the state this if is for)
            //      return
            //  ChangeState(The state this if is for)
            else
            {

                ChangeState(mouseCursorState_Default);
            }
        }
        else
        {
            ChangeState(mouseCursorState_Default);
        }
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
}
