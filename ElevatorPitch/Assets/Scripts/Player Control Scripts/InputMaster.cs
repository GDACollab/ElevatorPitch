// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Player Control Scripts/InputMaster.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputMaster : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
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
                    ""type"": ""Value"",
                    ""id"": ""31ceb70e-6d5d-4227-a908-2323e21339e9"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""UpButton"",
                    ""type"": ""Button"",
                    ""id"": ""fee19168-3e18-4fbb-b8d5-5f2b0b3298d4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""DownButton"",
                    ""type"": ""Button"",
                    ""id"": ""77226a20-0485-4a54-9c3c-a2265bc72000"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LeftButton"",
                    ""type"": ""Button"",
                    ""id"": ""4a2f7287-840a-4f29-ab4d-b2e6046c998d"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightButton"",
                    ""type"": ""Button"",
                    ""id"": ""a98e73ac-6157-4c08-8f12-cce0cce7a89f"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Rotation"",
                    ""type"": ""Button"",
                    ""id"": ""ba371e1d-f62a-4e98-b6cd-9e214b17f9a2"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""8507943f-e6a6-4ce9-8e46-4afc811b9bb4"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UpButton"",
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
                    ""name"": ""2D Vector"",
                    ""id"": ""5dc61b23-c3e2-4e2c-be92-0db6a04032bd"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""48ef026e-0799-46b4-9383-91a1c36faeb3"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""472305a7-f56a-4c80-9565-f4be585b4f1f"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""1aa116ea-8d48-47e0-ad81-e0f14ab92949"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""5e4ad471-2cdc-461b-a235-f073c603e137"",
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
                    ""id"": ""04cfd0f0-bf87-44bb-9eda-8b5c4451da48"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DownButton"",
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
                    ""action"": ""LeftButton"",
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
                    ""action"": ""RightButton"",
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
                    ""action"": ""Rotation"",
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
        m_IngameControls_UpButton = m_IngameControls.FindAction("UpButton", throwIfNotFound: true);
        m_IngameControls_DownButton = m_IngameControls.FindAction("DownButton", throwIfNotFound: true);
        m_IngameControls_LeftButton = m_IngameControls.FindAction("LeftButton", throwIfNotFound: true);
        m_IngameControls_RightButton = m_IngameControls.FindAction("RightButton", throwIfNotFound: true);
        m_IngameControls_Rotation = m_IngameControls.FindAction("Rotation", throwIfNotFound: true);
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
    private readonly InputAction m_IngameControls_UpButton;
    private readonly InputAction m_IngameControls_DownButton;
    private readonly InputAction m_IngameControls_LeftButton;
    private readonly InputAction m_IngameControls_RightButton;
    private readonly InputAction m_IngameControls_Rotation;
    public struct IngameControlsActions
    {
        private @InputMaster m_Wrapper;
        public IngameControlsActions(@InputMaster wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_IngameControls_Movement;
        public InputAction @UpButton => m_Wrapper.m_IngameControls_UpButton;
        public InputAction @DownButton => m_Wrapper.m_IngameControls_DownButton;
        public InputAction @LeftButton => m_Wrapper.m_IngameControls_LeftButton;
        public InputAction @RightButton => m_Wrapper.m_IngameControls_RightButton;
        public InputAction @Rotation => m_Wrapper.m_IngameControls_Rotation;
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
                @UpButton.started -= m_Wrapper.m_IngameControlsActionsCallbackInterface.OnUpButton;
                @UpButton.performed -= m_Wrapper.m_IngameControlsActionsCallbackInterface.OnUpButton;
                @UpButton.canceled -= m_Wrapper.m_IngameControlsActionsCallbackInterface.OnUpButton;
                @DownButton.started -= m_Wrapper.m_IngameControlsActionsCallbackInterface.OnDownButton;
                @DownButton.performed -= m_Wrapper.m_IngameControlsActionsCallbackInterface.OnDownButton;
                @DownButton.canceled -= m_Wrapper.m_IngameControlsActionsCallbackInterface.OnDownButton;
                @LeftButton.started -= m_Wrapper.m_IngameControlsActionsCallbackInterface.OnLeftButton;
                @LeftButton.performed -= m_Wrapper.m_IngameControlsActionsCallbackInterface.OnLeftButton;
                @LeftButton.canceled -= m_Wrapper.m_IngameControlsActionsCallbackInterface.OnLeftButton;
                @RightButton.started -= m_Wrapper.m_IngameControlsActionsCallbackInterface.OnRightButton;
                @RightButton.performed -= m_Wrapper.m_IngameControlsActionsCallbackInterface.OnRightButton;
                @RightButton.canceled -= m_Wrapper.m_IngameControlsActionsCallbackInterface.OnRightButton;
                @Rotation.started -= m_Wrapper.m_IngameControlsActionsCallbackInterface.OnRotation;
                @Rotation.performed -= m_Wrapper.m_IngameControlsActionsCallbackInterface.OnRotation;
                @Rotation.canceled -= m_Wrapper.m_IngameControlsActionsCallbackInterface.OnRotation;
            }
            m_Wrapper.m_IngameControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @UpButton.started += instance.OnUpButton;
                @UpButton.performed += instance.OnUpButton;
                @UpButton.canceled += instance.OnUpButton;
                @DownButton.started += instance.OnDownButton;
                @DownButton.performed += instance.OnDownButton;
                @DownButton.canceled += instance.OnDownButton;
                @LeftButton.started += instance.OnLeftButton;
                @LeftButton.performed += instance.OnLeftButton;
                @LeftButton.canceled += instance.OnLeftButton;
                @RightButton.started += instance.OnRightButton;
                @RightButton.performed += instance.OnRightButton;
                @RightButton.canceled += instance.OnRightButton;
                @Rotation.started += instance.OnRotation;
                @Rotation.performed += instance.OnRotation;
                @Rotation.canceled += instance.OnRotation;
            }
        }
    }
    public IngameControlsActions @IngameControls => new IngameControlsActions(this);
    public interface IIngameControlsActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnUpButton(InputAction.CallbackContext context);
        void OnDownButton(InputAction.CallbackContext context);
        void OnLeftButton(InputAction.CallbackContext context);
        void OnRightButton(InputAction.CallbackContext context);
        void OnRotation(InputAction.CallbackContext context);
    }
}
