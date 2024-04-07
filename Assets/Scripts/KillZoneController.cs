using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillZoneController : MonoBehaviour
{
    public AudioSource fallAudio;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            fallAudio.Play();
            GameController.instance.PlayerDamaged();

            StartCoroutine(ReloadWithAudio(fallAudio));
        }
    }

    private IEnumerator ReloadWithAudio(AudioSource audio)
    {
        while (audio.isPlaying)
        {
            yield return null;
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

