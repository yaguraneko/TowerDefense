using UnityEngine;
using System;
using TMPro;


public static class GlobalData
{
    public static int wave = 0, Money = 100;
    public static bool lose = false;
    public static Action NextWave;
    public static TextMeshProUGUI MoneyText, hleathText;
    public static int AliveSlimes = 0;
    public static int PlayerHP = 200;
    public static GameObject GameOver;
    private static GameObject sfx;


    public static void AudioManager(AudioClip clip, Vector3 pos, float volume=1, float pitch=1, bool loop=false, float spatialBlend=0)
    {
        if (sfx != null)
            return;
        GameObject audioSource = new GameObject("AudioSource");
        var sound = audioSource.AddComponent<AudioSource>();
        sound.clip = clip;
        sound.volume = volume;
        sound.pitch = pitch;
        sound.loop = loop;
        sound.spatialBlend = spatialBlend;
        sound.Play();
        sfx = audioSource;
        UnityEngine.Object.Destroy(audioSource, clip.length);
    }
    
}