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
            ""name"": ""GnomeMovement"",
            ""id"": ""e8488b60-b24e-46f6-9f99-0ad74a7bad80"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""f545afe5-8583-4df5-8d73-32c1678b70c7"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": ""Normalize(max=1)"",
                    ""interactions"": """"
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
            // GnomeMovement
            m_GnomeMovement = asset.FindActionMap("GnomeMovement", throwIfNotFound: true);
            m_GnomeMovement_Movement = m_GnomeMovement.FindAction("Movement", throwIfNotFound: true);
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

        // GnomeMovement
        private readonly InputActionMap m_GnomeMovement;
        private IGnomeMovementActions m_GnomeMovementActionsCallbackInterface;
        private readonly InputAction m_GnomeMovement_Movement;
        public struct GnomeMovementActions
        {
            private @GameControls m_Wrapper;
            public GnomeMovementActions(@GameControls wrapper) { m_Wrapper = wrapper; }
            public InputAction @Movement => m_Wrapper.m_GnomeMovement_Movement;
            public InputActionMap Get() { return m_Wrapper.m_GnomeMovement; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(GnomeMovementActions set) { return set.Get(); }
            public void SetCallbacks(IGnomeMovementActions instance)
            {
                if (m_Wrapper.m_GnomeMovementActionsCallbackInterface != null)
                {
                    @Movement.started -= m_Wrapper.m_GnomeMovementActionsCallbackInterface.OnMovement;
                    @Movement.performed -= m_Wrapper.m_GnomeMovementActionsCallbackInterface.OnMovement;
                    @Movement.canceled -= m_Wrapper.m_GnomeMovementActionsCallbackInterface.OnMovement;
                }
                m_Wrapper.m_GnomeMovementActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Movement.started += instance.OnMovement;
                    @Movement.performed += instance.OnMovement;
                    @Movement.canceled += instance.OnMovement;
                }
            }
        }
        public GnomeMovementActions @GnomeMovement => new GnomeMovementActions(this);
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
        public interface IGnomeMovementActions
        {
            void OnMovement(InputAction.CallbackContext context);
        }
    }
}
