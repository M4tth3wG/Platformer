using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD_Controller : MonoBehaviour
{
    public static HUD_Controller instance;
    public AudioSource audioSource;

    public Slider slider;
    public Toggle muteToggle;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        audioSource.volume = slider.value;
        audioSource.mute = muteToggle.isOn;
    }
}
