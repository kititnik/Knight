using System;

namespace Cainos.LucidEditor
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Method)]
    public class DisableIfAttribute : Attribute
    {
        public readonly string condition;

        public DisableIfAttribute(string condition)
        {
            this.condition = condition;
        }
    }
}