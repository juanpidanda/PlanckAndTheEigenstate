using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [Header("Input System")]
    [SerializeField] PlayerInput userInput;

    [Header("Gameplay Outputs; Outputs to read from other scripts")]
    [SerializeField] float secondsToTurnOffOutputs = 0.05f;
    [Header("Movemet Output")]
    [SerializeField] internal float movementOutput;
    [Header("Jump Output")]
    [SerializeField] internal bool jumpOutput;
    [Header("Primary Shot Outputs")]
    [SerializeField] internal bool primaryShotOutput;
    [SerializeField] internal bool primaryShotVarOutput;
    [Header("Secondary Shot Outputs")]
    [SerializeField] internal bool secondaryShotOutput;
    [SerializeField] internal bool secondaryShotVarOutput;
    [Header("Aiming Outputs")]
    [SerializeField] internal Vector2 aimingOutput;
    private void Awake()
    {
        if(userInput == null)
        {
            userInput = GetComponent<PlayerInput>();
        }
    }
    #region MOVEMENT FUNCTIONS
    public void OnMovement(InputAction.CallbackContext movementValue)
    {
        movementOutput = movementValue.ReadValue<Vector2>().x;
        if (movementOutput > 0.1f)
        {
            movementOutput = 1;
        }
        else if (movementOutput < -0.1f)
        {
            movementOutput = -1;
        }
        else
        {
            movementOutput = 0;
        }
        if (GameManager.gameManagerInstance.wantInputDebug)
        {
            Debug.Log("Movement Action Called = " + movementValue.ReadValue<Vector2>().x.ToString());
        }
    }
    #endregion

    #region JUMP FUNCTIONS
    public void OnJump(InputAction.CallbackContext jumpAction)
    {
        if (jumpAction.started)
        {
            StartCoroutine(JumpCoroutine());
        }
        if (GameManager.gameManagerInstance.wantInputDebug)
        {
            Debug.Log("Jump Action called");
        }
    }
    private IEnumerator JumpCoroutine()
    {
        jumpOutput = true;
        yield return new WaitForSeconds(secondsToTurnOffOutputs);
        jumpOutput = false;
    }
    #endregion

    #region PRIMARY SHOT FUNCTIONS
    public void OnPrimaryShot(InputAction.CallbackContext primaryShotAction)
    {
        StartCoroutine(PrimaryShotCoroutine(primaryShotAction.phase));

        if (GameManager.gameManagerInstance.wantInputDebug)
        {
            switch (primaryShotAction.phase)
            {
                case InputActionPhase.Disabled:
                    Debug.Log("Primary Shot Action Disabled");
                    break;
                case InputActionPhase.Waiting:
                    Debug.Log("Primary Shot Action Waiting");
                    break;
                case InputActionPhase.Started:
                    Debug.Log("Primary Shot Action Started");
                    break;
                case InputActionPhase.Performed:
                    Debug.Log("Primary Shot Action Performed");
                    break;
                case InputActionPhase.Canceled:
                    Debug.Log("Primary Shot Action Canceled");
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
    #endregion

    #region SECONDARY SHOT FUNCTIONS
    public void OnSecondaryShot(InputAction.CallbackContext secondaryShotAction)
    {
        StartCoroutine(SecondaryShotCoroutine(secondaryShotAction.phase));

        if (GameManager.gameManagerInstance.wantInputDebug)
        {
            switch (secondaryShotAction.phase)
            {
                case InputActionPhase.Disabled:
                    Debug.Log("Secondary Shot Action Disabled");
                    break;
                case InputActionPhase.Waiting:
                    Debug.Log("Secondary Shot Action Waiting");
                    break;
                case InputActionPhase.Started:
                    Debug.Log("Secondary Shot Action Started");
                    break;
                case InputActionPhase.Performed:
                    Debug.Log("Secondary Shot Action Performed");
                    break;
                case InputActionPhase.Canceled:
                    Debug.Log("Secondary Shot Action Canceled");
                    break;
            }
        }
    }
    private IEnumerator SecondaryShotCoroutine(InputActionPhase inputActionPhase)
    {
        switch (inputActionPhase)
        {
            case InputActionPhase.Disabled:
                break;
            case InputActionPhase.Waiting:
                break;
            case InputActionPhase.Started:
                secondaryShotOutput = true;
                yield return new WaitForSeconds(secondsToTurnOffOutputs);
                secondaryShotOutput = false;
                break;
            case InputActionPhase.Performed:
                break;
            case InputActionPhase.Canceled:
                secondaryShotVarOutput = true;
                yield return new WaitForSeconds(secondsToTurnOffOutputs);
                secondaryShotVarOutput = false;
                break;
        }
    }
    #endregion

    #region AIMING FUNCTIONS

    public void OnAiming(InputAction.CallbackContext aimingValue)
    {
        aimingOutput = aimingValue.ReadValue<Vector2>();

        if (GameManager.gameManagerInstance.wantInputDebug)
        {
            Debug.Log("Aiming Action Called = " + aimingValue.ReadValue<Vector2>());
        }
    }

    #endregion
}
