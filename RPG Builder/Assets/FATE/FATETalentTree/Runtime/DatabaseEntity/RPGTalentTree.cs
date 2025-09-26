using System;
using System.Collections.Generic;
using BLINK.RPGBuilder.Templates;
using FATE.FATEDatabase.Runtime.DatabaseEntry;
using UnityEngine;

namespace FATE.FATETalentTree.Runtime.DatabaseEntity
{
    public class RPGTalentTree : RPGBuilderDatabaseEntry
    {
        [HideInInspector] public string _name;
        [HideInInspector] public string displayName;
        [HideInInspector] public string _fileName;
        [HideInInspector] public Sprite icon;

    
        public int TiersAmount;
        public int treePointAcceptedID = -1;

        public enum TalentTreeNodeType
        {
            ability,
            recipe,
            resourceNode,
            bonus
        }

        [Serializable]
        public class Node_DATA
        {
            public TalentTreeNodeType nodeType;
            public string nodeName;
            public int abilityID = -1;
            public int recipeID = -1;
            public int resourceNodeID = -1;
            public int bonusID = -1;
            public int Tier;
            public int Row;

            public RequirementsTemplate RequirementsTemplate;
        }

        public List<Node_DATA> nodeList = new List<Node_DATA>();


        public void UpdateEntryData(RPGTalentTree newEntryData)
        {
            ID = newEntryData.ID;
            entryName = newEntryData.entryName;
            entryFileName = newEntryData.entryFileName;
            entryDisplayName = newEntryData.entryDisplayName;
            entryIcon = newEntryData.entryIcon;
            entryDescription = newEntryData.entryDescription;

            nodeList = newEntryData.nodeList;
            treePointAcceptedID = newEntryData.treePointAcceptedID;
            TiersAmount = newEntryData.TiersAmount;
        }
    }
}