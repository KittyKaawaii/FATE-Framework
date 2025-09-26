using System;
using UnityEngine;

namespace FATE.FATEAI.Runtime.Template
{
    [Serializable, CreateAssetMenu(fileName = "New AI Circling Target State Template", menuName = "BLINK/AI/Templates/Combat Circling Target Template")]
    public class AIStateCircleTargetTemplate : AIStateCombatIdleTemplate
    {
        public float minimumTimeBetweenDirectionChange = 3;
        public float maximumTimeBetweenDirectionChange = 3;
    }
}
