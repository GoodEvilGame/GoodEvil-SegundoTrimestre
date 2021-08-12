using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicHandler : MonoBehaviour
{
    public AudioSource CorridorMusic;
    // Start is called before the first frame update
    void Play()
    {
        CorridorMusic.Play();
    }
    void Start()
    {
        Play();
    }
    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Music");
        if (objs.Length > 1)
        {
            Destroy(this.CorridorMusic);
        }

        DontDestroyOnLoad(this.CorridorMusic);
        CorridorMusic = GetComponent<AudioSource>();

    }
     void PlayMusic()
    {
        CorridorMusic.Play();
    }
    void StopMusic()
    {
        CorridorMusic.Stop();
    }
}
