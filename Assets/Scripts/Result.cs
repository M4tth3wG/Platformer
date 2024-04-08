using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Result : MonoBehaviour
{
    public TextMeshProUGUI resultText;

    void Start()
    {
        if (GameController.instance.health == 0)
        {
            resultText.text = "YOU LOSE";
            resultText.color = Color.red;
        }
    }
}
