using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoveCounter : MonoBehaviour
{
    TextMeshProUGUI moveCounterDisplay;
    int moveCount;

    // Start is called before the first frame update
    void Start()
    {
        moveCounterDisplay = GetComponent<TextMeshProUGUI>();
        moveCount = 0;
        UpdateCounterDisplay();
    }

    public void IncreaseMoveCount()
    {
        moveCount++;
        UpdateCounterDisplay();
    }

    public void UpdateCounterDisplay()
    {
        moveCounterDisplay.text = moveCount.ToString();
    }
}
