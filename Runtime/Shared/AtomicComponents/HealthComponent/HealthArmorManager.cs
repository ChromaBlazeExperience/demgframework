using System;
using static DemGFramework.Utility.Utility;

namespace Shared.Components {
    [Serializable]
    public class HealthArmorManager
    {
        public float health;
        public float maxHealth;

        public float armor;
        public float maxArmor;

        public bool isAlive;

        public VoidAction OnDeath;

        public HealthArmorManager(float health, float maxHealth, float armor, float maxArmor)
        {
            this.health = health;
            this.maxHealth = maxHealth;
            this.armor = armor;
            this.maxArmor = maxArmor;
            isAlive = this.health > 0;
        }
        public void TotalRestore()
        {
            TotalRestoreHealth();
            TotalRestoreArmor();
        }
        public void TotalRestoreHealth()
        {
            health = maxHealth;
            isAlive = true;
        }
        public void TotalRestoreArmor()
        {
            armor = maxArmor;
        }
        public void RestoreHealth(float value)
        {
            health += value;
            isAlive = health > 0;
        }
        public void RestoreArmor(float value)
        {
            armor += value;
        }
        public void ApplyDamage(float damage)
        {
            if (armor > 0)
            {
                armor -= damage;
                if (armor < 0) armor = 0;
                return;
            }

            health -= damage;
            if (health < 0) health = 0;

            if (isAlive && health <= 0) {
                OnDeath?.Invoke();
            }

            isAlive = health > 0;
        }
        public void SetMaxHealth(float value)
        {
            maxHealth = value;
        }
        public void SetMaxArmor(float value)
        {
            maxArmor = value;
        }
        public void SetHealth(float value)
        {
            health = value;
        }
        public void SetArmor(float value)
        {
            armor = value;
        }
    }
}