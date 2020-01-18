// GENERATED AUTOMATICALLY FROM 'Assets/Controller Scripts/InputMaster.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputMaster : IInputActionCollection, IDisposable
{
    private InputActionAsset asset;
    public @InputMaster()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputMaster"",
    ""maps"": [
        {
            ""name"": ""Ingame Controls"",
            ""id"": ""38e0b5e0-1c45-4533-bf59-a1b94f30d20c"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Button"",
                    ""id"": ""31ceb70e-6d5d-4227-a908-2323e21339e9"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Buttons"",
                    ""type"": ""Button"",
                    ""id"": ""fee19168-3e18-4fbb-b8d5-5f2b0b3298d4"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""04cfd0f0-bf87-44bb-9eda-8b5c4451da48"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Buttons"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8507943f-e6a6-4ce9-8e46-4afc811b9bb4"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Buttons"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a2a4addc-3af4-4c55-85f7-5ef13de2252d"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Buttons"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ba9d7eb9-cdaf-4640-a2aa-17a199e29820"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Buttons"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a019f0b3-3244-4d67-9405-c975d3d75ba6"",
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
                    ""id"": ""70ceacb3-8b0c-4ba5-8cd8-eb6d9f4da362"",
                    ""path"": ""<Gamepad>/dpad"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ca977e99-e296-418c-862c-6ede260379f3"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Buttons"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Ingame Controls
        m_IngameControls = asset.FindActionMap("Ingame Controls", throwIfNotFound: true);
        m_IngameControls_Movement = m_IngameControls.FindAction("Movement", throwIfNotFound: true);
        m_IngameControls_Buttons = m_IngameControls.FindAction("Buttons", throwIfNotFound: true);
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

    // Ingame Controls
    private readonly InputActionMap m_IngameControls;
    private IIngameControlsActions m_IngameControlsActionsCallbackInterface;
    private readonly InputAction m_IngameControls_Movement;
    private readonly InputAction m_IngameControls_Buttons;
    public struct IngameControlsActions
    {
        private @InputMaster m_Wrapper;
        public IngameControlsActions(@InputMaster wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_IngameControls_Movement;
        public InputAction @Buttons => m_Wrapper.m_IngameControls_Buttons;
        public InputActionMap Get() { return m_Wrapper.m_IngameControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(IngameControlsActions set) { return set.Get(); }
        public void SetCallbacks(IIngameControlsActions instance)
        {
            if (m_Wrapper.m_IngameControlsActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_IngameControlsActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_IngameControlsActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_IngameControlsActionsCallbackInterface.OnMovement;
                @Buttons.started -= m_Wrapper.m_IngameControlsActionsCallbackInterface.OnButtons;
                @Buttons.performed -= m_Wrapper.m_IngameControlsActionsCallbackInterface.OnButtons;
                @Buttons.canceled -= m_Wrapper.m_IngameControlsActionsCallbackInterface.OnButtons;
            }
            m_Wrapper.m_IngameControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Buttons.started += instance.OnButtons;
                @Buttons.performed += instance.OnButtons;
                @Buttons.canceled += instance.OnButtons;
            }
        }
    }
    public IngameControlsActions @IngameControls => new IngameControlsActions(this);
    public interface IIngameControlsActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnButtons(InputAction.CallbackContext context);
    }
}
