using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] musicClips;
    public Sound[] sounds;

    public static AudioManager instance;

    private float timer;
    private Sound currentBGMusic;
    //private bool musicIsPlaying = false;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);

        foreach (Sound s in musicClips)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
        }

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
        }
    }

    private void Start()
    {
        timer = 0f;
        Debug.Log("Playing start music...");
        Play("music_active");
    }

    private void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;

        if (timer % 5 == 0)
        {
            Debug.Log($"{timer}s have passed, initiating check...");

            if (currentBGMusic.source != null && currentBGMusic.source.isPlaying)
            {
                Debug.Log($"Clip {currentBGMusic.name} is playing, skipping initialisation.");
                return;
            }
            else
            {
                Debug.Log("Nothing playing, starting new clip...");
                Play(musicClips[UnityEngine.Random.Range(0, musicClips.Length)]);
            }
        }
    }

    public void Play(string name)
    {
        Sound s = Array.Find(musicClips, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning($"Sound {name} not found.");
            return;
        }
        currentBGMusic = s;
        s.source.Play();
    }

    public void Play(Sound s)
    {
        if (s.clip == null)
        {
            Debug.LogWarning($"Sound {s.name} not found.");
            return;
        }
        currentBGMusic = s;
        s.source.Play();
    }


    void PlayBackgroundMusic()
    {
        //Debug.Log("Trying to play BG music...");
        //maybe add some fancy code that makes the appropriate theme play for
        //different situations

        if (currentBGMusic == null)
        {
            currentBGMusic = musicClips[UnityEngine.Random.Range(0, musicClips.Length)];
            Debug.Log($"Music clip selected: {currentBGMusic.name}; trying to play...");
            Play(currentBGMusic);
        }
            

        if (currentBGMusic.source.isPlaying)
            return;
        else
        {
            Debug.Log("Clip ended, resetting");
            timer = 0f;
            currentBGMusic = null;
        }
    }
}
