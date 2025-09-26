using System;
using FATE.FATEAI.Runtime.State;
using UnityEngine;

namespace FATE.FATEAI.Runtime.Template
{
    [Serializable, CreateAssetMenu(fileName = "New AI Walk Backward State Template", menuName = "BLINK/AI/Templates/Walk Backward Template")]
    public class AIStateWalkBackwardTemplate : AIStateTemplate
    {
        public float MovementSpeedModifier = 0.5f;
    }
}
