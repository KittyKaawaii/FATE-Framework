using UnityEngine;

namespace FATE.FATECustomAttribute.Runtime.AttributeParam
{
    public class DisplayNameAttribute : PropertyAttribute
    {
        public readonly string label;

        public DisplayNameAttribute(string label) : base(true)
        {
            this.label = label;
        }
    }
}