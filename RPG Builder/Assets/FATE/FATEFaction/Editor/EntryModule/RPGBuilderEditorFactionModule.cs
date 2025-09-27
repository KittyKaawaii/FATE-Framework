using System;
using System.Collections.Generic;
using FATE.FATECombat.Runtime.Data;
using FATE.FATEDatabase.Editor.EntryModule;
using FATE.FATEDatabase.Editor.Manager;
using FATE.FATEDatabase.Editor.Utility;
using FATE.FATEDatabase.Runtime.DatabaseEntry;
using FATE.FATEFaction.Runtime.Data;
using FATE.FATEFaction.Runtime.DatabaseEntry;
using FATE.FATEFaction.Runtime.DatabaseTypeEntry;
using UnityEditor;
using UnityEngine;

namespace FATE.FATEFaction.Editor.EntryModule
{
    public class RPGBuilderEditorFactionModule : RPGBuilderEditorModule
    {
        private Dictionary<int, RPGFaction> entries = new();
        private RPGFaction currentEntry;

        private readonly List<RPGBuilderDatabaseEntry> allFactionStances = new();

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

            RPGBuilderEditor.Instance.InitializeFilters(RPGBuilderEditor.Instance.EditorFilters.factionFilters);
        }

        public override void InstantiateCurrentEntry(int index)
        {
            if (entries.Count == 0) return;
            currentEntry = Instantiate(entries[index]);
            RPGBuilderEditor.Instance.CurrentEntry = currentEntry;
        }


        public override void LoadEntries()
        {
            Dictionary<int, RPGFaction> dictionary = new Dictionary<int, RPGFaction>();
            databaseEntries.Clear();
            allFactionStances.Clear();
            var allEntries =
                Resources.LoadAll<RPGFaction>(RPGBuilderEditor.Instance.EditorData.RPGBDatabasePath + AssetFolderName);
            for (var index = 0; index < allEntries.Length; index++)
            {
                var entry = allEntries[index];
                dictionary.Add(index, entry);
                databaseEntries.Add(entry);
            }

            entries = dictionary;

            foreach (var typeEntry in Resources.LoadAll<RPGBFactionStance>(RPGBuilderEditor.Instance.EditorSettings
                         .DatabasePath))
            {
                allFactionStances.Add(typeEntry);
            }
        }


        public override void CreateNewEntry()
        {
            if (EditorApplication.isCompiling)
            {
                Debug.LogError("You cannot interact with the RPG Builder while the editor is compiling");
                return;
            }

            currentEntry = CreateInstance<RPGFaction>();
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
            RPGFaction entryFile = (RPGFaction) updatedEntry;
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

            RPGBuilderEditor.Instance.EditorFilters.factionModuleSection.showBaseInfo =
                RPGBuilderEditorUtility.HandleModuleBanner("BASE INFO",
                    RPGBuilderEditor.Instance.EditorFilters.factionModuleSection.showBaseInfo);
            if (RPGBuilderEditor.Instance.EditorFilters.factionModuleSection.showBaseInfo)
            {
                GUILayout.Space(5);
                RPGBuilderEditorUtility.StartHorizontalMargin(RPGBuilderEditor.Instance.LongHorizontalMargin, false);
                currentEntry.EntryIcon = RPGBuilderEditorFields.DrawIcon(currentEntry.EntryIcon, 100, 100);
                GUILayout.BeginVertical();
                RPGBuilderEditorFields.DrawID(currentEntry.ID);
                currentEntry.EntryName =
                    RPGBuilderEditorFields.DrawHorizontalTextField("Name", "", RPGBuilderEditor.Instance.FieldHeight,
                        currentEntry.EntryName);
                currentEntry.EntryDisplayName = RPGBuilderEditorFields.DrawHorizontalTextField("Display Name", "",
                    RPGBuilderEditor.Instance.FieldHeight,
                    currentEntry.EntryDisplayName);
                currentEntry.EntryFileName = RPGBuilderEditorFields.DrawFileNameField("File Name", "",
                    RPGBuilderEditor.Instance.FieldHeight,
                    currentEntry.EntryName + AssetNameSuffix);
                currentEntry.EntryDescription = RPGBuilderEditorFields.DrawHorizontalDescriptionField("Description", "",
                    RPGBuilderEditor.Instance.FieldHeight,
                    currentEntry.EntryDescription);
                GUILayout.EndVertical();
                RPGBuilderEditorUtility.EndHorizontalMargin(RPGBuilderEditor.Instance.LongHorizontalMargin, false);
            }

            GUILayout.Space(10);
            RPGBuilderEditor.Instance.EditorFilters.factionModuleSection.showStances =
                RPGBuilderEditorUtility.HandleModuleBanner("STANCES",
                    RPGBuilderEditor.Instance.EditorFilters.factionModuleSection.showStances);
            if (RPGBuilderEditor.Instance.EditorFilters.factionModuleSection.showStances)
            {
                GUILayout.Space(10);
                if (RPGBuilderEditorFields.DrawHorizontalAddButton("Add Stance", true))
                {
                    currentEntry.FactionStances.Add(new FactionStanceData());
                }

                var ThisList = serialObj.FindProperty("factionStances");
                currentEntry.FactionStances =
                    RPGBuilderEditor.Instance.GetTargetObjectOfProperty(ThisList) as List<FactionStanceData>;

                RPGBuilderEditorUtility.StartHorizontalMargin(RPGBuilderEditor.Instance.LongHorizontalMargin, true);
                for (var a = 0; a < currentEntry.FactionStances.Count; a++)
                {
                    GUILayout.Space(10);

                    RPGBuilderEditorFields.DrawHorizontalLabel("Stance", "");
                    int weaponSlotIndex = EditorGUILayout.Popup(
                        RPGBuilderEditorUtility.GetTypeEntryIndex(allFactionStances,
                            currentEntry.FactionStances[a].FactionStance),
                        RPGBuilderEditorUtility.GetTypeEntriesAsStringArray(allFactionStances.ToArray()));
                    currentEntry.FactionStances[a].FactionStance = (RPGBFactionStance) allFactionStances[weaponSlotIndex];
                    if (RPGBuilderEditorFields.DrawSmallRemoveButton())
                    {
                        currentEntry.FactionStances.RemoveAt(a);
                        return;
                    }
                    EditorGUILayout.EndHorizontal();

                    currentEntry.FactionStances[a].AlignmentToPlayer =
                        (CombatData.EntityAlignment) RPGBuilderEditorFields.DrawHorizontalEnum("Player Alignment", "The player alignment to this faction when this stance is active",
                            (int)currentEntry.FactionStances[a].AlignmentToPlayer,
                            Enum.GetNames(typeof(CombatData.EntityAlignment)));

                    currentEntry.FactionStances[a].PointsRequired =
                        RPGBuilderEditorFields.DrawHorizontalIntField("Points Required",
                            "The amount of points required to reach this stance",
                            RPGBuilderEditor.Instance.FieldHeight,
                            currentEntry.FactionStances[a].PointsRequired);
                }

                RPGBuilderEditorUtility.EndHorizontalMargin(RPGBuilderEditor.Instance.LongHorizontalMargin, true);
            }

            GUILayout.Space(10);
            RPGBuilderEditor.Instance.EditorFilters.factionModuleSection.showInteractions =
                RPGBuilderEditorUtility.HandleModuleBanner("INTERACTIONS",
                    RPGBuilderEditor.Instance.EditorFilters.factionModuleSection.showInteractions);
            if (RPGBuilderEditor.Instance.EditorFilters.factionModuleSection.showInteractions)
            {
                GUILayout.Space(10);
                if (RPGBuilderEditorFields.DrawHorizontalAddButton("Add Interaction", true))
                {
                    currentEntry.FactionInteractions.Add(new FactionInteractionData());
                }

                var ThisList2 = serialObj.FindProperty("factionInteractions");
                currentEntry.FactionInteractions =
                    RPGBuilderEditor.Instance.GetTargetObjectOfProperty(ThisList2) as
                        List<FactionInteractionData>;

                GUILayout.Space(10);
                RPGBuilderEditorUtility.StartHorizontalMargin(RPGBuilderEditor.Instance.LongHorizontalMargin, true);
                for (var a = 0; a < currentEntry.FactionInteractions.Count; a++)
                {
                    GUILayout.Space(10);
                    if (RPGBuilderEditorFields.DrawHorizontalEntryRemoveButton(
                            currentEntry.FactionInteractions[a].FactionID,
                            "Faction"))
                    {
                        currentEntry.FactionInteractions.RemoveAt(a);
                        return;
                    }

                    currentEntry.FactionInteractions[a].FactionID = RPGBuilderEditorFields.DrawDatabaseEntryField(
                        currentEntry.FactionInteractions[a].FactionID,
                        "Faction", "Faction", "");

                    RPGBuilderEditorFields.DrawHorizontalLabel("Stance", "");
                    int weaponSlotIndex = EditorGUILayout.Popup(
                        RPGBuilderEditorUtility.GetTypeEntryIndex(allFactionStances,
                            currentEntry.FactionInteractions[a].DefaultFactionStance),
                        RPGBuilderEditorUtility.GetTypeEntriesAsStringArray(allFactionStances.ToArray()));
                    currentEntry.FactionInteractions[a].DefaultFactionStance =
                        (RPGBFactionStance) allFactionStances[weaponSlotIndex];
                    EditorGUILayout.EndHorizontal();

                    currentEntry.FactionInteractions[a].StartingPoints =
                        RPGBuilderEditorFields.DrawHorizontalIntField("Start Points",
                            "The amount of points the stance start by default",
                            RPGBuilderEditor.Instance.FieldHeight,
                            currentEntry.FactionInteractions[a].StartingPoints);

                    GUILayout.Space(10);
                }

                RPGBuilderEditorUtility.EndHorizontalMargin(RPGBuilderEditor.Instance.LongHorizontalMargin, true);
                GUILayout.Space(10);
            }

            serialObj.ApplyModifiedProperties();

            GUILayout.Space(25);
            GUILayout.EndScrollView();

        }
    }
}

    

