using System;
using System.Collections.Generic;
using System.Text;

namespace QuickReportCore.Objects
{
    /// <summary>
    /// ²Ù×÷·û¡£
    /// </summary>
    internal class Operator : BaseObject
    {
        public Operator(string id,string name)
        {
            ID = id;
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
