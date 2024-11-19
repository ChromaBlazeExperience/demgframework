using UnityEngine;
using UnityEngine.Events;

namespace Shared.Behaviours {


    public class StandardTriggerEvent: MonoBehaviour {
            public UnityEvent triggerEvent;
            void OnTriggerEnter(Collider other) {
                triggerEvent?.Invoke();
            }
    }

}