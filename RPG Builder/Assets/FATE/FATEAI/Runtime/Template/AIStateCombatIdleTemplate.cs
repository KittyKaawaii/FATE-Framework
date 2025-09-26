using System;
using FATE.FATEAI.Runtime.State;
using UnityEngine;

namespace FATE.FATEAI.Runtime.Template
{
    [Serializable, CreateAssetMenu(fileName = "New AI Combat Idle State Template", menuName = "BLINK/AI/Templates/Combat Idle Template")]
    public class AIStateCombatIdleTemplate : AIStateTemplate
    {
        public float MovementSpeedModifier = 0.5f;
    }
}
