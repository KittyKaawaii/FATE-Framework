using FATE.FATEFaction.Runtime.DatabaseTypeEntry;
using UnityEngine;
using UnityEngine.Serialization;

namespace FATE.FATEFaction.Runtime.Data
{
    [System.Serializable]
    public class FactionInteractionData
    {
        [FormerlySerializedAs("factionID")] public int FactionID = -1;

        public RPGBFactionStance DefaultFactionStance;
        [FormerlySerializedAs("startingPoints")] public int StartingPoints;
    }
}