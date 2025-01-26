using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppController : MonoBehaviour
{

    private void Start()
    {
        Camera.main.transform.position = new Vector3(16 / 2f, 16 / 2f, -10f);
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
