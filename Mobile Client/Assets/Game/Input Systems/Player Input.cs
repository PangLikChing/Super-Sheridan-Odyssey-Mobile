//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.2.0
//     from Assets/Game/Input Systems/Player Input.inputactions
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

public partial class @PlayerInput : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Player Input"",
    ""maps"": [
        {
            ""name"": ""Mobile Input"",
            ""id"": ""bc7a90cd-ba26-4cdf-96a2-4b094c31cc9d"",
            ""actions"": [
                {
                    ""name"": ""Touch 0"",
                    ""type"": ""PassThrough"",
                    ""id"": ""ef774f28-0a21-478d-8694-a238b15b37d0"",
                    ""expectedControlType"": ""Touch"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Touch 1"",
                    ""type"": ""PassThrough"",
                    ""id"": ""25c37c4d-70ac-45af-b06c-099bbc49038e"",
                    ""expectedControlType"": ""Touch"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""7c718f94-6279-4d6d-9a19-1922f2ce121e"",
                    ""path"": ""<Touchscreen>/touch0"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Touch 0"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6b185a37-55db-4ff2-ad10-40c870bc2751"",
                    ""path"": ""<Touchscreen>/touch1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Touch 1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Mobile Input
        m_MobileInput = asset.FindActionMap("Mobile Input", throwIfNotFound: true);
        m_MobileInput_Touch0 = m_MobileInput.FindAction("Touch 0", throwIfNotFound: true);
        m_MobileInput_Touch1 = m_MobileInput.FindAction("Touch 1", throwIfNotFound: true);
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

    // Mobile Input
    private readonly InputActionMap m_MobileInput;
    private IMobileInputActions m_MobileInputActionsCallbackInterface;
    private readonly InputAction m_MobileInput_Touch0;
    private readonly InputAction m_MobileInput_Touch1;
    public struct MobileInputActions
    {
        private @PlayerInput m_Wrapper;
        public MobileInputActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Touch0 => m_Wrapper.m_MobileInput_Touch0;
        public InputAction @Touch1 => m_Wrapper.m_MobileInput_Touch1;
        public InputActionMap Get() { return m_Wrapper.m_MobileInput; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MobileInputActions set) { return set.Get(); }
        public void SetCallbacks(IMobileInputActions instance)
        {
            if (m_Wrapper.m_MobileInputActionsCallbackInterface != null)
            {
                @Touch0.started -= m_Wrapper.m_MobileInputActionsCallbackInterface.OnTouch0;
                @Touch0.performed -= m_Wrapper.m_MobileInputActionsCallbackInterface.OnTouch0;
                @Touch0.canceled -= m_Wrapper.m_MobileInputActionsCallbackInterface.OnTouch0;
                @Touch1.started -= m_Wrapper.m_MobileInputActionsCallbackInterface.OnTouch1;
                @Touch1.performed -= m_Wrapper.m_MobileInputActionsCallbackInterface.OnTouch1;
                @Touch1.canceled -= m_Wrapper.m_MobileInputActionsCallbackInterface.OnTouch1;
            }
            m_Wrapper.m_MobileInputActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Touch0.started += instance.OnTouch0;
                @Touch0.performed += instance.OnTouch0;
                @Touch0.canceled += instance.OnTouch0;
                @Touch1.started += instance.OnTouch1;
                @Touch1.performed += instance.OnTouch1;
                @Touch1.canceled += instance.OnTouch1;
            }
        }
    }
    public MobileInputActions @MobileInput => new MobileInputActions(this);

    public object Touch { get; internal set; }

    public interface IMobileInputActions
    {
        void OnTouch0(InputAction.CallbackContext context);
        void OnTouch1(InputAction.CallbackContext context);
    }
}
