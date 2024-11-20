using UnityEngine;

namespace DemGFramework.Core
{
    public class BaseEntityLogic<TState, TProperty> : MonoBehaviour
    {
        protected TState state;
        protected TProperty properties;
        
        public void SetStateAndProperties(TState state, TProperty properties)
        {
            this.state = state;
            this.properties = properties;
        }
    }
}