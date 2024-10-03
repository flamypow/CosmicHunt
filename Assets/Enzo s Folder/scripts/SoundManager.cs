using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{       
    public static SoundManager instance;
    public AudioSource soundEffectSource;
    public AudioSource musicSource;
    public AudioClip[] soundEffects;
    public AudioClip[] musics;

    public void Awake() //another singleton to call this
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void PlaySound(int index)
    {
        if (index >= 0 && index < soundEffects.Length)
        {
            soundEffectSource.PlayOneShot(soundEffects[index]);
        }
    }
    public void PlayMusic(int index)
    {
        if (index >= 0 && index < musics.Length)
        {
            musicSource.clip = musics[index];
            musicSource.Play();
        }
        
    }
    public void StopMusic()
    {
        musicSource.Stop();
    }

}
