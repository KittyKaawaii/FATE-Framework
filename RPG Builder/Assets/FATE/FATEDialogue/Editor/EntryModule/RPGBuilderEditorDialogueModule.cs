using System.Collections.Generic;
using FATE.FATEDatabase.Editor.EntryModule;
using FATE.FATEDatabase.Editor.Manager;
using FATE.FATEDatabase.Editor.Utility;
using FATE.FATEDatabase.Runtime.DatabaseEntry;
using FATE.FATEDialogue.Runtime.DatabaseEntry;
using FATE.FATEDialogue.Runtime.Node;
using UnityEditor;
using UnityEngine;

namespace FATE.FATEDialogue.Editor.EntryModule
{
    public class RPGBuilderEditorDialogueModule : RPGBuilderEditorModule
    {
        private Dictionary<int, RPGDialogue> entries = new Dictionary<int, RPGDialogue>();
        private RPGDialogue currentEntry;
    
        public override void Initialize()
        {
            LoadEntries();
            if (entries.Count != 0)
            {
                currentEntry = Instantiate(entries[RPGBuilderEditor.Instance.CurrentEntryIndex]);
                RPGBuilderEditor.Instance.CurrentEntry = currentEntry;
            }
            else
            {
                CreateNewEntry();
            }
            RPGBuilderEditor.Instance.InitializeFilters(RPGBuilderEditor.Instance.EditorFilters.dialogueFilters);
        }

        public override void InstantiateCurrentEntry(int index)
        {
            if (entries.Count == 0) return;
            currentEntry = Instantiate(entries[index]);
            RPGBuilderEditor.Instance.CurrentEntry = currentEntry;
        }

        public override void LoadEntries()
        {
            Dictionary<int, RPGDialogue> dictionary = new Dictionary<int, RPGDialogue>();
            databaseEntries.Clear();
            var allEntries = Resources.LoadAll<RPGDialogue>(RPGBuilderEditor.Instance.EditorData.RPGBDatabasePath + AssetFolderName);
            for (var index = 0; index < allEntries.Length; index++)
            {
                var entry = allEntries[index];
                dictionary.Add(index, entry);
                databaseEntries.Add(entry);
            }
            entries = dictionary;
        }
    
    

        public override void CreateNewEntry()
        {
            if (EditorApplication.isCompiling)
            { 
                Debug.LogError("You cannot interact with the RPG Builder while the editor is compiling");
                return;
            }
        
            currentEntry = CreateInstance<RPGDialogue>();
            RPGBuilderEditor.Instance.CurrentEntry = currentEntry;
            RPGBuilderEditor.Instance.CurrentEntryIndex = -1;
        }

    

        public override bool SaveConditionsMet()
        {
            if (string.IsNullOrEmpty(currentEntry.EntryName))
            {
                RPGBuilderEditorUtility.DisplayDialogueWindow("Invalid Name", "Enter a valid name", "OK");
                return false;
            }
            if (ContainsInvalidCharacters(currentEntry.EntryName))
            {
                RPGBuilderEditorUtility.DisplayDialogueWindow("Invalid Characters", "The Name contains invalid characters", "OK");
                return false;
            }
        
            return true;
        }

        public override void UpdateEntryData(RPGBuilderDatabaseEntry updatedEntry)
        {
            RPGDialogue entryFile = (RPGDialogue)updatedEntry;
            entryFile.UpdateEntryData(currentEntry);
        }
    
        public override void ClearEntries()
        {
            databaseEntries.Clear();
            entries.Clear();
            currentEntry = null;
        }
    
        public override void DrawView()
        {
            if (currentEntry == null)
            {
                if (entries.Count > 0 && entries[0] != null)
                {
                    RPGBuilderEditor.Instance.SelectDatabaseEntry(0, true);
                }
                else
                {
                    CreateNewEntry();
                }
            }

            RPGBuilderEditorUtility.UpdateViewAndFieldData();

            float topSpace = RPGBuilderEditor.Instance.ButtonHeight + 5;
            GUILayout.Space(topSpace);
        
            RPGBuilderEditor.Instance.ViewScroll = EditorGUILayout.BeginScrollView(RPGBuilderEditor.Instance.ViewScroll,
                false, false,
                GUILayout.Width(RPGBuilderEditor.Instance.ViewWidth),
                GUILayout.MaxWidth(RPGBuilderEditor.Instance.ViewWidth),
                GUILayout.ExpandHeight(true));

            GUILayout.Space(10);
            RPGBuilderEditor.Instance.EditorFilters.dialogueModuleSection.showBaseInfo =
                RPGBuilderEditorUtility.HandleModuleBanner("BASE INFO",
                    RPGBuilderEditor.Instance.EditorFilters.dialogueModuleSection.showBaseInfo);
            if (RPGBuilderEditor.Instance.EditorFilters.dialogueModuleSection.showBaseInfo)
            {
                GUILayout.Space(10);
                RPGBuilderEditorUtility.StartHorizontalMargin(RPGBuilderEditor.Instance.LongHorizontalMargin, true);
                RPGBuilderEditorFields.DrawID(currentEntry.ID);
                currentEntry.EntryName =
                    RPGBuilderEditorFields.DrawHorizontalTextField("Name", "", RPGBuilderEditor.Instance.FieldHeight,
                        currentEntry.EntryName);
                currentEntry.EntryDisplayName = RPGBuilderEditorFields.DrawHorizontalTextField(
                    "Display Name", "", RPGBuilderEditor.Instance.FieldHeight,
                    currentEntry.EntryDisplayName);
                currentEntry.EntryFileName = RPGBuilderEditorFields.DrawFileNameField(
                    "File Name", "", RPGBuilderEditor.Instance.FieldHeight,
                    currentEntry.EntryName + AssetNameSuffix);
                currentEntry.EntryDescription =
                    RPGBuilderEditorFields.DrawHorizontalDescriptionField("Description", "",
                        RPGBuilderEditor.Instance.FieldHeight,
                        currentEntry.EntryDescription);
                RPGBuilderEditorUtility.EndHorizontalMargin(RPGBuilderEditor.Instance.LongHorizontalMargin, true);
            }

            GUILayout.Space(10);
            RPGBuilderEditor.Instance.EditorFilters.dialogueModuleSection.showGraphSettings =
                RPGBuilderEditorUtility.HandleModuleBanner("GRAPH",
                    RPGBuilderEditor.Instance.EditorFilters.dialogueModuleSection.showGraphSettings);
            if (RPGBuilderEditor.Instance.EditorFilters.dialogueModuleSection.showGraphSettings)
            {
                GUILayout.Space(10);
                RPGBuilderEditorUtility.StartHorizontalMargin(RPGBuilderEditor.Instance.LongHorizontalMargin, true);
                currentEntry.dialogueGraph =
                    (RPGDialogueGraph) RPGBuilderEditorFields.DrawHorizontalObject<RPGDialogueGraph>("Dialogue Graph", "",
                        currentEntry.dialogueGraph);

                if (currentEntry.dialogueGraph == null)
                {
                    GUILayout.Space(5);
                    if (GUILayout.Button("Create Graph and Assign", RPGBuilderEditor.Instance.EditorSkin.GetStyle("HorizontalAddButton"),
                            GUILayout.MinWidth(150),
                            GUILayout.ExpandWidth(true)))
                    {
                        if (string.IsNullOrEmpty(currentEntry.EntryName))
                        {
                            EditorUtility.DisplayDialog("Warning", "The name cannot be empty", "OK");
                            return;
                        }

                        var existingGraph = (RPGDialogueGraph) AssetDatabase.LoadAssetAtPath(
                            RPGBuilderEditor.Instance.EditorData.ResourcePath +
                            RPGBuilderEditor.Instance.EditorData.RPGBDatabasePath + "DialoguesExternalData/" +
                            currentEntry.EntryFileName + "_GRAPH" + ".asset",
                            typeof(RPGDialogueGraph));
                        if (existingGraph != null)
                        {
                            EditorUtility.DisplayDialog("Graph",
                                "This Dialogue already has a graph created. It was assigned instead of creating a new one",
                                "Ok");

                            currentEntry.dialogueGraph = existingGraph;
                        }
                        else
                        {
                            RPGDialogueGraph newDialogueGraph = CreateInstance<RPGDialogueGraph>();
                            AssetDatabase.CreateAsset(newDialogueGraph,
                                RPGBuilderEditor.Instance.EditorData.ResourcePath +
                                RPGBuilderEditor.Instance.EditorData.RPGBDatabasePath + "DialoguesExternalData/" +
                                currentEntry.EntryFileName + "_GRAPH" + ".asset");

                            AssetDatabase.SaveAssets();
                            AssetDatabase.Refresh();

                            var createdGraph = (RPGDialogueGraph) AssetDatabase.LoadAssetAtPath(
                                RPGBuilderEditor.Instance.EditorData.ResourcePath +
                                RPGBuilderEditor.Instance.EditorData.RPGBDatabasePath + "DialoguesExternalData/" +
                                currentEntry.EntryFileName + "_GRAPH" + ".asset",
                                typeof(RPGDialogueGraph));

                            EditorUtility.SetDirty(newDialogueGraph);
                            EditorUtility.SetDirty(createdGraph);
                            AssetDatabase.SaveAssets();
                            AssetDatabase.Refresh();

                            currentEntry.dialogueGraph = createdGraph;
                        }
                    }
                }

                RPGBuilderEditorUtility.EndHorizontalMargin(RPGBuilderEditor.Instance.LongHorizontalMargin, true);
            }

            GUILayout.Space(10);
            RPGBuilderEditor.Instance.EditorFilters.dialogueModuleSection.showSettings =
                RPGBuilderEditorUtility.HandleModuleBanner("SETTINGS",
                    RPGBuilderEditor.Instance.EditorFilters.dialogueModuleSection.showSettings);
            if (RPGBuilderEditor.Instance.EditorFilters.dialogueModuleSection.showSettings)
            {
                GUILayout.Space(10);
                RPGBuilderEditorUtility.StartHorizontalMargin(RPGBuilderEditor.Instance.LongHorizontalMargin, true);
                currentEntry.hasExitNode = RPGBuilderEditorFields.DrawHorizontalToggle(
                    "Exit Node?", "", RPGBuilderEditor.Instance.FieldHeight,
                    currentEntry.hasExitNode);

                if (currentEntry.hasExitNode)
                {
                    currentEntry.exitNodeText =
                        RPGBuilderEditorFields.DrawHorizontalTextField("Exit Node Message", "",
                            RPGBuilderEditor.Instance.FieldHeight,
                            currentEntry.exitNodeText);
                }

                RPGBuilderEditorUtility.EndHorizontalMargin(RPGBuilderEditor.Instance.LongHorizontalMargin, true);
            }

            GUILayout.Space(25);
            GUILayout.EndScrollView();

        }
    
        public override void ConvertDatabaseEntriesAfterUpdate ()
        {
            var allEntries = Resources.LoadAll<RPGDialogue>(RPGBuilderEditor.Instance.EditorData.RPGBDatabasePath + AssetFolderName);
            foreach (var entry in allEntries)
            {
                EditorUtility.SetDirty(entry);
                entry.EntryName = entry._name;
                AssetDatabase.RenameAsset(RPGBuilderEditor.Instance.EditorData.ResourcePath + 
                                          RPGBuilderEditor.Instance.EditorData.RPGBDatabasePath + AssetFolderName + "/" + entry._fileName + ".asset", entry.EntryName + AssetNameSuffix);
                entry.EntryFileName = entry.EntryName + AssetNameSuffix;
                entry.EntryDisplayName = entry.displayName;
                entry.EntryDescription = entry.description;
                EditorUtility.SetDirty(entry);
            }
        
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }
    }
}
