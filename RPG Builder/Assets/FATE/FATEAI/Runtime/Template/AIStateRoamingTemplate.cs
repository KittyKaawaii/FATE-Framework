using System;
using UnityEngine;

namespace FATE.FATEAI.Runtime.Template
{
    [Serializable, CreateAssetMenu(fileName = "New AI Roaming State Template", menuName = "BLINK/AI/Templates/Roaming Template")]
    public class AIStateRoamingTemplate : AIStateIdleTemplate
    {
        public float MinDistanceToMove = 2f;
        public float PauseDuration = 60;
        public float RoamDistance = 15;
        public float RoamPointThreshold;
        public LayerMask roamGroundLayers;
        public float roamTargetCheckInterval = 0.25f;
        public bool roamAroundSpawner = true;
    }
}
