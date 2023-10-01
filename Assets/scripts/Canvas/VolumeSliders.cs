using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeSliders : MonoBehaviour
{
    public AudioMixer audioMixerMusic;
    public AudioMixer audioMixerEffects;
    // Start is called before the first frame update
    public void SetVolumeMusic(float volume)
    {
        audioMixerMusic.SetFloat("volume", volume);
    }
    public void SetVolumeEffects(float volume)
    {
        audioMixerEffects.SetFloat("volume", volume);
    }
}
