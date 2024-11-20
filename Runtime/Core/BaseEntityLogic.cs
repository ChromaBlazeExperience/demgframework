using UnityEngine;

namespace DemGFramework.Core
{
    public class BaseEntityLogic<TState, TProperty> : MonoBehaviour
    {
        public TState state;
        public TProperty properties;
        
        public void SetStateAndProperties(TState state, TProperty properties)
        {
            this.state = state;
            this.properties = properties;
        }
    }
}