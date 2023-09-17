using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsBehaviours : MonoBehaviour
{
    public void CallLevelScene(int level)
    {
        GameManager.gameManagerInstance.CallGameScene(level);
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
