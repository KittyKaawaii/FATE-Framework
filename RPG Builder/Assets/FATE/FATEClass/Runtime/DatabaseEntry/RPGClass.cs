using System.Collections.Generic;
using BLINK.RPGBuilder.Combat;
using BLINK.RPGBuilder.Templates;
using FATE.FATEClass.Runtime.Data;
using FATE.FATECombat.Runtime.Data;
using FATE.FATEDatabase.Runtime.DatabaseEntry;
using FATE.FATEItem.Runtime.Data;
using UnityEngine;

namespace FATE.FATEClass.Runtime.DatabaseEntry
{
    public class RPGClass : RPGBuilderDatabaseEntry
    {
        [HideInInspector] public string _name;
        [HideInInspector] public string _fileName;
        [HideInInspector] public string displayName;
        [HideInInspector] public string description;
        [HideInInspector] public Sprite icon;
    

        public int autoAttackAbilityID = -1;

        public List<CLASS_STATS_DATA> stats = new List<CLASS_STATS_DATA>();
        public List<CombatData.CustomStatValues> CustomStats = new List<CombatData.CustomStatValues>();
        public bool UseStatListTemplate;
        public StatListTemplate StatListTemplate;

        public int levelTemplateID = -1;

        public List<TalentTreesDATA> talentTrees = new List<TalentTreesDATA>();

        public List<SpellbookDATA> spellbooks = new List<SpellbookDATA>();
    
        public List<RPGItemDATA.StartingItemsDATA> startItems = new List<RPGItemDATA.StartingItemsDATA>();

        public List<RPGCombatDATA.ActionAbilityDATA> actionAbilities = new List<RPGCombatDATA.ActionAbilityDATA>();
    
        public int allocationStatPoints;
        public List<CharacterEntries.AllocatedStatEntry> allocatedStatsEntries = new List<CharacterEntries.AllocatedStatEntry>();
    
        public List<CharacterEntries.AllocatedStatEntry> allocatedStatsEntriesGame = new List<CharacterEntries.AllocatedStatEntry>();
        public void UpdateEntryData(RPGClass newEntryData)
        {
            ID = newEntryData.ID;
            EntryName = newEntryData.EntryName;
            EntryFileName = newEntryData.EntryFileName;
            EntryDisplayName = newEntryData.EntryDisplayName;
            EntryIcon = newEntryData.EntryIcon;
            EntryDescription = newEntryData.EntryDescription;
        
            CustomStats = newEntryData.CustomStats;
            UseStatListTemplate = newEntryData.UseStatListTemplate;
            StatListTemplate = newEntryData.StatListTemplate;
            levelTemplateID = newEntryData.levelTemplateID;
            talentTrees = newEntryData.talentTrees;
            autoAttackAbilityID = newEntryData.autoAttackAbilityID;
            startItems = newEntryData.startItems;
            actionAbilities = newEntryData.actionAbilities;
            spellbooks = newEntryData.spellbooks;
            allocationStatPoints = newEntryData.allocationStatPoints;
            allocatedStatsEntries = newEntryData.allocatedStatsEntries;
            allocatedStatsEntriesGame = newEntryData.allocatedStatsEntriesGame;
        }
    }
}