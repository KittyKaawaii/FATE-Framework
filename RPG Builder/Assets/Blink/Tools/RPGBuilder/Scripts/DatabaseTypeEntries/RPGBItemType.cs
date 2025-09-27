using BLINK.RPGBuilder.Data;
using FATE.FATEDatabase.Runtime.DatabaseEntry;

public class RPGBItemType : RPGBuilderDatabaseEntry
{
    public bool CanBeEquipped;
    public EconomyData.EquipFunction EquipType;
    public EconomyData.ItemTypeFunction ItemTypeFunction;
        
    public void UpdateEntryData(RPGBItemType newEntryData)
    {
        entryName = newEntryData.entryName;
        entryFileName = newEntryData.entryFileName;
        entryDisplayName = newEntryData.entryDisplayName;
        CanBeEquipped = newEntryData.CanBeEquipped;
        EquipType = newEntryData.EquipType;
        ItemTypeFunction = newEntryData.ItemTypeFunction;
    }
}
