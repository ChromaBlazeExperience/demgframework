using DemGFramework.Shared.Components;
using UnityEngine;

namespace DemGFramework.Shared.Behaviours
{  
    public class Explosion : MonoBehaviour
    {
        public float explosionRadius = 5f;
        public float explosionForce = 700f;
        public float upwardsModifier = 3f;
        public float damage = 100f;
        public LayerMask layerMask;
        public bool applyForce = true;

        public bool autoStart = false;
        public bool delayedAutoStart = false;
        public float delayTime = 1f;

        public bool debugExplosionRadius = false;

        private ExplosionBehaviour behaviour;

        private void Start() {
            behaviour = new ExplosionBehaviour();
            behaviour.transform = transform;
            behaviour.explosionRadius = explosionRadius;
            behaviour.explosionForce = explosionForce;
            behaviour.upwardsModifier = upwardsModifier;
            behaviour.damage = damage;
            behaviour.layerMask = layerMask;
            if(autoStart) {
                Explode();
            }
            if(delayedAutoStart) {
                Invoke("Explode", delayTime);
            }
        }
        public void Explode() {
            behaviour.Explode();
        }
        private void OnDrawGizmosSelected() {
            if(!debugExplosionRadius) return;
            
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, explosionRadius);
        }
    }
    public struct ExplosionBehaviour {
        public Transform transform;
        public float explosionRadius;
        public float explosionForce;
        public float upwardsModifier;
        public float damage;
        public LayerMask layerMask;
        public void Explode() {
            Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius, layerMask);
            foreach (Collider hit in colliders)
            {
                Rigidbody rb;
                if (hit.TryGetComponent<Rigidbody>(out rb))
                {
                    rb.AddExplosionForce(explosionForce, transform.position, explosionRadius, upwardsModifier, ForceMode.Impulse);
                }
                IDamageble damageble = hit.gameObject.GetComponentInParent<IDamageble>();
                if (damageble != null)
                {
                    var packet = new ExplosionPacket();
                    packet.damage = damage - Vector3.Distance(hit.transform.position, transform.position);
                    packet.explosionForce = explosionForce;
                    packet.radius = explosionRadius;
                    packet.upwardsModifier = upwardsModifier;
                    packet.originPosition = transform.position;

                    damageble.StartApplyDamage(packet);
                }
            }
        }
    }
    public struct ExplosionPacket {
        public float damage;
        public float explosionForce;
        public float radius;
        public float upwardsModifier;
        public Vector3 originPosition;
    }
}