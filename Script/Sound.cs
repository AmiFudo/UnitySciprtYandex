using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public AudioClip[] sounds;

    private AudioSource audiSrc => GetComponent<AudioSource>();

    public void PlaySound(AudioClip clip, float volume = 1f, bool destroyed = false, float p1 = 0.85f, float p2 = 1.2f)
    {
        audiSrc.pitch = Random.Range(p1, p2);
        audiSrc.PlayOneShot(clip, volume);
    }
}
