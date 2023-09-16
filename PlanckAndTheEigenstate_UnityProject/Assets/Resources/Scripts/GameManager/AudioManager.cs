using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("OST")]
    [SerializeField] AudioSource soundtrackSource;
    [Header("Themes")]
    [SerializeField] internal AudioClip mainMenuClip;
    [SerializeField] internal AudioClip level01Clip, level02Clip, level03Clip, level04Clip;

    public void SetNewTheme(AudioClip themeToPlay)
    {
        if(soundtrackSource.clip != themeToPlay)
        {
            soundtrackSource.Stop();
            soundtrackSource.clip = themeToPlay;
            soundtrackSource.Play();
        }
    }
}
