using DemGFramework.Core;
using Unity.VisualScripting;

namespace DemGFramework.Shared.Components
{
    public class HealthArmorComponent<T, Y> : BaseEntityComponent<T, Y>
    {
        public HealthArmorBase healthArmorBase;

        public override void LoadFromData()
        {
            healthArmorBase = new HealthArmorBase(100, 100, 0, 0);
            if(!readyToWork) {
                healthArmorBase.OnDeath += OnDeath;
            }
            base.LoadFromData();
        }
        private void OnEnable()
        {
            if(readyToWork) {
                if(healthArmorBase.OnDeath.IsUnityNull()) 
                    healthArmorBase.OnDeath += OnDeath;
            }
        }
        private void OnDisable() {
            if(readyToWork) {
                healthArmorBase.OnDeath -= OnDeath;
            }
        }

        public virtual void OnDeath() {
        }
    }
}