//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Input Manager/PlayerControls.inputactions
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

public partial class @PlayerControls: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Character "",
            ""id"": ""120eda51-de0c-4090-bcfa-16c57844dfec"",
            ""actions"": [
                {
                    ""name"": ""Fire"",
                    ""type"": ""Button"",
                    ""id"": ""8c5b8cee-af57-4c74-bf87-3e96823def6e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""88d0dd60-817f-48ab-80a0-2aabaf71d11f"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Aim"",
                    ""type"": ""Value"",
                    ""id"": ""9c6cc80c-f2bf-4223-a97d-5a82e2ecdf2d"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Run"",
                    ""type"": ""Button"",
                    ""id"": ""322208ec-277c-4b80-bbe3-61aba45a2ce4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Equip Slot - 1"",
                    ""type"": ""Button"",
                    ""id"": ""6536ba8c-158c-4b21-abf6-f0dfbcbc0a09"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Equip Slot - 2"",
                    ""type"": ""Button"",
                    ""id"": ""d3ea4687-0e83-4ef7-b414-e49c0dabcace"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Equip Slot - 3"",
                    ""type"": ""Button"",
                    ""id"": ""5d2cf7da-3389-430b-87b1-5b2d2c1c5b28"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Equip Slot - 4"",
                    ""type"": ""Button"",
                    ""id"": ""4b2165b9-b1d3-45d2-bf03-b1eb1ef5d4de"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Equip Slot - 5"",
                    ""type"": ""Button"",
                    ""id"": ""3190df3f-6199-4db2-9ed4-545ac57f653a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Drop Current Weapon"",
                    ""type"": ""Button"",
                    ""id"": ""657d131c-aaa1-42bb-8d0f-23f052c419f2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Reload"",
                    ""type"": ""Button"",
                    ""id"": ""2ab53d65-92fc-42a8-913c-b4eb5fa5546d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Toogle Weapon Mode"",
                    ""type"": ""Button"",
                    ""id"": ""a66fb886-267b-46da-8670-a45d89128af1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Interaction"",
                    ""type"": ""Button"",
                    ""id"": ""531c33b9-acc0-4d36-a2e6-763bc64d6bc1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""UI Mission ToolTip Switch"",
                    ""type"": ""Button"",
                    ""id"": ""a5c9aac9-9f88-4ba0-b988-2cc6b7ba00d1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""UI Pause"",
                    ""type"": ""Button"",
                    ""id"": ""b93a2be4-711c-4e1a-9dc5-a0cc8d7fd558"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""02407c90-cf5c-4a3d-9733-6c0069ab2bcb"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""c86e3601-b0aa-49a2-b7d8-c5f005fd3fec"",
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
                    ""id"": ""702c50b6-e87a-40ad-bcfa-77be549fc99b"",
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
                    ""id"": ""d95e7516-150f-4844-85fb-16b3a806096c"",
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
                    ""id"": ""f61d35e1-bc82-4dfb-afdf-307c6486d2d3"",
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
                    ""id"": ""1ab3a667-acdd-405b-9e7d-fe65c31a4660"",
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
                    ""id"": ""2e275601-cbb2-4711-b098-6fa49c0725c9"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d43a758b-cece-4b97-926c-7e79a949430a"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""de5eb120-9aa7-4610-a883-80a648980409"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Equip Slot - 1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""64633af6-c745-456d-9152-195b7c2f7829"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Equip Slot - 2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e3b4af53-fb92-4aed-8f97-bbd14b5e09e0"",
                    ""path"": ""<Keyboard>/g"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Drop Current Weapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b6845d16-f29e-4d90-95f2-78e5d7601496"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Reload"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f7e96240-2651-4a58-bf42-e171a24d5a9a"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Equip Slot - 3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ad9d2f0a-fdf8-40b2-afec-f9e64ece875d"",
                    ""path"": ""<Keyboard>/4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Equip Slot - 4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fe43fbd9-44a8-493a-8b2b-9e62c3332ee3"",
                    ""path"": ""<Keyboard>/5"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Equip Slot - 5"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""736ea05c-536c-4703-bd44-033c4d05f723"",
                    ""path"": ""<Keyboard>/t"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Toogle Weapon Mode"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fc3fbabe-a9da-441a-90f4-34e7910d90f0"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interaction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e046bfd5-d6f2-4844-8fe1-8dc0ecb50026"",
                    ""path"": ""<Keyboard>/h"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UI Mission ToolTip Switch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3f1e4a94-3a5a-40b6-a78b-42d2f499c380"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UI Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UI"",
            ""id"": ""5c0a07a7-0ea0-4720-8828-a33289b46e8c"",
            ""actions"": [
                {
                    ""name"": ""UI Pause"",
                    ""type"": ""Button"",
                    ""id"": ""b30110c4-d156-46e0-a5b4-60e006d10e42"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""29bc2e3f-22ae-44f1-a11b-1efdc3346238"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UI Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Car"",
            ""id"": ""c812285a-9dbb-4b6f-a26e-eee229618d94"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""f6cefce3-9373-4a55-975e-3eb9f1b27bd5"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""CarExit"",
                    ""type"": ""Button"",
                    ""id"": ""27ea6c3e-d824-44eb-b51a-ea97854554d6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Brake"",
                    ""type"": ""Button"",
                    ""id"": ""95b6a74a-0a28-45ae-bac7-21f2468b4013"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""0b53bd74-f5f5-4b40-87bc-efcd12031739"",
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
                    ""id"": ""27c6c768-f827-4f17-acdc-56393eaba518"",
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
                    ""id"": ""adc7acc3-dafb-4e16-b74b-493c84e01a8e"",
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
                    ""id"": ""1353ceea-a7eb-4b21-92ae-d74a78db31b9"",
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
                    ""id"": ""eba9efb9-6c75-4b1d-b02f-f389f4fdd0cf"",
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
                    ""id"": ""5b92fb43-f359-487e-9a02-9c0525b193ae"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CarExit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""99b1a15e-e55f-4f37-af8b-d6dedf42ba92"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Brake"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Character 
        m_Character = asset.FindActionMap("Character ", throwIfNotFound: true);
        m_Character_Fire = m_Character.FindAction("Fire", throwIfNotFound: true);
        m_Character_Movement = m_Character.FindAction("Movement", throwIfNotFound: true);
        m_Character_Aim = m_Character.FindAction("Aim", throwIfNotFound: true);
        m_Character_Run = m_Character.FindAction("Run", throwIfNotFound: true);
        m_Character_EquipSlot1 = m_Character.FindAction("Equip Slot - 1", throwIfNotFound: true);
        m_Character_EquipSlot2 = m_Character.FindAction("Equip Slot - 2", throwIfNotFound: true);
        m_Character_EquipSlot3 = m_Character.FindAction("Equip Slot - 3", throwIfNotFound: true);
        m_Character_EquipSlot4 = m_Character.FindAction("Equip Slot - 4", throwIfNotFound: true);
        m_Character_EquipSlot5 = m_Character.FindAction("Equip Slot - 5", throwIfNotFound: true);
        m_Character_DropCurrentWeapon = m_Character.FindAction("Drop Current Weapon", throwIfNotFound: true);
        m_Character_Reload = m_Character.FindAction("Reload", throwIfNotFound: true);
        m_Character_ToogleWeaponMode = m_Character.FindAction("Toogle Weapon Mode", throwIfNotFound: true);
        m_Character_Interaction = m_Character.FindAction("Interaction", throwIfNotFound: true);
        m_Character_UIMissionToolTipSwitch = m_Character.FindAction("UI Mission ToolTip Switch", throwIfNotFound: true);
        m_Character_UIPause = m_Character.FindAction("UI Pause", throwIfNotFound: true);
        // UI
        m_UI = asset.FindActionMap("UI", throwIfNotFound: true);
        m_UI_UIPause = m_UI.FindAction("UI Pause", throwIfNotFound: true);
        // Car
        m_Car = asset.FindActionMap("Car", throwIfNotFound: true);
        m_Car_Movement = m_Car.FindAction("Movement", throwIfNotFound: true);
        m_Car_CarExit = m_Car.FindAction("CarExit", throwIfNotFound: true);
        m_Car_Brake = m_Car.FindAction("Brake", throwIfNotFound: true);
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

    // Character 
    private readonly InputActionMap m_Character;
    private List<ICharacterActions> m_CharacterActionsCallbackInterfaces = new List<ICharacterActions>();
    private readonly InputAction m_Character_Fire;
    private readonly InputAction m_Character_Movement;
    private readonly InputAction m_Character_Aim;
    private readonly InputAction m_Character_Run;
    private readonly InputAction m_Character_EquipSlot1;
    private readonly InputAction m_Character_EquipSlot2;
    private readonly InputAction m_Character_EquipSlot3;
    private readonly InputAction m_Character_EquipSlot4;
    private readonly InputAction m_Character_EquipSlot5;
    private readonly InputAction m_Character_DropCurrentWeapon;
    private readonly InputAction m_Character_Reload;
    private readonly InputAction m_Character_ToogleWeaponMode;
    private readonly InputAction m_Character_Interaction;
    private readonly InputAction m_Character_UIMissionToolTipSwitch;
    private readonly InputAction m_Character_UIPause;
    public struct CharacterActions
    {
        private @PlayerControls m_Wrapper;
        public CharacterActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Fire => m_Wrapper.m_Character_Fire;
        public InputAction @Movement => m_Wrapper.m_Character_Movement;
        public InputAction @Aim => m_Wrapper.m_Character_Aim;
        public InputAction @Run => m_Wrapper.m_Character_Run;
        public InputAction @EquipSlot1 => m_Wrapper.m_Character_EquipSlot1;
        public InputAction @EquipSlot2 => m_Wrapper.m_Character_EquipSlot2;
        public InputAction @EquipSlot3 => m_Wrapper.m_Character_EquipSlot3;
        public InputAction @EquipSlot4 => m_Wrapper.m_Character_EquipSlot4;
        public InputAction @EquipSlot5 => m_Wrapper.m_Character_EquipSlot5;
        public InputAction @DropCurrentWeapon => m_Wrapper.m_Character_DropCurrentWeapon;
        public InputAction @Reload => m_Wrapper.m_Character_Reload;
        public InputAction @ToogleWeaponMode => m_Wrapper.m_Character_ToogleWeaponMode;
        public InputAction @Interaction => m_Wrapper.m_Character_Interaction;
        public InputAction @UIMissionToolTipSwitch => m_Wrapper.m_Character_UIMissionToolTipSwitch;
        public InputAction @UIPause => m_Wrapper.m_Character_UIPause;
        public InputActionMap Get() { return m_Wrapper.m_Character; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CharacterActions set) { return set.Get(); }
        public void AddCallbacks(ICharacterActions instance)
        {
            if (instance == null || m_Wrapper.m_CharacterActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_CharacterActionsCallbackInterfaces.Add(instance);
            @Fire.started += instance.OnFire;
            @Fire.performed += instance.OnFire;
            @Fire.canceled += instance.OnFire;
            @Movement.started += instance.OnMovement;
            @Movement.performed += instance.OnMovement;
            @Movement.canceled += instance.OnMovement;
            @Aim.started += instance.OnAim;
            @Aim.performed += instance.OnAim;
            @Aim.canceled += instance.OnAim;
            @Run.started += instance.OnRun;
            @Run.performed += instance.OnRun;
            @Run.canceled += instance.OnRun;
            @EquipSlot1.started += instance.OnEquipSlot1;
            @EquipSlot1.performed += instance.OnEquipSlot1;
            @EquipSlot1.canceled += instance.OnEquipSlot1;
            @EquipSlot2.started += instance.OnEquipSlot2;
            @EquipSlot2.performed += instance.OnEquipSlot2;
            @EquipSlot2.canceled += instance.OnEquipSlot2;
            @EquipSlot3.started += instance.OnEquipSlot3;
            @EquipSlot3.performed += instance.OnEquipSlot3;
            @EquipSlot3.canceled += instance.OnEquipSlot3;
            @EquipSlot4.started += instance.OnEquipSlot4;
            @EquipSlot4.performed += instance.OnEquipSlot4;
            @EquipSlot4.canceled += instance.OnEquipSlot4;
            @EquipSlot5.started += instance.OnEquipSlot5;
            @EquipSlot5.performed += instance.OnEquipSlot5;
            @EquipSlot5.canceled += instance.OnEquipSlot5;
            @DropCurrentWeapon.started += instance.OnDropCurrentWeapon;
            @DropCurrentWeapon.performed += instance.OnDropCurrentWeapon;
            @DropCurrentWeapon.canceled += instance.OnDropCurrentWeapon;
            @Reload.started += instance.OnReload;
            @Reload.performed += instance.OnReload;
            @Reload.canceled += instance.OnReload;
            @ToogleWeaponMode.started += instance.OnToogleWeaponMode;
            @ToogleWeaponMode.performed += instance.OnToogleWeaponMode;
            @ToogleWeaponMode.canceled += instance.OnToogleWeaponMode;
            @Interaction.started += instance.OnInteraction;
            @Interaction.performed += instance.OnInteraction;
            @Interaction.canceled += instance.OnInteraction;
            @UIMissionToolTipSwitch.started += instance.OnUIMissionToolTipSwitch;
            @UIMissionToolTipSwitch.performed += instance.OnUIMissionToolTipSwitch;
            @UIMissionToolTipSwitch.canceled += instance.OnUIMissionToolTipSwitch;
            @UIPause.started += instance.OnUIPause;
            @UIPause.performed += instance.OnUIPause;
            @UIPause.canceled += instance.OnUIPause;
        }

        private void UnregisterCallbacks(ICharacterActions instance)
        {
            @Fire.started -= instance.OnFire;
            @Fire.performed -= instance.OnFire;
            @Fire.canceled -= instance.OnFire;
            @Movement.started -= instance.OnMovement;
            @Movement.performed -= instance.OnMovement;
            @Movement.canceled -= instance.OnMovement;
            @Aim.started -= instance.OnAim;
            @Aim.performed -= instance.OnAim;
            @Aim.canceled -= instance.OnAim;
            @Run.started -= instance.OnRun;
            @Run.performed -= instance.OnRun;
            @Run.canceled -= instance.OnRun;
            @EquipSlot1.started -= instance.OnEquipSlot1;
            @EquipSlot1.performed -= instance.OnEquipSlot1;
            @EquipSlot1.canceled -= instance.OnEquipSlot1;
            @EquipSlot2.started -= instance.OnEquipSlot2;
            @EquipSlot2.performed -= instance.OnEquipSlot2;
            @EquipSlot2.canceled -= instance.OnEquipSlot2;
            @EquipSlot3.started -= instance.OnEquipSlot3;
            @EquipSlot3.performed -= instance.OnEquipSlot3;
            @EquipSlot3.canceled -= instance.OnEquipSlot3;
            @EquipSlot4.started -= instance.OnEquipSlot4;
            @EquipSlot4.performed -= instance.OnEquipSlot4;
            @EquipSlot4.canceled -= instance.OnEquipSlot4;
            @EquipSlot5.started -= instance.OnEquipSlot5;
            @EquipSlot5.performed -= instance.OnEquipSlot5;
            @EquipSlot5.canceled -= instance.OnEquipSlot5;
            @DropCurrentWeapon.started -= instance.OnDropCurrentWeapon;
            @DropCurrentWeapon.performed -= instance.OnDropCurrentWeapon;
            @DropCurrentWeapon.canceled -= instance.OnDropCurrentWeapon;
            @Reload.started -= instance.OnReload;
            @Reload.performed -= instance.OnReload;
            @Reload.canceled -= instance.OnReload;
            @ToogleWeaponMode.started -= instance.OnToogleWeaponMode;
            @ToogleWeaponMode.performed -= instance.OnToogleWeaponMode;
            @ToogleWeaponMode.canceled -= instance.OnToogleWeaponMode;
            @Interaction.started -= instance.OnInteraction;
            @Interaction.performed -= instance.OnInteraction;
            @Interaction.canceled -= instance.OnInteraction;
            @UIMissionToolTipSwitch.started -= instance.OnUIMissionToolTipSwitch;
            @UIMissionToolTipSwitch.performed -= instance.OnUIMissionToolTipSwitch;
            @UIMissionToolTipSwitch.canceled -= instance.OnUIMissionToolTipSwitch;
            @UIPause.started -= instance.OnUIPause;
            @UIPause.performed -= instance.OnUIPause;
            @UIPause.canceled -= instance.OnUIPause;
        }

        public void RemoveCallbacks(ICharacterActions instance)
        {
            if (m_Wrapper.m_CharacterActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(ICharacterActions instance)
        {
            foreach (var item in m_Wrapper.m_CharacterActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_CharacterActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public CharacterActions @Character => new CharacterActions(this);

    // UI
    private readonly InputActionMap m_UI;
    private List<IUIActions> m_UIActionsCallbackInterfaces = new List<IUIActions>();
    private readonly InputAction m_UI_UIPause;
    public struct UIActions
    {
        private @PlayerControls m_Wrapper;
        public UIActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @UIPause => m_Wrapper.m_UI_UIPause;
        public InputActionMap Get() { return m_Wrapper.m_UI; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIActions set) { return set.Get(); }
        public void AddCallbacks(IUIActions instance)
        {
            if (instance == null || m_Wrapper.m_UIActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_UIActionsCallbackInterfaces.Add(instance);
            @UIPause.started += instance.OnUIPause;
            @UIPause.performed += instance.OnUIPause;
            @UIPause.canceled += instance.OnUIPause;
        }

        private void UnregisterCallbacks(IUIActions instance)
        {
            @UIPause.started -= instance.OnUIPause;
            @UIPause.performed -= instance.OnUIPause;
            @UIPause.canceled -= instance.OnUIPause;
        }

        public void RemoveCallbacks(IUIActions instance)
        {
            if (m_Wrapper.m_UIActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IUIActions instance)
        {
            foreach (var item in m_Wrapper.m_UIActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_UIActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public UIActions @UI => new UIActions(this);

    // Car
    private readonly InputActionMap m_Car;
    private List<ICarActions> m_CarActionsCallbackInterfaces = new List<ICarActions>();
    private readonly InputAction m_Car_Movement;
    private readonly InputAction m_Car_CarExit;
    private readonly InputAction m_Car_Brake;
    public struct CarActions
    {
        private @PlayerControls m_Wrapper;
        public CarActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Car_Movement;
        public InputAction @CarExit => m_Wrapper.m_Car_CarExit;
        public InputAction @Brake => m_Wrapper.m_Car_Brake;
        public InputActionMap Get() { return m_Wrapper.m_Car; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CarActions set) { return set.Get(); }
        public void AddCallbacks(ICarActions instance)
        {
            if (instance == null || m_Wrapper.m_CarActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_CarActionsCallbackInterfaces.Add(instance);
            @Movement.started += instance.OnMovement;
            @Movement.performed += instance.OnMovement;
            @Movement.canceled += instance.OnMovement;
            @CarExit.started += instance.OnCarExit;
            @CarExit.performed += instance.OnCarExit;
            @CarExit.canceled += instance.OnCarExit;
            @Brake.started += instance.OnBrake;
            @Brake.performed += instance.OnBrake;
            @Brake.canceled += instance.OnBrake;
        }

        private void UnregisterCallbacks(ICarActions instance)
        {
            @Movement.started -= instance.OnMovement;
            @Movement.performed -= instance.OnMovement;
            @Movement.canceled -= instance.OnMovement;
            @CarExit.started -= instance.OnCarExit;
            @CarExit.performed -= instance.OnCarExit;
            @CarExit.canceled -= instance.OnCarExit;
            @Brake.started -= instance.OnBrake;
            @Brake.performed -= instance.OnBrake;
            @Brake.canceled -= instance.OnBrake;
        }

        public void RemoveCallbacks(ICarActions instance)
        {
            if (m_Wrapper.m_CarActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(ICarActions instance)
        {
            foreach (var item in m_Wrapper.m_CarActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_CarActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public CarActions @Car => new CarActions(this);
    public interface ICharacterActions
    {
        void OnFire(InputAction.CallbackContext context);
        void OnMovement(InputAction.CallbackContext context);
        void OnAim(InputAction.CallbackContext context);
        void OnRun(InputAction.CallbackContext context);
        void OnEquipSlot1(InputAction.CallbackContext context);
        void OnEquipSlot2(InputAction.CallbackContext context);
        void OnEquipSlot3(InputAction.CallbackContext context);
        void OnEquipSlot4(InputAction.CallbackContext context);
        void OnEquipSlot5(InputAction.CallbackContext context);
        void OnDropCurrentWeapon(InputAction.CallbackContext context);
        void OnReload(InputAction.CallbackContext context);
        void OnToogleWeaponMode(InputAction.CallbackContext context);
        void OnInteraction(InputAction.CallbackContext context);
        void OnUIMissionToolTipSwitch(InputAction.CallbackContext context);
        void OnUIPause(InputAction.CallbackContext context);
    }
    public interface IUIActions
    {
        void OnUIPause(InputAction.CallbackContext context);
    }
    public interface ICarActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnCarExit(InputAction.CallbackContext context);
        void OnBrake(InputAction.CallbackContext context);
    }
}
