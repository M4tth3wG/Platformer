using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishFlagController : MonoBehaviour
{
    public AudioSource levelCompleteAudio;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            levelCompleteAudio.Play();
            other.attachedRigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
            StartCoroutine(UpdateController(levelCompleteAudio));
        }
    }

    private IEnumerator UpdateController(AudioSource audio)
    {
        while (audio.isPlaying)
        {
            yield return null;
        }

        GameController.instance.NextLevel();
    }
}
