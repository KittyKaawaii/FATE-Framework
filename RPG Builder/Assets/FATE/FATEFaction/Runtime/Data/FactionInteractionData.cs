using UnityEngine;

namespace FATE.FATEFaction.Runtime.Data
{
    [System.Serializable]
    public class FactionInteractionData
    {
        public int factionID = -1;

        [HideInInspector] public string defaultStance;
        public RPGBFactionStance DefaultFactionStance;
        public int startingPoints;
    }
}