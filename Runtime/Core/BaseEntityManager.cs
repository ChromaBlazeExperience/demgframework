using Sirenix.OdinInspector;
using UnityEngine;

namespace DemGFramework.Core
{
    public class BaseEntityManager<TState, TProperty> : MonoBehaviour
    {
        [TabGroup("Base State")]
        public TState baseState;
        [TabGroup("Components")]
        public TProperty properties;
        private BaseEntityState _baseState => baseState as BaseEntityState;

        public virtual void Awake() {
            _baseState.Initialize<TState, TProperty>(baseState, properties);
        }
        public virtual void Update() {
            _baseState.Update();
        }
    }
}