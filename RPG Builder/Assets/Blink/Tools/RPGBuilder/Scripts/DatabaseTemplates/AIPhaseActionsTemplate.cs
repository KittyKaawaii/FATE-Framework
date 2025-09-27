using System.Collections.Generic;
using FATE.FATEAI.Runtime.Data;
using FATE.FATEDatabase.Runtime.DatabaseEntry;

namespace BLINK.RPGBuilder.Templates
{
    public class AIPhaseActionsTemplate : RPGBuilderDatabaseEntry
    {
        public List<AIData.AIPhaseAction> PhaseActions = new List<AIData.AIPhaseAction>();
        
        public void UpdateEntryData(AIPhaseActionsTemplate newEntryData)
        {
            EntryName = newEntryData.EntryName;
            EntryFileName = newEntryData.EntryFileName;
            PhaseActions = newEntryData.PhaseActions;
        }
    }
}
