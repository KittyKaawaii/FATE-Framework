using System;
using FATE.FATESave.Runtime.Template;
using UnityEngine;

namespace BLINK.RPGBuilder.WorldPersistence
{
    [Serializable]
    public class TransformSaverTemplate : ObjectSaverTemplate
    {
        public Vector3 position;
        public Vector3 rotation;
        public Vector3 scale;
    }
}
