using System.Diagnostics;
using UnityEngine;

namespace DemGFramework.Shared.Components {
    public interface IDamageble
    {
        void StartApplyDamage(object packet);
        void UpdateApplyDamage(object packet);
        void EndApplyDamage(object packet);
    }
}