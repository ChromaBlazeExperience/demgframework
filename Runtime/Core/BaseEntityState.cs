using System;
using Sirenix.OdinInspector;

namespace DemGFramework.Core
{
    [Serializable]
    public class BaseEntityState<T>
    {
        [TabGroup("Components")]
        public T properties;
        [TabGroup("Components")]
        public Components components = new Components();

        public virtual void Start() {

        }
        public virtual void Update() {
            
        }
        public virtual void DefaultSetup<Y>(Y state) {
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