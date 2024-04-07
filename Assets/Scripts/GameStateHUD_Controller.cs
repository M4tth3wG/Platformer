using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameStateHUD_Controller : MonoBehaviour
{
    public TextMeshProUGUI livesDisplay;
    public TextMeshProUGUI enemiesKilledDisplay;

    void Update()
    {
        livesDisplay.text = GameController.instance.health.ToString();
        enemiesKilledDisplay.text = GameController.instance.enemiesKilled.ToString();
    }
}
