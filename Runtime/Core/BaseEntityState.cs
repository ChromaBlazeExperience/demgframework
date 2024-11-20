using System;
using Sirenix.OdinInspector;
using Unity.VisualScripting;
using UnityEngine;

namespace DemGFramework.Core
{
    [Serializable]
    public class BaseEntityState<T>
    {
        [TabGroup("Components")]
        public T properties;
        [TabGroup("Components")]
        public GameObject scripts;
        [TabGroup("Components")]
        public Components components = new Components();
        
        public virtual void Start() {
            
        }
        public virtual void Update() {
            
        }
        public virtual void DefaultSetup<Y>(Y state) {
            bool useLogic = scripts.TryGetComponent<BaseEntityLogic<Unknown, Unknown>>(out var logic);
            if (useLogic) {
                Debug.Log("Using logic");
                logic.SetStateAndProperties(properties as Unknown, this as Unknown);
            }
            else Debug.Log("No logic");
            components.DefaultSetup<T, Y>(properties, state);
        }
        public void SetNewConfigurationFor<Y>(string type, T data) {
            components.ReinitializeDataOfComponent<T, Y>(type, data);
        }
        public void ResetConfigurationAtDefaultFor<Y>(string type) {
            components.ReinitializeDataOfComponent<T, Y>(type, properties);
        }
    }
}