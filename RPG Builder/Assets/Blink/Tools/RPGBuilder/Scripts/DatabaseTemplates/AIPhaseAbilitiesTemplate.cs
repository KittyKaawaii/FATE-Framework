using System.Collections.Generic;
using FATE.FATEAI.Runtime.Data;
using FATE.FATEDatabase.Runtime.DatabaseEntry;

namespace BLINK.RPGBuilder.Templates
{
    public class AIPhaseAbilitiesTemplate : RPGBuilderDatabaseEntry
    {
        public bool CheckMaxAbilities;
        public int MaxAbilities = 1;

        public List<AIData.AIPhaseAbility> Abilities = new List<AIData.AIPhaseAbility>();
        
        public void UpdateEntryData(AIPhaseAbilitiesTemplate newEntryData)
        {
            EntryName = newEntryData.EntryName;
            EntryFileName = newEntryData.EntryFileName;
            CheckMaxAbilities = newEntryData.CheckMaxAbilities;
            MaxAbilities = newEntryData.MaxAbilities;
            Abilities = newEntryData.Abilities;
        }
    }
}
