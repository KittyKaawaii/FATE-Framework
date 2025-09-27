using System;
using FATE.FATEAttribute.Runtime.Attribute;

namespace FATE.FATEAbility.Runtime.Data
{
    [Serializable]
    public class AbilityTagsData
    {
        public AbilityTags tag;

        [EffectID] public int effectID = -1;
    }
}