using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Counter : MonoBehaviour
{
    public int mineCount = 32;

    [SerializeField] TextMeshProUGUI counterText;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MinusMines()
    {
        if (mineCount > 0)
        {
            mineCount -= 1;
        }
        UpdateCounterText();
    }

    public void PlusMines()
    {
        mineCount +=1;
        UpdateCounterText();
    }

    private void UpdateCounterText()
    {
        counterText.text = mineCount.ToString();
    }

    public void ResetMineCounter()
    {
        counterText.text = 32.ToString();
        mineCount = 32;
    }
}
