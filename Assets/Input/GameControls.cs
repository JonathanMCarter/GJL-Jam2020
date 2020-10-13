// GENERATED AUTOMATICALLY FROM 'Assets/Input/GameControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace DresslikeaGnome.OhGnomes
{
    public class @GameControls : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @GameControls()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""GameControls"",
    ""maps"": [
        {
            ""name"": ""Gnome"",
            ""id"": ""e8488b60-b24e-46f6-9f99-0ad74a7bad80"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""f545afe5-8583-4df5-8d73-32c1678b70c7"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": ""Normalize(max=1)"",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""PassThrough"",
                    ""id"": ""4fe57633-2cdf-4d8b-b73c-c1a46341f8e4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                },
                {
                    ""name"": ""WeaponToggle"",
                    ""type"": ""PassThrough"",
                    ""id"": ""7092c941-edc0-4aef-bdf8-08537bc7c71a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""ToggleWeaponOne"",
                    ""type"": ""Button"",
                    ""id"": ""34a818cd-e1eb-40ad-b0fb-4b101998471b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""ToggleWeaponTwo"",
                    ""type"": ""Button"",
                    ""id"": ""19cc90a6-0385-4b1c-8674-04ff09fad8a9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""ToggleWeaponThree"",
                    ""type"": ""Button"",
                    ""id"": ""5c42a412-ee54-419f-aec1-5f58157bfda6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""ToggleWeaponScroll"",
                    ""type"": ""PassThrough"",
                    ""id"": ""23539e03-7f75-47a3-b48d-a13527b3085f"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                },
                {
                    ""name"": ""UseTrap"",
                    ""type"": ""PassThrough"",
                    ""id"": ""d6530d4a-e813-4a3f-aa41-bd588ee13978"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""b3e59d94-3e83-491b-913f-afd1180bb725"",
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
                    ""id"": ""3f2b1bed-28c5-4da0-b4e7-f753ef43514c"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""2037c885-e98d-482a-927f-0fef41e410f4"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""2954143b-dcd1-4430-a6dc-70edd1805a31"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""59bcb7a0-461f-4b41-ab32-6f68bc2e6a2b"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""ArrowKeys"",
                    ""id"": ""745e8b33-cb83-45b2-95c0-796654fa2868"",
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
                    ""id"": ""398e6c16-c109-4abd-ab71-a97f96db6498"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""bbca5276-4a34-4a07-9c9c-719821da778d"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""80ed84ff-574d-4481-836a-ad20d5b965d7"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""80819141-dcfe-458e-baa0-d82204393d55"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""57305179-1321-4fd8-a497-60b52e3e4084"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""54d5ae3d-7e67-4ea4-b584-5a00599765a3"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""UseTrap"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bd9d2994-731e-4c2e-b382-f67e51e6e214"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""UseTrap"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""371c7ba7-eaf5-44bd-9c86-184b898c6e7e"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""ToggleWeaponOne"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ce191ffa-f07e-4b14-9172-5a88a50c6394"",
                    ""path"": ""<Mouse>/scroll"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""ToggleWeaponScroll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f97ddbf4-3ab5-4137-97e7-62e542cdbc39"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""ToggleWeaponTwo"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c9754a70-5c68-4797-a0b4-2c3495d052cd"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""ToggleWeaponThree"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2d029d64-69bb-42c6-b00b-1e6be3be38c1"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""WeaponToggle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Menu"",
            ""id"": ""57d9340b-a198-4b7d-b417-6132b20e1bd5"",
            ""actions"": [
                {
                    ""name"": ""PauseGame"",
                    ""type"": ""PassThrough"",
                    ""id"": ""3898dce9-5b1a-4063-9a86-931e48cdb800"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""c7089620-0735-49ee-b070-0be4de3aa24a"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""PauseGame"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""PC"",
            ""bindingGroup"": ""PC"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Controller"",
            ""bindingGroup"": ""Controller"",
            ""devices"": [
                {
                    ""devicePath"": ""<XInputController>"",
                    ""isOptional"": true,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
            // Gnome
            m_Gnome = asset.FindActionMap("Gnome", throwIfNotFound: true);
            m_Gnome_Movement = m_Gnome.FindAction("Movement", throwIfNotFound: true);
            m_Gnome_Attack = m_Gnome.FindAction("Attack", throwIfNotFound: true);
            m_Gnome_WeaponToggle = m_Gnome.FindAction("WeaponToggle", throwIfNotFound: true);
            m_Gnome_ToggleWeaponOne = m_Gnome.FindAction("ToggleWeaponOne", throwIfNotFound: true);
            m_Gnome_ToggleWeaponTwo = m_Gnome.FindAction("ToggleWeaponTwo", throwIfNotFound: true);
            m_Gnome_ToggleWeaponThree = m_Gnome.FindAction("ToggleWeaponThree", throwIfNotFound: true);
            m_Gnome_ToggleWeaponScroll = m_Gnome.FindAction("ToggleWeaponScroll", throwIfNotFound: true);
            m_Gnome_UseTrap = m_Gnome.FindAction("UseTrap", throwIfNotFound: true);
            // Menu
            m_Menu = asset.FindActionMap("Menu", throwIfNotFound: true);
            m_Menu_PauseGame = m_Menu.FindAction("PauseGame", throwIfNotFound: true);
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

        // Gnome
        private readonly InputActionMap m_Gnome;
        private IGnomeActions m_GnomeActionsCallbackInterface;
        private readonly InputAction m_Gnome_Movement;
        private readonly InputAction m_Gnome_Attack;
        private readonly InputAction m_Gnome_WeaponToggle;
        private readonly InputAction m_Gnome_ToggleWeaponOne;
        private readonly InputAction m_Gnome_ToggleWeaponTwo;
        private readonly InputAction m_Gnome_ToggleWeaponThree;
        private readonly InputAction m_Gnome_ToggleWeaponScroll;
        private readonly InputAction m_Gnome_UseTrap;
        public struct GnomeActions
        {
            private @GameControls m_Wrapper;
            public GnomeActions(@GameControls wrapper) { m_Wrapper = wrapper; }
            public InputAction @Movement => m_Wrapper.m_Gnome_Movement;
            public InputAction @Attack => m_Wrapper.m_Gnome_Attack;
            public InputAction @WeaponToggle => m_Wrapper.m_Gnome_WeaponToggle;
            public InputAction @ToggleWeaponOne => m_Wrapper.m_Gnome_ToggleWeaponOne;
            public InputAction @ToggleWeaponTwo => m_Wrapper.m_Gnome_ToggleWeaponTwo;
            public InputAction @ToggleWeaponThree => m_Wrapper.m_Gnome_ToggleWeaponThree;
            public InputAction @ToggleWeaponScroll => m_Wrapper.m_Gnome_ToggleWeaponScroll;
            public InputAction @UseTrap => m_Wrapper.m_Gnome_UseTrap;
            public InputActionMap Get() { return m_Wrapper.m_Gnome; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(GnomeActions set) { return set.Get(); }
            public void SetCallbacks(IGnomeActions instance)
            {
                if (m_Wrapper.m_GnomeActionsCallbackInterface != null)
                {
                    @Movement.started -= m_Wrapper.m_GnomeActionsCallbackInterface.OnMovement;
                    @Movement.performed -= m_Wrapper.m_GnomeActionsCallbackInterface.OnMovement;
                    @Movement.canceled -= m_Wrapper.m_GnomeActionsCallbackInterface.OnMovement;
                    @Attack.started -= m_Wrapper.m_GnomeActionsCallbackInterface.OnAttack;
                    @Attack.performed -= m_Wrapper.m_GnomeActionsCallbackInterface.OnAttack;
                    @Attack.canceled -= m_Wrapper.m_GnomeActionsCallbackInterface.OnAttack;
                    @WeaponToggle.started -= m_Wrapper.m_GnomeActionsCallbackInterface.OnWeaponToggle;
                    @WeaponToggle.performed -= m_Wrapper.m_GnomeActionsCallbackInterface.OnWeaponToggle;
                    @WeaponToggle.canceled -= m_Wrapper.m_GnomeActionsCallbackInterface.OnWeaponToggle;
                    @ToggleWeaponOne.started -= m_Wrapper.m_GnomeActionsCallbackInterface.OnToggleWeaponOne;
                    @ToggleWeaponOne.performed -= m_Wrapper.m_GnomeActionsCallbackInterface.OnToggleWeaponOne;
                    @ToggleWeaponOne.canceled -= m_Wrapper.m_GnomeActionsCallbackInterface.OnToggleWeaponOne;
                    @ToggleWeaponTwo.started -= m_Wrapper.m_GnomeActionsCallbackInterface.OnToggleWeaponTwo;
                    @ToggleWeaponTwo.performed -= m_Wrapper.m_GnomeActionsCallbackInterface.OnToggleWeaponTwo;
                    @ToggleWeaponTwo.canceled -= m_Wrapper.m_GnomeActionsCallbackInterface.OnToggleWeaponTwo;
                    @ToggleWeaponThree.started -= m_Wrapper.m_GnomeActionsCallbackInterface.OnToggleWeaponThree;
                    @ToggleWeaponThree.performed -= m_Wrapper.m_GnomeActionsCallbackInterface.OnToggleWeaponThree;
                    @ToggleWeaponThree.canceled -= m_Wrapper.m_GnomeActionsCallbackInterface.OnToggleWeaponThree;
                    @ToggleWeaponScroll.started -= m_Wrapper.m_GnomeActionsCallbackInterface.OnToggleWeaponScroll;
                    @ToggleWeaponScroll.performed -= m_Wrapper.m_GnomeActionsCallbackInterface.OnToggleWeaponScroll;
                    @ToggleWeaponScroll.canceled -= m_Wrapper.m_GnomeActionsCallbackInterface.OnToggleWeaponScroll;
                    @UseTrap.started -= m_Wrapper.m_GnomeActionsCallbackInterface.OnUseTrap;
                    @UseTrap.performed -= m_Wrapper.m_GnomeActionsCallbackInterface.OnUseTrap;
                    @UseTrap.canceled -= m_Wrapper.m_GnomeActionsCallbackInterface.OnUseTrap;
                }
                m_Wrapper.m_GnomeActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Movement.started += instance.OnMovement;
                    @Movement.performed += instance.OnMovement;
                    @Movement.canceled += instance.OnMovement;
                    @Attack.started += instance.OnAttack;
                    @Attack.performed += instance.OnAttack;
                    @Attack.canceled += instance.OnAttack;
                    @WeaponToggle.started += instance.OnWeaponToggle;
                    @WeaponToggle.performed += instance.OnWeaponToggle;
                    @WeaponToggle.canceled += instance.OnWeaponToggle;
                    @ToggleWeaponOne.started += instance.OnToggleWeaponOne;
                    @ToggleWeaponOne.performed += instance.OnToggleWeaponOne;
                    @ToggleWeaponOne.canceled += instance.OnToggleWeaponOne;
                    @ToggleWeaponTwo.started += instance.OnToggleWeaponTwo;
                    @ToggleWeaponTwo.performed += instance.OnToggleWeaponTwo;
                    @ToggleWeaponTwo.canceled += instance.OnToggleWeaponTwo;
                    @ToggleWeaponThree.started += instance.OnToggleWeaponThree;
                    @ToggleWeaponThree.performed += instance.OnToggleWeaponThree;
                    @ToggleWeaponThree.canceled += instance.OnToggleWeaponThree;
                    @ToggleWeaponScroll.started += instance.OnToggleWeaponScroll;
                    @ToggleWeaponScroll.performed += instance.OnToggleWeaponScroll;
                    @ToggleWeaponScroll.canceled += instance.OnToggleWeaponScroll;
                    @UseTrap.started += instance.OnUseTrap;
                    @UseTrap.performed += instance.OnUseTrap;
                    @UseTrap.canceled += instance.OnUseTrap;
                }
            }
        }
        public GnomeActions @Gnome => new GnomeActions(this);

        // Menu
        private readonly InputActionMap m_Menu;
        private IMenuActions m_MenuActionsCallbackInterface;
        private readonly InputAction m_Menu_PauseGame;
        public struct MenuActions
        {
            private @GameControls m_Wrapper;
            public MenuActions(@GameControls wrapper) { m_Wrapper = wrapper; }
            public InputAction @PauseGame => m_Wrapper.m_Menu_PauseGame;
            public InputActionMap Get() { return m_Wrapper.m_Menu; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(MenuActions set) { return set.Get(); }
            public void SetCallbacks(IMenuActions instance)
            {
                if (m_Wrapper.m_MenuActionsCallbackInterface != null)
                {
                    @PauseGame.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnPauseGame;
                    @PauseGame.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnPauseGame;
                    @PauseGame.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnPauseGame;
                }
                m_Wrapper.m_MenuActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @PauseGame.started += instance.OnPauseGame;
                    @PauseGame.performed += instance.OnPauseGame;
                    @PauseGame.canceled += instance.OnPauseGame;
                }
            }
        }
        public MenuActions @Menu => new MenuActions(this);
        private int m_PCSchemeIndex = -1;
        public InputControlScheme PCScheme
        {
            get
            {
                if (m_PCSchemeIndex == -1) m_PCSchemeIndex = asset.FindControlSchemeIndex("PC");
                return asset.controlSchemes[m_PCSchemeIndex];
            }
        }
        private int m_ControllerSchemeIndex = -1;
        public InputControlScheme ControllerScheme
        {
            get
            {
                if (m_ControllerSchemeIndex == -1) m_ControllerSchemeIndex = asset.FindControlSchemeIndex("Controller");
                return asset.controlSchemes[m_ControllerSchemeIndex];
            }
        }
        public interface IGnomeActions
        {
            void OnMovement(InputAction.CallbackContext context);
            void OnAttack(InputAction.CallbackContext context);
            void OnWeaponToggle(InputAction.CallbackContext context);
            void OnToggleWeaponOne(InputAction.CallbackContext context);
            void OnToggleWeaponTwo(InputAction.CallbackContext context);
            void OnToggleWeaponThree(InputAction.CallbackContext context);
            void OnToggleWeaponScroll(InputAction.CallbackContext context);
            void OnUseTrap(InputAction.CallbackContext context);
        }
        public interface IMenuActions
        {
            void OnPauseGame(InputAction.CallbackContext context);
        }
    }
}
