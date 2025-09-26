using System;
using UnityEngine.Serialization;

namespace FATE.FATEAbility.Runtime.Data
{
    [Serializable]
    public class AbilityEffectsApplied
    {
        [FormerlySerializedAs("effectID")] public int EffectID = -1;

        public float chance = 100f;

        public int effectRank;

        public RPGCombatDATA.TARGET_TYPE target = RPGCombatDATA.TARGET_TYPE.Target;

        public bool isSpread;

        public float spreadDistanceMax;

        public int spreadUnitMax;

        public float delay;

        public string tooltipText;
    }
}