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
    private int nextCheckTime = 120;
    private int timerInterval = 30;
    public Sound currentBGMusic;
    public Sound currentSFX;
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
        Play("music_active", true);
    }

    private void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;

        if (timer > nextCheckTime)
        {
            Debug.Log($"{timer}s have passed, initiating check...");
            nextCheckTime += timerInterval;

            if (currentBGMusic.source != null && currentBGMusic.source.isPlaying)
            {
                Debug.Log($"Clip {currentBGMusic.name} is playing, skipping initialisation.");
                return;
            }
            else
            {
                Debug.Log("Nothing playing, starting new clip...");
                Play(musicClips[UnityEngine.Random.Range(0, musicClips.Length)], true);
            }
        }
    }

    public void Play(string name, bool isMusic)
    {
        Sound s = new();
        if (isMusic)
        {
            s = Array.Find(musicClips, sound => sound.name == name);
            if (s == null)
            {
                Debug.LogWarning($"Sound {name} not found.");
                return;
            }
            currentBGMusic = s;
        }
        else
        {
            s = Array.Find(sounds, sound => sound.name == name);
            if (s == null)
            {
                Debug.LogWarning($"Sound {name} not found.");
                return;
            }
            currentSFX = s;
        }
        s.source.Play();
        Debug.Log($"Now playing {s.name}");
    }

    public void Play(Sound s, bool isMusic)
    {
        if (s.clip == null)
        {
            Debug.LogWarning($"Sound {s.name} not found.");
            return;
        }
        if (isMusic)
            currentBGMusic = s;
        else
            currentSFX = s;

        s.source.Play();
        Debug.Log($"Now playing {s.name}");
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            s = Array.Find(musicClips, sound => sound.name == name);
            if (s == null)
            {
                Debug.LogWarning($"Sound {s.name} not found.");
            }
        }

        s.source.Stop();
//        Debug.Log($"Sound {name} could not be stopped, not playing.");
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
            Play(currentBGMusic, true);
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
