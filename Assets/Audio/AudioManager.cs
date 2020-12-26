using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager _instance;
    public static AudioManager Instance { get { return _instance; } }
    
    [Header("Assignment")]
    public AudioSource PlayerAudioSource;
    public AudioSource Heartbeat;
    public Transform Enemy;
    public Transform Player;

    [Header("Interaction Sounds")]
    public AudioClip flashlightClick;
    public AudioClip doorLocked;
    public AudioClip doorUnlock;
    public AudioClip heartbeats;
    public AudioClip generaotrSwitch;
    public AudioClip jerryCan;
    public AudioClip keys;
    public AudioClip lightSwitch;
    public AudioClip oilPour;
    public AudioClip paper;
    

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    private void Update()
    {
        HeartBeats();
    }

    public void FlashLightClick()
    {
        PlayerAudioSource.clip = flashlightClick;
        PlayerAudioSource.Play();
    }

    public void DoorLocked()
    {
        PlayerAudioSource.clip = doorLocked;
        PlayerAudioSource.Play();
    }

    public void DoorUnlock()
    {
        PlayerAudioSource.clip = doorUnlock;
        PlayerAudioSource.Play();
    }


    public void HeartBeats()
    {
        float dist = Vector3.Distance(Player.position, Enemy.position);
        print(dist);
        if(dist < 20)
        {
            Heartbeat.volume = 0.1f + 0.9f * (1f-dist / 20f);
            Heartbeat.pitch = 1f + 0.2f *(1f- dist / 20f);
        }
        else
        {
            Heartbeat.volume = 0.1f ;
            Heartbeat.pitch = 1f ;
        }
        
    }

    public void GeneratorSwitch()
    {
        PlayerAudioSource.clip = generaotrSwitch;
        PlayerAudioSource.Play();
    }

    public void JerryCan()
    {
        PlayerAudioSource.clip = jerryCan;
        PlayerAudioSource.Play();
    }

    public void Keys()
    {
        PlayerAudioSource.clip = keys;
        PlayerAudioSource.Play();
    }

    public void LightSwitch()
    {
        PlayerAudioSource.clip = lightSwitch;
        PlayerAudioSource.Play();
    }

    public void OilPour()
    {
        PlayerAudioSource.clip = oilPour;
        PlayerAudioSource.Play();
    }

    public void Paper()
    {
        PlayerAudioSource.clip = paper;
        PlayerAudioSource.Play();
    }

}
