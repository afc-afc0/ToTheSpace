using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;

    public static AudioManager Instance
    {
        get
        {
            return instance;
        }
    }

    public Sound[] sounds;

    private void Awake()
    {
        instance = this;

        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }

    }

    public void Play(string name)
    {
        if (name == String.Empty)
            return;

        Sound s = Array.Find(sounds, sound => sound.name == name);

        /*if (s.source.isPlaying == false)
        {
            s.source.Play();
        }
        */
        s.source.Play();
    }


}
