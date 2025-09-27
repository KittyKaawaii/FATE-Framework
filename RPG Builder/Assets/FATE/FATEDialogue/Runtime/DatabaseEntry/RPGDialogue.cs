using FATE.FATEDatabase.Runtime.DatabaseEntry;
using FATE.FATEDialogue.Runtime.Node;
using UnityEngine;

namespace FATE.FATEDialogue.Runtime.DatabaseEntry
{
    public class RPGDialogue : RPGBuilderDatabaseEntry
    {
        [HideInInspector] public string _name;
        [HideInInspector] public string _fileName;
        [HideInInspector] public string displayName;
        [HideInInspector] public string description;

        public RPGDialogueGraph dialogueGraph;

        public bool hasExitNode;
        public string exitNodeText = "Goodbye";
    
        public void UpdateEntryData(RPGDialogue newEntryData)
        {
            ID = newEntryData.ID;
            EntryName = newEntryData.EntryName;
            EntryFileName = newEntryData.EntryFileName;
            EntryDisplayName = newEntryData.EntryDisplayName;
            EntryIcon = newEntryData.EntryIcon;
            EntryDescription = newEntryData.EntryDescription;
        
            dialogueGraph = newEntryData.dialogueGraph;
            hasExitNode = newEntryData.hasExitNode;
            exitNodeText = newEntryData.exitNodeText;
        }
    }
}
