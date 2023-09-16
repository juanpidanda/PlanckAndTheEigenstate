using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [Header("Input System")]
    [SerializeField] PlayerInput userInput;

    [Tooltip("Outputs to read from other scripts")]
    [Header("Gameplay Outputs")]
    [SerializeField] internal int movementOutput;
    [SerializeField] internal bool jumpOutput;
    [SerializeField] internal bool primaryShotOutput;
    [SerializeField] internal bool primaryShotVarOutput;
    [SerializeField] internal bool secondaryShotOutput;
    [SerializeField] internal bool secondaryShotVarOutput;
    [SerializeField] float secondsToTurnOffOutputs = 0.5f;
    private void Awake()
    {
        if(userInput == null)
        {
            userInput = GetComponent<PlayerInput>();
        }
    }
    public void OnMovement(InputAction.CallbackContext inputValue)
    {
        movementOutput = (int)inputValue.ReadValue<Vector2>().x;
        if (GameManager.gameManagerInstance.wantInputDebug)
        {
            Debug.Log("Movement Action Called = " + inputValue.ReadValue<Vector2>().x.ToString());
        }
    }
    public void OnPrimaryShot(InputAction.CallbackContext primaryShotAction)
    {
        StartCoroutine(PrimaryShotCoroutine(primaryShotAction.phase));

        if (GameManager.gameManagerInstance.wantInputDebug)
        {
            switch (primaryShotAction.phase)
            {
                case InputActionPhase.Disabled:
                    Debug.Log("Primary Shoot Action Disabled");
                    break;
                case InputActionPhase.Waiting:
                    Debug.Log("Primary Shoot Action Waiting");
                    break;
                case InputActionPhase.Started:
                    Debug.Log("Primary Shoot Action Started");
                    break;
                case InputActionPhase.Performed:
                    Debug.Log("Primary Shoot Action Performed");
                    break;
                case InputActionPhase.Canceled:
                    Debug.Log("Primary Shoot Action Canceled");
                    break;
            }
        }
    }
    private IEnumerator PrimaryShotCoroutine(InputActionPhase inputActionPhase)
    {
        switch (inputActionPhase)
        {
            case InputActionPhase.Disabled:
                break;
            case InputActionPhase.Waiting:
                break;
            case InputActionPhase.Started:
                primaryShotOutput = true;
                yield return new WaitForSeconds(secondsToTurnOffOutputs);
                primaryShotOutput = false;
                break;
            case InputActionPhase.Performed:
                break;
            case InputActionPhase.Canceled:
                primaryShotVarOutput = true;
                yield return new WaitForSeconds(secondsToTurnOffOutputs);
                primaryShotVarOutput = false;
                break;
        }
    }
}
