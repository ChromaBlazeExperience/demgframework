using System.Linq;
using DemGFramework.Core;
using UnityEngine;

namespace DemGFramework.Shared.Components{

    public class InteractionComponent<T, Y>: BaseEntityComponent<T, Y> {

        private Transform raycastOrigin;
        private float checkerRadius;
        private LayerMask raycastLayer;

        private IInteractable currentInteractable;

        #region LIFECYCLE
            private void Update() {
                CheckInteractable();
            }
        #endregion

        #region GAME LOGIC
            private void CheckInteractable() {
                Collider[] colliders = Physics.OverlapSphere(raycastOrigin.position, checkerRadius, raycastLayer);

                if(colliders.Length == 0){
                    currentInteractable = null;
                    return;
                } 

                //get the more closest object
                colliders = colliders.OrderBy(x => Vector3.Distance(raycastOrigin.position, x.transform.position)).ToArray();
                colliders[0].TryGetComponent<IInteractable>(out currentInteractable);

                // Debug.Log("Pickup: " + currentInteractable.Name);
            }

        #endregion
    }

}