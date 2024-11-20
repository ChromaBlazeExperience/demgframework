using UnityEngine;

namespace DemGFramework.Core
{
    public class BaseEntityLogic<TState, TProperty> : MonoBehaviour
    {
        protected TState state;
        protected TProperty properties;
        
        public void SetStateAndProperties(object[] data)
        {
            this.state = (TState)data[0];
            this.properties = (TProperty)data[1];
        }
    }
}