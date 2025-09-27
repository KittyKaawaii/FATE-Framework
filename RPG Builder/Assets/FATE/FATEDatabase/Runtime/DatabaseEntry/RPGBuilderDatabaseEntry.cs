
using FATE.FATECustomAttribute.Runtime.AttributeParam;
using UnityEngine;

namespace FATE.FATEDatabase.Runtime.DatabaseEntry
{
    
    public abstract class RPGBuilderDatabaseEntry : ScriptableObject
    {
        [Header("Для изменения значений перейдите в базу данных")]
        [ReadOnlyField]public int ID = -1;

        [DisplayName("Наименование")][ReadOnlyField]public string entryName;

        [DisplayName("На")][ReadOnlyField]public string entryFileName;

        [ReadOnlyField]public string entryDisplayName;

        [ReadOnlyField]public Sprite entryIcon;

        [ReadOnlyField]public string entryDescription;
    }
}