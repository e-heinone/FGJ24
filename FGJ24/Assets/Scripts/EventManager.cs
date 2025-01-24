using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    [SerializeField] private UDictionary<string, bool> savedEvent;

    public void ToggleBoolean(string eventName)
    {
        savedEvent[eventName] = !savedEvent[eventName];
    }

    public bool GetBoolean(string eventName)
    {
        return savedEvent[eventName];
    }
}
