using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppController : MonoBehaviour
{
    [SerializeField]
    Texture2D cursor;

    private void Start()
    {
        Camera.main.transform.position = new Vector3(16 / 2f, 16 / 2f, -10f);
        Cursor.SetCursor(cursor, Vector3.zero, CursorMode.ForceSoftware);
    }

    public void EnableGO(GameObject go)
    {
        go.SetActive(true);
    }

    public void DisableGO(GameObject go)
    {
        go.SetActive(false);
    }

    public void ToggleGOActiveStatus(GameObject go)
    {
        if (go.activeSelf)
        {
            go.SetActive(false);
        }
        else
            go.SetActive(true);
    }

    public void QuitGame()
    {
        Debug.Log("App quit.");
        Application.Quit();
    }
}
