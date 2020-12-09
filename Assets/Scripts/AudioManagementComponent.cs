using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.UI;

public class AudioManagementComponent : MonoBehaviour
{
    public Sound[] sounds;
    [SerializeField] private Button[] buttons;

    private float fixedMusicVolume = 0.2f;
    private float fixedSoundVolume = 0.3f;
    public void Awake()
    {
        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.pitch = s.pitch;
            s.source.volume = s.volume;
            s.source.loop = s.loop;
        }
    }
    public void Start()
    {
        Play("Theme");
        AddSoundToAllButtons();
    }
    public void Play(string name)
    {
        Sound sound = null;
        foreach(Sound s in sounds)
        {
            if(s.name == name)
            {
                sound = s;
            }
        }
        if(sound==null){return;}
        sound.source.Play();
    }
    public void MuteAllSounds()
    {
        foreach(Sound s in sounds)
        {
            if(s.name== "Theme"){continue;}
            s.source.volume = 0;
        }
    }
    public void VolumeUpAllSounds()
    {
        foreach(Sound s in sounds)
        {
            if(s.name == "Theme"){continue;}
            s.source.volume = fixedMusicVolume;
        }
    }
    public void AddSoundToAllButtons()
    {
        foreach(Button b in buttons)
        {
            b.onClick.AddListener(delegate {Play("Button"); });
        }
    }
    public void Mute(string name)
    {
        foreach (Sound s in sounds)
        {
            if(s.name == name)
            {
                s.source.volume = 0;
            }
        }
    }
    public void VolumeUp(string name)
    {
        foreach (Sound s in sounds)
        {
            if(s.name == name)
            {
                s.source.volume = fixedSoundVolume;
            }
        }
    }
}
