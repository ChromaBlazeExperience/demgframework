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

        //NOTA: i components sono utili al momento solo per fare il reload delle properties che potremmo automatizzare da codice
        //prendendo tutti gli entitycomponent in scripts e facendo il load/reload delle properties .
        
        public virtual void Initialize<TProperty>(TProperty properties) {
            components.InitializeComponents(scripts);
            DefaultSetup<TProperty>(properties);
        }
        public virtual void DefaultSetup<TProperty>(TProperty properties) {
            components.DefaultSetup<TProperty>(properties);
        }
        public void SetNewConfigurationFor<TProperty>(string type, TProperty data) {
            components.ReinitializeDataOfComponent<TProperty>(type, data);
        }
        public void ResetConfigurationAtDefaultFor<TProperty>(string type, TProperty properties) {
            components.ReinitializeDataOfComponent<TProperty>(type, properties);
        }
    }
}