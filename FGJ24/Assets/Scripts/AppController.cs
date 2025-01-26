using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppController : MonoBehaviour
{
    [SerializeField]
    private GameObject minesweeperGame;

    private void Start()
    {
        Camera.main.transform.position = new Vector3(16 / 2f, 16 / 2f, -10f);
    }

    public void EnableMinesweeper()
    {
        minesweeperGame.SetActive(true);
    }
    public void DisableMinesweeper()
    {
        minesweeperGame.SetActive(false);
    }
}
