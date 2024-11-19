using System.Diagnostics;
using UnityEngine;

namespace Shared.Components {
    public interface IDamageble
    {
        void StartApplyDamage(object packet);
        void UpdateApplyDamage(object packet);
        void EndApplyDamage(object packet);
    }
}