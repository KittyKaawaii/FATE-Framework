using FATE.FATECombat.Runtime.Data;
using FATE.FATEFaction.Runtime.DatabaseTypeEntry;
using UnityEngine;
using UnityEngine.Serialization;

namespace FATE.FATEFaction.Runtime.Data
{
    [System.Serializable]
    public class FactionStanceData
    {
        public RPGBFactionStance FactionStance;
        [FormerlySerializedAs("pointsRequired")] public int PointsRequired;

        [FormerlySerializedAs("AlignementToPlayer")] public CombatData.EntityAlignment AlignmentToPlayer;
    }
}