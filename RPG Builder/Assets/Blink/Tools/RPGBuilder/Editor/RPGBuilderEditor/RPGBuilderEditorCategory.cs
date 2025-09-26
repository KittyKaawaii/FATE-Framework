using System.Collections.Generic;
using FATE.FATEDatabase.Editor.EntryModule;
using UnityEngine;

public class RPGBuilderEditorCategory : ScriptableObject
{
    public string CategoryName;
    public int OrderIndex;
    
    public bool IsEnabled = true;
    public bool IsExpanded;
    public bool IsDatabaseCategory;
    
    public List<RPGBuilderEditorModule> modules = new List<RPGBuilderEditorModule>();
}
