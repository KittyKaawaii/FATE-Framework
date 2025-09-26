using System;
using FATE.FATEAI.Runtime.State;
using UnityEngine;

namespace FATE.FATEAI.Runtime.Template
{
    [Serializable, CreateAssetMenu(fileName = "New AI Idle State Template", menuName = "BLINK/AI/Templates/Idle Template")]
    public class AIStateIdleTemplate : AIStateTemplate
    {
        public float viewAngle = 60;
        public float viewDistance = 15;

        public float AutoAggroDistance = 5;
        
        public float MovementSpeedModifier = 0.5f;
    }
}
