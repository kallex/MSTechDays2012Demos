using System;

namespace T4_EntityFramework_Custom_Aspect
{
    partial class ClassProperty
    {
        public override string ToString()
        {
            return "Property: " + Environment.NewLine +  "PropertyType: " + PropertyType + Environment.NewLine + "Property Name: " + PropertyName;
        }
    }
}