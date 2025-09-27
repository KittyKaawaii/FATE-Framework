using FATE.FATECustomAttribute.Runtime.AttributeParam;
using UnityEngine;
using UnityEngine.Serialization;

namespace FATE.FATEDatabase.Runtime.DatabaseEntry
{

    public abstract class RPGBuilderDatabaseEntry : ScriptableObject
    {
        [Header("Для изменения значений перейдите в базу данных")] [ReadOnlyFieldWithName("")]
        public int ID = -1;
        [FormerlySerializedAs("entryName")] [ReadOnlyFieldWithName("Наименование")]
        public string EntryName;

        [FormerlySerializedAs("entryDisplayName"), ReadOnlyFieldWithName("Отображаемое имя")]
        public string EntryDisplayName;

        [FormerlySerializedAs("entryDescription"), ReadOnlyFieldWithName("Описание")]
        public string EntryDescription;

        [FormerlySerializedAs("entryIcon"), ReadOnlyFieldWithName("Иконка")]
        public Sprite EntryIcon;

        [FormerlySerializedAs("entryFileName"), HideInInspector]
        public string EntryFileName;
    }
}