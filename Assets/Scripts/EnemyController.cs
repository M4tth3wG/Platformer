using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public AudioSource hitAudio;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            hitAudio.Play();
            StartCoroutine(UpdateController(hitAudio));
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
