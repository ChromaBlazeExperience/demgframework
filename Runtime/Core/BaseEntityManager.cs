using Sirenix.OdinInspector;
using UnityEngine;

namespace DemGFramework.Core
{
    public class BaseEntityManager<TState, TProperty> : MonoBehaviour
    {
        [TabGroup("Base State")]
        public TState baseState;
        private BaseEntityState<TProperty> _baseState => baseState as BaseEntityState<TProperty>;

        public virtual void Awake() {
            _baseState.DefaultSetup<TState>(baseState);
            //poi ci saranno input manager, ecc in override perché questa classe verrà overridata da
            //inputentitymanager, emptyentitymanager (senza components e input), ecc
            //il base entity manager è quello che usi per i nemici per intenderdci
            //quindi non ha bisogno di input manager
        }
        public virtual void Update() {
            _baseState.Update();
        }
    }
}