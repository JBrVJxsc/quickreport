using System;
using System.Collections.Generic;
using System.Text;

namespace QuickReportCore.Objects
{
    /// <summary>
    /// 可进行比较的Row。
    /// </summary>
    internal class CompareableRow : BaseObject
    {
        public CompareableRow(object objectToCompare, FarPoint.Win.Spread.Row r)
        {
            comparer = objectToCompare;
            row = r;
        }

        private object comparer;
        /// <summary>
        /// 用作比较的载体。
        /// </summary>
        public object Comparer
        {
            get
            {
                return comparer;
            }
        }

        private FarPoint.Win.Spread.Row row;
        /// <summary>
        /// Row。
        /// </summary>
        public FarPoint.Win.Spread.Row Row
        {
            get
            {
                return row;
            }
        }
    }
}
