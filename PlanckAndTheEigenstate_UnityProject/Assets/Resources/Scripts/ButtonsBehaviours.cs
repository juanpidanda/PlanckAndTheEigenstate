using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsBehaviours : MonoBehaviour
{
    public void CallLevelScene(int level)
    {
        GameManager.gameManagerInstance.CallGameScene(level);
    }
    public void CallPause(bool wantToPause)
    {
        GameManager.gameManagerInstance.PauseApp(wantToPause);
    }
}
