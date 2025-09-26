using System.Collections.Generic;
using FATE.FATERace.Runtime.DatabaseEntry;
using UnityEngine;

namespace BLINK.RPGBuilder.World
{
    public class CharacterGraveyard : MonoBehaviour
    {
        public List<RPGClass> requiredClasses = new List<RPGClass>();
        public List<RPGRace> requiredRaces = new List<RPGRace>();
    }
}