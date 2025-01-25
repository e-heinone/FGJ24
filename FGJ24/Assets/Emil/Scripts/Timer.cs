using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    float elapsedTime;

    public bool isOn = true;

    public void ResetTimer()
    {
        elapsedTime = 0;
        timerText.text = "00:00";
        isOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isOn)
        {
            elapsedTime += Time.deltaTime;

            int minutes = Mathf.FloorToInt(elapsedTime / 60);
            int seconds = Mathf.FloorToInt(elapsedTime % 60);

            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
}
