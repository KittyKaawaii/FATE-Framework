using System;
using FATE.FATESave.Runtime.Template;

namespace BLINK.RPGBuilder.WorldPersistence
{
    [Serializable]
    public class InteractableObjectSaverTemplate : ObjectSaverTemplate
    {
        public float Cooldown;
        public int UsedCount;
        public bool Unavailable;
    }
}
