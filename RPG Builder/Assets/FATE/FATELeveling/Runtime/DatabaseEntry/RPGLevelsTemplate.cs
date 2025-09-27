using System;
using System.Collections.Generic;
using FATE.FATEDatabase.Runtime.DatabaseEntry;
using UnityEngine;

namespace FATE.FATELeveling.Runtime.DatabaseEntry
{
    public class RPGLevelsTemplate : RPGBuilderDatabaseEntry
    {
        [HideInInspector] public string _name;
        [HideInInspector] public string _fileName;
    
    
        public int levels;
        public int baseXPValue;
        public float increaseAmount;
        public GameObject levelUpPrefab;

        [Serializable]
        public class LEVELS_DATA
        {
            public string levelName;
            public int level;
            public int XPRequired;
        }

        public List<LEVELS_DATA> allLevels = new List<LEVELS_DATA>();

        public void UpdateEntryData(RPGLevelsTemplate newEntryData)
        {
            ID = newEntryData.ID;
            EntryName = newEntryData.EntryName;
            EntryFileName = newEntryData.EntryFileName;
            EntryDisplayName = newEntryData.EntryDisplayName;
            EntryIcon = newEntryData.EntryIcon;
            EntryDescription = newEntryData.EntryDescription;
        
            levels = newEntryData.levels;
            baseXPValue = newEntryData.baseXPValue;
            increaseAmount = newEntryData.increaseAmount;
            allLevels = newEntryData.allLevels;
            levelUpPrefab = newEntryData.levelUpPrefab;
        }
    }
}