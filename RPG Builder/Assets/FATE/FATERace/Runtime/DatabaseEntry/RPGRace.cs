using System;
using System.Collections.Generic;
using BLINK.RPGBuilder.Templates;
using FATE.FATECombat.Runtime.Data;
using FATE.FATEDatabase.Runtime.DatabaseEntry;
using FATE.FATEItem.Runtime.Data;
using UnityEngine;

namespace FATE.FATERace.Runtime.DatabaseEntry
{
    public class RPGRace : RPGBuilderDatabaseEntry
    {
        [HideInInspector] public string _name;
        [HideInInspector] public string _fileName;
        [HideInInspector] public string displayName;
        [HideInInspector] public string description;
    
        public int startingSceneID = -1;
        public int startingPositionID = -1;
    
        public int factionID = -1;
        public int speciesID = -1;

        public GameObject malePrefab;
        public Sprite maleIcon;
        public GameObject femalePrefab;
        public Sprite femaleIcon;
        public bool dynamicAnimator;
        public RuntimeAnimatorController restAnimatorController, combatAnimatorController;

        public int levelTemplateID = -1;
    
        [Serializable]
        public class RaceGenderData
        {
            public RPGBGender Gender;
            public GameObject Prefab;
            public Sprite Icon;
            public bool DynamicAnimator;
            public RuntimeAnimatorController RestAnimatorController, CombatAnimatorController;
        }
        public List<RaceGenderData> Genders = new List<RaceGenderData>();

        [Serializable]
        public class RACE_CLASSES_DATA
        {
            public int classID = -1;
        }

        public List<RACE_CLASSES_DATA> availableClasses = new List<RACE_CLASSES_DATA>();

    
        [Serializable]
        public class WEAPON_TEMPLATES_DATA
        {
            public int weaponTemplateID = -1;
        }

        public List<WEAPON_TEMPLATES_DATA> weaponTemplates = new List<WEAPON_TEMPLATES_DATA>();
    
        [Serializable]
        public class RACE_STATS_DATA
        {
            public int statID = -1;
            public float amount;
            public bool isPercent;
        }

        public List<RACE_STATS_DATA> stats = new List<RACE_STATS_DATA>();
        public List<CombatData.CustomStatValues> CustomStats = new List<CombatData.CustomStatValues>();
        public bool UseStatListTemplate;
        public StatListTemplate StatListTemplate;
    

        public List<RPGItemDATA.StartingItemsDATA> startItems = new List<RPGItemDATA.StartingItemsDATA>();
        public List<RPGCombatDATA.ActionAbilityDATA> actionAbilities = new List<RPGCombatDATA.ActionAbilityDATA>();

        public int allocationStatPoints;
        public List<CharacterEntries.AllocatedStatEntry> allocatedStatsEntries = new List<CharacterEntries.AllocatedStatEntry>();
        public void UpdateEntryData(RPGRace newEntryData)
        {
            ID = newEntryData.ID;
            EntryName = newEntryData.EntryName;
            EntryFileName = newEntryData.EntryFileName;
            EntryDisplayName = newEntryData.EntryDisplayName;
            EntryIcon = newEntryData.EntryIcon;
            EntryDescription = newEntryData.EntryDescription;

            Genders = newEntryData.Genders;
            availableClasses = newEntryData.availableClasses;
            weaponTemplates = newEntryData.weaponTemplates;
            CustomStats = newEntryData.CustomStats;
            UseStatListTemplate = newEntryData.UseStatListTemplate;
            StatListTemplate = newEntryData.StatListTemplate;
            startingSceneID = newEntryData.startingSceneID;
            startingPositionID = newEntryData.startingPositionID;
            startItems = newEntryData.startItems;
            actionAbilities = newEntryData.actionAbilities;
            factionID = newEntryData.factionID;
            allocatedStatsEntries = newEntryData.allocatedStatsEntries;
            allocationStatPoints = newEntryData.allocationStatPoints;
            speciesID = newEntryData.speciesID;
            levelTemplateID = newEntryData.levelTemplateID;
        }
    }
}