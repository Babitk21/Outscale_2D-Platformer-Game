using System;
using UnityEngine;
using UnityEngine.Audio;

[Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
    [Range(0,1)]
    public float volume;
    [Range(0.2f,3f )]
    public float pitch;
    public bool loop;
    [HideInInspector]
    public AudioSource source;
}
