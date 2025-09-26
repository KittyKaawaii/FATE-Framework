using System;

namespace FATE.FATEClass.Runtime.Data
{

    [Serializable]
    public class CLASS_STATS_DATA
    {
        public string statName;

        public int statID = -1;

        public float amount;

        public bool isPercent;

        public float bonusPerLevel;
    }

}