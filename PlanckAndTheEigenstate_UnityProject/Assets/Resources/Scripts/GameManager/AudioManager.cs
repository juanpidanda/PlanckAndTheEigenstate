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

    public void SetSceneTheme()
    {
        switch (GameManager.gameManagerInstance.currentGameScene)
        {
            case GameScenes.MAINMENU:
                SetNewTheme(mainMenuClip);
                break;
            case GameScenes.LEVEL_01:
                SetNewTheme(level01Clip);
                break;
            case GameScenes.LEVEL_02:
                SetNewTheme(level02Clip);
                break;
            case GameScenes.LEVEL_03:
                SetNewTheme(level03Clip);
                break;
            case GameScenes.LEVEL_04:
                SetNewTheme(level04Clip);
                break;
            case GameScenes.CINEMATICS:
                SetNewTheme(mainMenuClip);
                break;
        }
    }
    void SetNewTheme(AudioClip themeToPlay)
    {
        if(soundtrackSource.clip != themeToPlay)
        {
            soundtrackSource.Stop();
            soundtrackSource.clip = themeToPlay;
            soundtrackSource.Play();
        }
    }
}
