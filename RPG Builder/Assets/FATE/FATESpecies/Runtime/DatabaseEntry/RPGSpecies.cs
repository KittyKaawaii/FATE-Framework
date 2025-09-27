using System;
using System.Collections.Generic;
using BLINK.RPGBuilder.Templates;
using FATE.FATECombat.Runtime.Data;
using FATE.FATEDatabase.Runtime.DatabaseEntry;
using FATE.FATEStat.Runtime.DatabaseEntry;
using UnityEngine;

namespace FATE.FATESpecies.Runtime.DatabaseEntry
{
    public class RPGSpecies : RPGBuilderDatabaseEntry
    {
        [HideInInspector] public string _name;
        [HideInInspector] public string displayName;
        [HideInInspector] public string fileName;
        [HideInInspector] public string description;
        [HideInInspector] public Sprite icon;
    
    
        [Serializable]
        public class SPECIES_STAT_DATA
        {
            public int statID = -1;
            public float value;
        
            public List<RPGStat.VitalityActions> vitalityActions = new List<RPGStat.VitalityActions>();
        }

        public List<SPECIES_STAT_DATA> stats = new List<SPECIES_STAT_DATA>();
        public List<CombatData.CustomStatValues> CustomStats = new List<CombatData.CustomStatValues>();
        public bool UseStatListTemplate;
        public StatListTemplate StatListTemplate;
    
        [Serializable]
        public class SPECIES_TRAIT
        {
            [HideInInspector] public string statFunction;
            public RPGBDamageType damageType;
            public float modifier = 100;
        }

        public List<SPECIES_TRAIT> traits = new List<SPECIES_TRAIT>();
    
        public void UpdateEntryData(RPGSpecies newEntryData)
        {
            ID = newEntryData.ID;
            entryName = newEntryData.entryName;
            entryFileName = newEntryData.entryFileName;
            entryDisplayName = newEntryData.entryDisplayName;
            entryIcon = newEntryData.entryIcon;
            entryDescription = newEntryData.entryDescription;

            CustomStats = newEntryData.CustomStats;
            UseStatListTemplate = newEntryData.UseStatListTemplate;
            StatListTemplate = newEntryData.StatListTemplate;
            traits = newEntryData.traits;
        }
    }
}
