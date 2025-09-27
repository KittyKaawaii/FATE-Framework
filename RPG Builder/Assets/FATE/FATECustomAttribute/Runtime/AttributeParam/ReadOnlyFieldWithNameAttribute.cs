using UnityEngine;

namespace FATE.FATECustomAttribute.Runtime.AttributeParam
{
    public class ReadOnlyFieldWithNameAttribute : PropertyAttribute
    {
        public readonly string label;

        public ReadOnlyFieldWithNameAttribute(string label) : base(true)
        {
            this.label = label;
        }
    }
}