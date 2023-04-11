using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicSounds : MonoBehaviour
{
    public AudioClip[] clipsMusic;
    public AudioSource _sound;
    private int idSound = -1;
    private float volumeSound = 0.5f;
    public Slider volumeSoundSlider;

    void Start()
    {
        idSound = Random.Range(0, clipsMusic.Length);
        _sound.clip = clipsMusic[idSound];
        _sound.volume = volumeSound;
        _sound.Play();
    }

    void Update()
    {
        if (!_sound.isPlaying)
        {
            int i = Random.Range(0, clipsMusic.Length);
            while (idSound == i)
            {
                i = Random.Range(0, clipsMusic.Length);
            }
            idSound = i;
            _sound.clip = clipsMusic[idSound];
            _sound.Play();
        }
    }

    public  void CheckVolumeSlider()
    {
        volumeSound = volumeSoundSlider.value;
        _sound.volume = volumeSound;
    }
}
