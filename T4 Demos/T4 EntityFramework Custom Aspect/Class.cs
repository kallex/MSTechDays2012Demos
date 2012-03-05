using System;

namespace T4_EntityFramework_Custom_Aspect
{
    partial class Class
    {
        public override string ToString()
        {
            return "Class:" + Environment.NewLine + "ClassName: " + ClassName;
        }  
    }
}