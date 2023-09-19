using System.Collections.Generic;
using UnityEngine;
using UnityEngine. UI;

[RequireComponent(typeof(AudioSource))]

public class SoundManager : MonoBehaviour
{
    [SerializeField] private List<AudioClip> soundClips;
    private Dictionary<string, AudioClip> soundDictionary = new Dictionary<string, AudioClip>();
    private AudioSource audioSource;
    [SerializeField] private AudioClip currentClip;

    [SerializeField] Slider volumeSlider;

    private void Start()
    {
        foreach (var clip in soundClips)
        {
            soundDictionary[clip.name] = clip;
        }
        gameObject.TryGetComponent<AudioSource>(out audioSource);
    }

    public void PlaySound(string soundName)
    {
        if (soundDictionary.TryGetValue(soundName, out AudioClip clipToPlay))
        {
            audioSource.clip = clipToPlay;
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning($"Sound with name {soundName} not found!");
        }
    }

    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
    }
}
