using System;
using FATE.FATEAttribute.Runtime.Attribute;

namespace FATE.FATEClass.Runtime.Data
{

    [Serializable]
    public class CLASS_STATS_DATA
    {
        public string statName;

        [StatID] public int statID = -1;

        public float amount;

        public bool isPercent;

        public float bonusPerLevel;
    }

}