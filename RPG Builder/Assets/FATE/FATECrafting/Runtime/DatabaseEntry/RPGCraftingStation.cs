using System.Collections.Generic;
using FATE.FATEDatabase.Runtime.DatabaseEntry;
using UnityEngine;

namespace FATE.FATECrafting.Runtime.DatabaseEntry
{
    public class RPGCraftingStation : RPGBuilderDatabaseEntry
    {
        [HideInInspector] public string _name;
        [HideInInspector] public string _fileName;
        [HideInInspector] public string displayName;
        [HideInInspector] public Sprite icon;
    

        public float maxDistance;

        [System.Serializable]
        public class CraftSkillsDATA
        {
            public int craftSkillID = -1;
        }
        public List<CraftSkillsDATA> craftSkills = new List<CraftSkillsDATA>();

        public void UpdateEntryData(RPGCraftingStation newEntryData)
        {
            ID = newEntryData.ID;
            entryName = newEntryData.entryName;
            entryFileName = newEntryData.entryFileName;
            entryDisplayName = newEntryData.entryDisplayName;
            entryIcon = newEntryData.entryIcon;
            entryDescription = newEntryData.entryDescription;
        
            maxDistance = newEntryData.maxDistance;
            craftSkills = newEntryData.craftSkills;
        }
    }
}