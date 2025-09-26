using System;
using FATE.FATESave.Runtime.Template;

namespace BLINK.RPGBuilder.WorldPersistence
{
    [Serializable]
    public class ColliderSaverTemplate : ObjectSaverTemplate
    {
        public bool Enabled;
        public bool IsTrigger;
    }
}
