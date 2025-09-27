using UnityEngine;

namespace FATE.FATEDatabase.Runtime.DatabaseEntry
{
    public abstract class RPGBuilderDatabaseEntry : ScriptableObject
    {
        public int ID = -1;
        public string entryName;
        public string entryFileName;
        public string entryDisplayName;
        public Sprite entryIcon;
        public string entryDescription;
    }
}
