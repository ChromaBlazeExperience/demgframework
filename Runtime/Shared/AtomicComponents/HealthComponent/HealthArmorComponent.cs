using UnityEngine;
using System;
using DemGFramework.Core;
using static DemGFramework.Utility.Utility;
using Unity.VisualScripting;

namespace Shared.Components
{
    public class HealthArmorComponent<T, Y> : BaseEntityComponent<T, Y>
    {
        public HealthArmorManager healthArmorComponent;

        public override void LoadFromData()
        {
            healthArmorComponent = new HealthArmorManager(100, 100, 0, 0);
            if(!readyToWork) {
                healthArmorComponent.OnDeath += OnDeath;
            }
            base.LoadFromData();
        }
        private void OnEnable()
        {
            if(readyToWork) {
                if(healthArmorComponent.OnDeath.IsUnityNull()) 
                    healthArmorComponent.OnDeath += OnDeath;
            }
        }
        private void OnDisable() {
            if(readyToWork) {
                healthArmorComponent.OnDeath -= OnDeath;
            }
        }

        public virtual void OnDeath() {
        }
    }
}