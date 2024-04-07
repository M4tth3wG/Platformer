using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public AudioSource fallAudio;
    public AudioSource hitAudio;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        AudioSource currentAudio = null;

        if (collision.tag == "Enemy")
        {
            currentAudio = hitAudio;
        }
        else if (collision.tag == "KillZone")
        {
            currentAudio = fallAudio;
        }

        if (currentAudio != null)
        {
            currentAudio.Play();
            UpdateController(currentAudio);
        }     
    }

    private IEnumerator UpdateController(AudioSource audio)
    {
        while (audio.isPlaying)
        {
            yield return null;
        }

        GameController.instance.PlayerDamaged();
    }
}
