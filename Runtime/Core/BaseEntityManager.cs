using Sirenix.OdinInspector;
using UnityEngine;

namespace DemGFramework.Core
{
    public class BaseEntityManager<TState, TProperty> : MonoBehaviour
    {
        [TabGroup("Base State")]
        public TState state;

        [TabGroup("Components")]
        public TProperty properties;

        public virtual void Awake() {
            (state as BaseEntityState).Initialize<TProperty>(properties);
        }
    }
}