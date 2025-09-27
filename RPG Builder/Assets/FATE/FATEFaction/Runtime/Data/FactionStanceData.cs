using FATE.FATECombat.Runtime.Data;
using UnityEngine;

namespace FATE.FATEFaction.Runtime.Data
{
    [System.Serializable]
    public class FactionStanceData
    {
        [HideInInspector] public string stance;
        public RPGBFactionStance FactionStance;
        public int pointsRequired;

        [HideInInspector] public RPGCombatDATA.ALIGNMENT_TYPE playerAlignment;
        public CombatData.EntityAlignment AlignementToPlayer;
    }
}