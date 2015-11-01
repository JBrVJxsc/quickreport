using System;
using System.Collections.Generic;
using System.Text;

namespace QuickReportCore.Objects
{
    internal class ConditionTypeElement : BaseObject
    {
        private bool hide = false;
        /// <summary>
        ///  «∑Ò“˛≤ÿ°£
        /// </summary>
        public bool Hide
        {
            get
            {
                return hide;
            }
            set
            {
                hide = value;
            }
        }  
        private int sortId = 0;
        /// <summary>
        /// ≈≈¡––Ú∫≈°£
        /// </summary>
        public int SortId
        {
            get
            {
                return sortId;
            }
            set
            {
                sortId = value;
            }
        }

        public ConditionTypeElement Clone()
        {
            ConditionTypeElement c = new ConditionTypeElement();
            c.ID = ID;
            c.Name = Name;
            c.Hide = Hide;
            c.SortId = SortId;
            return c;
        }
    }
}
