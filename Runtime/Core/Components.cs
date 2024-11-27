using System;
using System.Collections.Generic;
using UnityEngine;

namespace DemGFramework.Core {

    [Serializable]
    public class Components {
        public List<Component> components = new List<Component>();
        public void OnOff(string type, bool value)
        {
            Component component = components.Find(c => c.type == type);
            if (component != null)
            {
                component.script.enabled = value;
            }
        }
        public void ActiveAllComponents() {
            foreach(Component c in components)
            {
                c.script.enabled = true;
            }
        }
        public void ActivateByDefault() {
            foreach(Component c in components)
            {
                c.script.enabled = c.defaultStateValue;
            }
        }
        public void DeactiveAllComponents() {
            foreach(Component c in components)
            {
                c.script.enabled = false;
            }
        }
        public void DefaultSetup<TProperty>(TProperty data)
        {
            Dictionary<string, object> dataCasted = Utility.Utility.ToDictionary(data);
            foreach(Component c in components)
            {
                (c.script as BaseEntityComponent).enabled = (c.defaultStateValue);
                (c.script as BaseEntityComponent).Initialize(dataCasted);
            }
            #if UNITY_EDITOR
                if(components.Count > 0) Debug.Log("Components Setup Completed");
                else  Debug.LogWarning("Components Setup Failed");
            #endif
        }
        public void ReloadData()
        {
            foreach(Component c in components)
            {
                (c.script as BaseEntityComponent).LoadFromData();
            }
        }
        public void ReinitializeDataOfComponent<TProperty>(string type, TProperty data) {
            Dictionary<string, object> dataCasted = Utility.Utility.ToDictionary(data);
            Component component = components.Find(c => c.type == type);
            if (component != null)
            {
                (component.script as BaseEntityComponent).LoadNewData(dataCasted);
            }
        }
        public void CanPlayAllComponent() {
            foreach(Component c in components)
            {
                (c.script as BaseEntityComponent).SetCanPlay(true);
            }
        }
        public void NotCanPlayAllComponent() {
            foreach(Component c in components)
            {
                (c.script as BaseEntityComponent).SetCanPlay(false);
            }
        }
    }

    [Serializable]
    public class Component
    {
        public string type;
        public MonoBehaviour script;
        public bool defaultStateValue;
    }
}