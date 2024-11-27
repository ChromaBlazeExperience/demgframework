using Sirenix.OdinInspector;
using UnityEngine;

namespace DemGFramework.Core
{
    public class BaseEntityManager<TState, TProperty> : MonoBehaviour
    {
        [TabGroup("Base State")]
        private TState _baseState;
        public BaseEntityState baseState => _baseState as BaseEntityState;

        [TabGroup("Components")]
        public TProperty properties;

        public virtual void Awake() {
            baseState.Initialize<TState, TProperty>(_baseState, properties);
        }
        public virtual void Update() {
            baseState.Update();
        }
    }
}