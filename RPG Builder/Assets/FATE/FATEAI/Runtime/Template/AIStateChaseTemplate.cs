using System;
using FATE.FATEAI.Runtime.State;
using UnityEngine;

namespace FATE.FATEAI.Runtime.Template
{
    [Serializable, CreateAssetMenu(fileName = "New AI Chase State Template", menuName = "BLINK/AI/Templates/Chase Template")]
    public class AIStateChaseTemplate : AIStateTemplate
    {
        public float MovementSpeedModifier = 1f;
    }
}
