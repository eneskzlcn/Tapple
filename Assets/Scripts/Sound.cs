using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound
{

    public AudioClip clip;

    [Range(0.1f,3f)]
    public float pitch;
    [Range(0f,1f)]
    public float volume;
    public string name;
    public bool loop;

    [HideInInspector]
    public AudioSource source;
}