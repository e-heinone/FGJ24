using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class WindowEvents : MonoBehaviour
{
    private UIDocument _document;
    private Button _button;

    private void OnEnable()
    {
        _document = GetComponent<UIDocument>();
        _button = _document.rootVisualElement.Q("ExitButton") as Button;
        _button.RegisterCallback<ClickEvent>(OnExitButtonClick);
    }

    private void OnDisable()
    {
        _button.UnregisterCallback<ClickEvent>(OnExitButtonClick);
    }

    private void OnExitButtonClick(ClickEvent clickEvent)
    {
        gameObject.SetActive(false);
    }
}
