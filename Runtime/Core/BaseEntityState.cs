using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Unity.VisualScripting;
using UnityEngine;

namespace DemGFramework.Core
{
    [Serializable]
    public class BaseEntityState
    {
        [TabGroup("Components")]
        public GameObject scripts;
        [TabGroup("Components")]
        public Components components = new Components();
        private Dictionary<string, object> properties = new Dictionary<string, object>();
        
        public virtual void Start() {
            
        }
        public virtual void Update() {
            
        }
        public virtual void Initialize<TState, TProperty>(TState state, TProperty properties) {
            this.properties = Utility.Utility.ToDictionary(properties);
            components.DefaultSetup<TState, TProperty>(state, properties);
        }
        public virtual void DefaultSetup<TState, TProperty>(TState state, TProperty properties) {
            components.DefaultSetup<TState, TProperty>(state, properties);
        }
        public void SetNewConfigurationFor<TState, TProperty>(string type, TProperty data) {
            components.ReinitializeDataOfComponent<TState, TProperty>(type, data);
        }
        public void ResetConfigurationAtDefaultFor<TState, TProperty>(string type, TProperty properties) {
            components.ReinitializeDataOfComponent<TState, TProperty>(type, properties);
        }
    }
}