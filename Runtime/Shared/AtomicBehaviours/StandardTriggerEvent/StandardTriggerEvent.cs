using UnityEngine;
using UnityEngine.Events;

namespace DemGFramework.Shared.Behaviours {


    public class StandardTriggerEvent: MonoBehaviour {
            public UnityEvent triggerEvent;
            void OnTriggerEnter(Collider other) {
                triggerEvent?.Invoke();
            }
    }

}