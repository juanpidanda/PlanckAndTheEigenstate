using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameScenes
{
    MAINMENU,
    LEVEL_01,
    LEVEL_02,
    LEVEL_03,
    LEVEL_04,
    CINEMATICS
}
public enum SceneState
{
    STARTING,
    PLAYING,
    ONPAUSE,
    ENDING
}
public class GameManager : MonoBehaviour
{
    public static GameManager gameManagerInstance;
    [Header("Debug Options")]
    public bool wantGeneralDebug;
    public bool wantInputDebug;
    public bool wantSettingsDebug;
    public bool wantPlayerDebug;

    [Header("Scene Data")]
    [SerializeField] GameScenes currentGameScene;
    [SerializeField] SceneState currentSceneState;
    SceneState lastSceneState;

    [Header("Management")]
    [SerializeField] internal InputManager inputManager;
    [SerializeField] internal AudioManager audioManager;
    //[SerializeField] internal SettingsManager SettingsManager;

    void Awake()
    {
        CheckGameManagerInstance();
        GetManagers();
    }
    /// <summary>
    /// Check if gameManagerInstance exists, if yes destroy this, if not create an instance
    /// </summary>
    void CheckGameManagerInstance()
    {
        if (gameManagerInstance == null)
        {
            gameManagerInstance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        CurrentSceneStartPhase();
    }

    /// <summary>
    /// Get Managers if null for each gamesubmanagers
    /// </summary>
    void GetManagers()
    {
        if(inputManager == null)
        {
            inputManager = GetComponent<InputManager>();
        }
        if(audioManager == null)
        {
            audioManager = GetComponent<AudioManager>();
        }

        if (wantGeneralDebug)
        {
            if(inputManager == null)
            {
                Debug.Log("Input manager is missing");
            }
            if(audioManager == null)
            {
                Debug.Log("Audio Manager is missing");
            }
        }
    }

    #region SCENE MANAGMENT
    void SetNextScene(GameScenes sceneToSet)
    {
        CurrentSceneEndPhase();
        currentGameScene = sceneToSet;
        if (wantGeneralDebug)
        {
            Debug.Log("Loading " + sceneToSet.ToString() + " Scene");
        }
        SceneManager.LoadScene((int)sceneToSet);
        //CurrentSceneStartPhase();
    }
    void CurrentSceneStartPhase()
    {
        currentSceneState = SceneState.STARTING;
        switch (currentGameScene)
        {
            case GameScenes.MAINMENU:
                audioManager.SetNewTheme(audioManager.mainMenuClip);
                break;
            case GameScenes.LEVEL_01:
                audioManager.SetNewTheme(audioManager.level01Clip);
                break;
            case GameScenes.LEVEL_02:
                audioManager.SetNewTheme(audioManager.level02Clip);
                break;
            case GameScenes.LEVEL_03:
                audioManager.SetNewTheme(audioManager.level03Clip);
                break;
            case GameScenes.LEVEL_04:
                audioManager.SetNewTheme(audioManager.level04Clip);
                break;
            case GameScenes.CINEMATICS:
                audioManager.SetNewTheme(audioManager.mainMenuClip);
                break;
        }
        currentSceneState = SceneState.PLAYING;
    }
    void CurrentSceneEndPhase()
    {
        switch (currentGameScene)
        {
            case GameScenes.MAINMENU:
                break;
            case GameScenes.LEVEL_01:
                break;
            case GameScenes.LEVEL_02:
                break;
            case GameScenes.LEVEL_03:
                break;
            case GameScenes.LEVEL_04:
                break;
            case GameScenes.CINEMATICS:
                break;
        }
    }
    #endregion

    #region PUBLIC CALLS
    public void PauseApp(bool ispausing)
    {
        if (ispausing)
        {
            lastSceneState = currentSceneState;
            Time.timeScale = 0.0f;
            currentSceneState = SceneState.ONPAUSE;
        }
        else
        {
            Time.timeScale = 1.0f;
            currentSceneState = lastSceneState;
        }
    }
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void CallGameScene(GameScenes gameSceneToCall)
    {
        SetNextScene(gameSceneToCall);
    }
    public void CallGameScene(int sceneIndex)
    {
        switch (sceneIndex)
        {
            case 0:
                SetNextScene(GameScenes.MAINMENU);
                break;
            case 1:
                SetNextScene(GameScenes.LEVEL_01);
                break;
            case 2:
                SetNextScene(GameScenes.LEVEL_02);
                break;
            case 3:
                SetNextScene(GameScenes.LEVEL_03);
                break;
            case 4:
                SetNextScene(GameScenes.LEVEL_04);
                break;
        }
    }
    public void CallAppQuit()
    {
        CurrentSceneEndPhase();
        Application.Quit();
    }
    #endregion

    private void OnApplicationFocus(bool isFocus)
    {
        if (isFocus)
        {
            PauseApp(false);
        }
        else
        {
            PauseApp(true);
        }
    }
}
