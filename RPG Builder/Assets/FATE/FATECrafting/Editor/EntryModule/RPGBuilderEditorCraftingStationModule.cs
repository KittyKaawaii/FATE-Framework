using System.Collections.Generic;
using FATE.FATECrafting.Runtime.DatabaseEntry;
using FATE.FATEDatabase.Editor.EntryModule;
using FATE.FATEDatabase.Editor.Manager;
using FATE.FATEDatabase.Editor.Utility;
using FATE.FATEDatabase.Runtime.DatabaseEntry;
using UnityEditor;
using UnityEngine;

namespace FATE.FATECrafting.Editor.EntryModule
{
    public class RPGBuilderEditorCraftingStationModule : RPGBuilderEditorModule
    {
        private Dictionary<int, RPGCraftingStation> entries = new Dictionary<int, RPGCraftingStation>();
        private RPGCraftingStation currentEntry;

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
            RPGBuilderEditor.Instance.InitializeFilters(RPGBuilderEditor.Instance.EditorFilters.craftingStationFilters);
        }

        public override void InstantiateCurrentEntry(int index)
        {
            if (entries.Count == 0) return;
            currentEntry = Instantiate(entries[index]);
            RPGBuilderEditor.Instance.CurrentEntry = currentEntry;
        }

        public override void LoadEntries()
        {
            Dictionary<int, RPGCraftingStation> dictionary = new Dictionary<int, RPGCraftingStation>();
            databaseEntries.Clear();
            var allEntries =
                Resources.LoadAll<RPGCraftingStation>(RPGBuilderEditor.Instance.EditorData.RPGBDatabasePath +
                                                      AssetFolderName);
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

            currentEntry = CreateInstance<RPGCraftingStation>();
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
            RPGCraftingStation entryFile = (RPGCraftingStation) updatedEntry;
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

            ScriptableObject scriptableObj = currentEntry;
            var serialObj = new SerializedObject(scriptableObj);

            float topSpace = RPGBuilderEditor.Instance.ButtonHeight + 5;
            GUILayout.Space(topSpace);
        
            RPGBuilderEditor.Instance.ViewScroll = EditorGUILayout.BeginScrollView(RPGBuilderEditor.Instance.ViewScroll,
                false, false,
                GUILayout.Width(RPGBuilderEditor.Instance.ViewWidth),
                GUILayout.MaxWidth(RPGBuilderEditor.Instance.ViewWidth),
                GUILayout.ExpandHeight(true));

            GUILayout.Space(10);
            RPGBuilderEditor.Instance.EditorFilters.craftingStationModuleSection.showBaseInfo =
                RPGBuilderEditorUtility.HandleModuleBanner("BASE INFO",
                    RPGBuilderEditor.Instance.EditorFilters.craftingStationModuleSection.showBaseInfo);
            if (RPGBuilderEditor.Instance.EditorFilters.craftingStationModuleSection.showBaseInfo)
            {
                GUILayout.Space(10);
                RPGBuilderEditorUtility.StartHorizontalMargin(RPGBuilderEditor.Instance.LongHorizontalMargin, false);
                currentEntry.EntryIcon =
                    RPGBuilderEditorFields.DrawIcon(currentEntry.EntryIcon, 100, 100);
                GUILayout.BeginVertical();
                RPGBuilderEditorFields.DrawID(currentEntry.ID);
                currentEntry.EntryName =
                    RPGBuilderEditorFields.DrawHorizontalTextField("Name", "", RPGBuilderEditor.Instance.FieldHeight,
                        currentEntry.EntryName);
                currentEntry.EntryDisplayName = RPGBuilderEditorFields.DrawHorizontalTextField("Display Name",
                    "", RPGBuilderEditor.Instance.FieldHeight,
                    currentEntry.EntryDisplayName);
                currentEntry.EntryFileName = RPGBuilderEditorFields.DrawFileNameField("File Name", "",
                    RPGBuilderEditor.Instance.FieldHeight,
                    currentEntry.EntryName + AssetNameSuffix);
                GUILayout.EndVertical();
                RPGBuilderEditorUtility.EndHorizontalMargin(RPGBuilderEditor.Instance.LongHorizontalMargin, false);
            }

            GUILayout.Space(10);
            RPGBuilderEditor.Instance.EditorFilters.craftingStationModuleSection.showSkills =
                RPGBuilderEditorUtility.HandleModuleBanner("SKILLS",
                    RPGBuilderEditor.Instance.EditorFilters.craftingStationModuleSection.showSkills);
            if (RPGBuilderEditor.Instance.EditorFilters.craftingStationModuleSection.showSkills)
            {
                GUILayout.Space(10);
                if (RPGBuilderEditorFields.DrawHorizontalAddButton("Add Skill", true))
                {
                    currentEntry.craftSkills.Add(new RPGCraftingStation.CraftSkillsDATA());
                }

                var ThisList2 = serialObj.FindProperty("craftSkills");
                currentEntry.craftSkills =
                    RPGBuilderEditor.Instance.GetTargetObjectOfProperty(ThisList2) as
                        List<RPGCraftingStation.CraftSkillsDATA>;

                RPGBuilderEditorUtility.StartHorizontalMargin(RPGBuilderEditor.Instance.LongHorizontalMargin, true);
                for (var a = 0; a < currentEntry.craftSkills.Count; a++)
                {
                    GUILayout.Space(10);
                    if (RPGBuilderEditorFields.DrawHorizontalEntryRemoveButton(
                            currentEntry.craftSkills[a].craftSkillID,
                            "Skill"))
                    {
                        currentEntry.craftSkills.RemoveAt(a);
                        return;
                    }

                    currentEntry.craftSkills[a].craftSkillID =
                        RPGBuilderEditorFields.DrawDatabaseEntryField(
                            currentEntry.craftSkills[a].craftSkillID, "Skill", "Skill", "");
                }

                RPGBuilderEditorUtility.EndHorizontalMargin(RPGBuilderEditor.Instance.LongHorizontalMargin, true);
            }

            serialObj.ApplyModifiedProperties();

            GUILayout.Space(25);
            GUILayout.EndScrollView();
        }
    
        public override void ConvertDatabaseEntriesAfterUpdate ()
        {
            var allEntries = Resources.LoadAll<RPGCraftingStation>(RPGBuilderEditor.Instance.EditorData.RPGBDatabasePath + AssetFolderName);
            foreach (var entry in allEntries)
            {
                EditorUtility.SetDirty(entry);
                entry.EntryName = entry._name;
                AssetDatabase.RenameAsset(RPGBuilderEditor.Instance.EditorData.ResourcePath + 
                                          RPGBuilderEditor.Instance.EditorData.RPGBDatabasePath + AssetFolderName + "/" + entry._fileName + ".asset", entry.EntryName + AssetNameSuffix);
                entry.EntryFileName = entry.EntryName + AssetNameSuffix;
                entry.EntryDisplayName = entry.displayName;
                entry.EntryIcon = entry.icon;
                EditorUtility.SetDirty(entry);
            }
        
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }
    }
}
