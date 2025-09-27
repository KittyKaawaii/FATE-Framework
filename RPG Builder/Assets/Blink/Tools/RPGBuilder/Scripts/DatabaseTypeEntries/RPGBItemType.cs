using BLINK.RPGBuilder.Data;
using FATE.FATEDatabase.Runtime.DatabaseEntry;

public class RPGBItemType : RPGBuilderDatabaseEntry
{
    public bool CanBeEquipped;
    public EconomyData.EquipFunction EquipType;
    public EconomyData.ItemTypeFunction ItemTypeFunction;
        
    public void UpdateEntryData(RPGBItemType newEntryData)
    {
        EntryName = newEntryData.EntryName;
        EntryFileName = newEntryData.EntryFileName;
        EntryDisplayName = newEntryData.EntryDisplayName;
        CanBeEquipped = newEntryData.CanBeEquipped;
        EquipType = newEntryData.EquipType;
        ItemTypeFunction = newEntryData.ItemTypeFunction;
    }
}
