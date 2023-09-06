using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class SoundManager : MonoBehaviour
{
    [SerializeField] private List<AudioClip> soundClips;
    private AudioSource audioSource;
    [SerializeField] private AudioClip currentClip;
    private void Start()
    {
        gameObject.TryGetComponent<AudioSource>(out audioSource);
    }

    public void PlaySound(string soundName)
    {
        for (int i = 0; i < soundClips.Count; i++)
        {
            if (soundClips[i].name == soundName)
            {
                currentClip = soundClips[i];
                audioSource.clip = currentClip;
                audioSource.Play();
                return;
            }
        }
    }
}
