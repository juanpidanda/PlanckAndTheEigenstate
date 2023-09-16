//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.6.3
//     from Assets/Resources/Scripts/GameManager/UserInputActions.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @UserInputActions: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @UserInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""UserInputActions"",
    ""maps"": [
        {
            ""name"": ""CharacterActionMap"",
            ""id"": ""e8b3163c-5a64-4452-b397-704928ed9e2a"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""da87f43b-7936-4b25-a63b-7c3b0cfdfe91"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""43362d9c-00ca-40ab-8e5d-1f9bfb89a9e2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ParticleShoot"",
                    ""type"": ""Button"",
                    ""id"": ""5acc5c47-4323-4c81-bd83-ba90a2d49dca"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""WaveShoot"",
                    ""type"": ""Button"",
                    ""id"": ""d3f402a7-e304-4e15-98b4-e8de9b9bc8a4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2DVector"",
                    ""id"": ""46c48ee6-67ca-4092-836f-a7e5e6b900e0"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Left"",
                    ""id"": ""84ddd40c-d087-4d67-8006-2264c9f4b0e5"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Right"",
                    ""id"": ""dfe08f59-6a04-4798-b576-a8c8e0a07161"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""0feb08e9-d2aa-4496-b7f6-b6709c45441a"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2e7d49c0-87c1-438c-aea8-d167cbc75cd8"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7d8065ec-92c3-4a06-ab9b-4d2d58e4a948"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ParticleShoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""daac7d66-2d31-4c45-8f81-cdb998ff90be"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WaveShoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // CharacterActionMap
        m_CharacterActionMap = asset.FindActionMap("CharacterActionMap", throwIfNotFound: true);
        m_CharacterActionMap_Movement = m_CharacterActionMap.FindAction("Movement", throwIfNotFound: true);
        m_CharacterActionMap_Jump = m_CharacterActionMap.FindAction("Jump", throwIfNotFound: true);
        m_CharacterActionMap_ParticleShoot = m_CharacterActionMap.FindAction("ParticleShoot", throwIfNotFound: true);
        m_CharacterActionMap_WaveShoot = m_CharacterActionMap.FindAction("WaveShoot", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // CharacterActionMap
    private readonly InputActionMap m_CharacterActionMap;
    private List<ICharacterActionMapActions> m_CharacterActionMapActionsCallbackInterfaces = new List<ICharacterActionMapActions>();
    private readonly InputAction m_CharacterActionMap_Movement;
    private readonly InputAction m_CharacterActionMap_Jump;
    private readonly InputAction m_CharacterActionMap_ParticleShoot;
    private readonly InputAction m_CharacterActionMap_WaveShoot;
    public struct CharacterActionMapActions
    {
        private @UserInputActions m_Wrapper;
        public CharacterActionMapActions(@UserInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_CharacterActionMap_Movement;
        public InputAction @Jump => m_Wrapper.m_CharacterActionMap_Jump;
        public InputAction @ParticleShoot => m_Wrapper.m_CharacterActionMap_ParticleShoot;
        public InputAction @WaveShoot => m_Wrapper.m_CharacterActionMap_WaveShoot;
        public InputActionMap Get() { return m_Wrapper.m_CharacterActionMap; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CharacterActionMapActions set) { return set.Get(); }
        public void AddCallbacks(ICharacterActionMapActions instance)
        {
            if (instance == null || m_Wrapper.m_CharacterActionMapActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_CharacterActionMapActionsCallbackInterfaces.Add(instance);
            @Movement.started += instance.OnMovement;
            @Movement.performed += instance.OnMovement;
            @Movement.canceled += instance.OnMovement;
            @Jump.started += instance.OnJump;
            @Jump.performed += instance.OnJump;
            @Jump.canceled += instance.OnJump;
            @ParticleShoot.started += instance.OnParticleShoot;
            @ParticleShoot.performed += instance.OnParticleShoot;
            @ParticleShoot.canceled += instance.OnParticleShoot;
            @WaveShoot.started += instance.OnWaveShoot;
            @WaveShoot.performed += instance.OnWaveShoot;
            @WaveShoot.canceled += instance.OnWaveShoot;
        }

        private void UnregisterCallbacks(ICharacterActionMapActions instance)
        {
            @Movement.started -= instance.OnMovement;
            @Movement.performed -= instance.OnMovement;
            @Movement.canceled -= instance.OnMovement;
            @Jump.started -= instance.OnJump;
            @Jump.performed -= instance.OnJump;
            @Jump.canceled -= instance.OnJump;
            @ParticleShoot.started -= instance.OnParticleShoot;
            @ParticleShoot.performed -= instance.OnParticleShoot;
            @ParticleShoot.canceled -= instance.OnParticleShoot;
            @WaveShoot.started -= instance.OnWaveShoot;
            @WaveShoot.performed -= instance.OnWaveShoot;
            @WaveShoot.canceled -= instance.OnWaveShoot;
        }

        public void RemoveCallbacks(ICharacterActionMapActions instance)
        {
            if (m_Wrapper.m_CharacterActionMapActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(ICharacterActionMapActions instance)
        {
            foreach (var item in m_Wrapper.m_CharacterActionMapActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_CharacterActionMapActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public CharacterActionMapActions @CharacterActionMap => new CharacterActionMapActions(this);
    public interface ICharacterActionMapActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnParticleShoot(InputAction.CallbackContext context);
        void OnWaveShoot(InputAction.CallbackContext context);
    }
}