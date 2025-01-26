using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Notepad : MonoBehaviour
{
    [SerializeField] private UDictionary<string, bool> _keyValuePairs;

    private UIDocument _document;

    // tee näitä pareja jokaselle riville
    private TextField _textField1;
    [SerializeField] private string _text1;

    private TextField _textField2;
    [SerializeField] private string _text2;


    //private void Awake()
    //{
    //    _document = GetComponent<UIDocument>();
    //    //_document.rootVisualElement.RegisterCallback<ChangeEvent<string>>(OnStringchangedEvent);

    //    //_document.rootVisualElement.Q("NotepadText1").RegisterCallback<ChangeEvent<string>, TextField>(OnStringchangedEvent, _textField1);

    //    _textField1 = _document.rootVisualElement.Q("NotepadText1") as TextField;

    //    _document.rootVisualElement.Q("NotepadText1").RegisterCallback<ChangeEvent<string>>(TextField1Changed);
    //}

    private void OnEnable()
    {
        _document = GetComponent<UIDocument>();

        _document.rootVisualElement.Q("NotepadText1").RegisterCallback<ChangeEvent<string>>(TextField1Changed);
        _textField1 = _document.rootVisualElement.Q("NotepadText1") as TextField;
        _textField1.value = _text1;

        _document.rootVisualElement.Q("NotepadText2").RegisterCallback<ChangeEvent<string>>(TextField2Changed);
        _textField2 = _document.rootVisualElement.Q("NotepadText2") as TextField;
        _textField2.value = _text2;
    }

    private void OnDisable()
    {
        //_document.rootVisualElement.UnregisterCallback<ChangeEvent<string>>(OnStringchangedEvent);
        //_document.rootVisualElement.Q("NotepadText1").UnregisterCallback<ChangeEvent<string>, string>(OnStringchangedEvent);
        //_document.rootVisualElement.Q("NotepadText2").UnregisterCallback<ChangeEvent<string>, string>(OnStringchangedEvent);
    }

    private void TextField1Changed(ChangeEvent<string> changeEvent)
    {
        Debug.Log("input field changed " + changeEvent.newValue);
        _textField1.value = changeEvent.newValue;
        _text1 = changeEvent.newValue;

        CheckText(changeEvent.newValue);
    }

    private void TextField2Changed(ChangeEvent<string> changeEvent)
    {
        Debug.Log("input field changed " + changeEvent.newValue);
        _textField2.value = changeEvent.newValue;
        _text2 = changeEvent.newValue;

        CheckText(changeEvent.newValue);
    }

    private void CheckText(string text)
    {
        if(_keyValuePairs.ContainsKey(text))
        {
            Debug.Log("Text matched the answer");
            _keyValuePairs[text] = true;
        }
    }
}
