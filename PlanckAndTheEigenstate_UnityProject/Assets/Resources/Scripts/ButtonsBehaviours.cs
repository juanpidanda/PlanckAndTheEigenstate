using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsBehaviours : MonoBehaviour
{
    public void CallLevelScene(int level)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void PauseButton(bool wantToPause)
    {
        GameManager.gameManagerInstance.PauseApp(wantToPause);
    }
    public void QuitAppButton()
    {
        GameManager.gameManagerInstance.CallAppQuit();
    }
    public void MainMenuButton()
    {
        GameManager.gameManagerInstance.CallGameScene(GameScenes.MAINMENU);
    }
    
}
