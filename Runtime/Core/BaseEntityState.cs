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

        protected Dictionary<string, Action> stateInjections = new Dictionary<string, Action>();

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

        public void AddNewInjection(string stateName, Action stateInjection) {
            stateInjections.Add(stateName, stateInjection);
        }
        public void RemoveInjection(string stateName) {
            if (stateInjections.ContainsKey(stateName)) {
                stateInjections.Remove(stateName);
            }
        }
        public void InjectState(string stateName, object[] parameters) {
            if (stateInjections.ContainsKey(stateName)) {
                if(parameters.Length > 0) stateInjections[stateName].DynamicInvoke(parameters);
                else stateInjections[stateName].Invoke();
            }
        }
    }
}