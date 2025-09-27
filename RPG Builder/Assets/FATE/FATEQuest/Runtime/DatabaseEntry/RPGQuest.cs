using System;
using System.Collections.Generic;
using BLINK.RPGBuilder.Templates;
using FATE.FATEDatabase.Runtime.DatabaseEntry;
using UnityEngine;

namespace FATE.FATEQuest.Runtime.DatabaseEntry
{
    public class RPGQuest : RPGBuilderDatabaseEntry
    {
        [HideInInspector] public string _name;
        [HideInInspector] public string displayName;
        [HideInInspector] public string _fileName;
        [HideInInspector] public string description;
    
    
        public string ObjectiveText;
        public string ProgressText;

        public bool repeatable;
        public bool canBeTurnedInWithoutNPC;

        public List<RequirementsData.RequirementGroup> Requirements = new List<RequirementsData.RequirementGroup>();
        public bool UseRequirementsTemplate;
        public RequirementsTemplate RequirementsTemplate;

        [Serializable]
        public class QuestItemsGivenDATA
        {
            public int itemID = -1;
            public int count;
        }

        public List<QuestItemsGivenDATA> itemsGiven = new List<QuestItemsGivenDATA>();

        public enum QuestObjectiveType
        {
            task
        }

        [Serializable]
        public class QuestObjectiveDATA
        {
            public QuestObjectiveType objectiveType;
            public int taskID = -1;
            public float timeLimit;
        }

        public List<QuestObjectiveDATA> objectives = new List<QuestObjectiveDATA>();

        public enum QuestRewardType
        {
            item,
            currency,
            treePoint,
            Experience,
            FactionPoint,
            weaponTemplateEXP
        }

        [Serializable]
        public class QuestRewardDATA
        {
            public QuestRewardType rewardType;
            public int itemID = -1;
            public int currencyID = -1;
            public int treePointID = -1;
            public int factionID = -1;
            public int weaponTemplateID = -1;
            public int count;
            public int Experience;
        }

        public List<QuestRewardDATA> rewardsGiven = new List<QuestRewardDATA>();
        public List<QuestRewardDATA> rewardsToPick = new List<QuestRewardDATA>();

        public void UpdateEntryData(RPGQuest newEntryData)
        {
            ID = newEntryData.ID;
            EntryName = newEntryData.EntryName;
            EntryFileName = newEntryData.EntryFileName;
            EntryDisplayName = newEntryData.EntryDisplayName;
            EntryIcon = newEntryData.EntryIcon;
            EntryDescription = newEntryData.EntryDescription;
        
            ObjectiveText = newEntryData.ObjectiveText;
            ProgressText = newEntryData.ProgressText;
            repeatable = newEntryData.repeatable;
            Requirements = newEntryData.Requirements;
            itemsGiven = newEntryData.itemsGiven;
            objectives = newEntryData.objectives;
            rewardsGiven = newEntryData.rewardsGiven;
            rewardsToPick = newEntryData.rewardsToPick;
            canBeTurnedInWithoutNPC = newEntryData.canBeTurnedInWithoutNPC;
            UseRequirementsTemplate = newEntryData.UseRequirementsTemplate;
            RequirementsTemplate = newEntryData.RequirementsTemplate;
        }
    }
}