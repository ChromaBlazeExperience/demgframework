using System;
using System.Collections.Generic;
using DemGFramework.Configuration;
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
        public void DefaultSetup<T, Y>(T data, Y state)
        {
            foreach(Component c in components)
            {
                (c.script as BaseEntityComponent<T, Y>).enabled = (c.defaultStateValue);
                (c.script as BaseEntityComponent<T, Y>).Initialize(data, state);
            }
            #if UNITY_EDITOR
                if(components.Count > 0) Debug.Log("Components Setup Completed");
                else  Debug.LogWarning("Components Setup Failed");
            #endif
        }
        public void ReloadData<T, Y>()
        {
            foreach(Component c in components)
            {
                (c.script as BaseEntityComponent<T, Y>).LoadFromData();
            }
        }
        public void ReinitializeDataOfComponent<T, Y>(string type, T data) {
            Component component = components.Find(c => c.type == type);
            if (component != null)
            {
                (component.script as BaseEntityComponent<T, Y>).LoadNewData(data);
            }
        }
        public T GetComponent<T>(string type) {
            Component component = components.Find(c => c.type == type);
            if (component != null)
            {
                return component.script.GetComponent<T>();
            }
            return default(T);
        }
        public void CanPlayAllComponent<T, Y>() {
            foreach(Component c in components)
            {
                (c.script as BaseEntityComponent<T, Y>).SetCanPlay(true);
            }
        }
        public void NotCanPlayAllComponent<T, Y>() {
            foreach(Component c in components)
            {
                (c.script as BaseEntityComponent<T, Y>).SetCanPlay(false);
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