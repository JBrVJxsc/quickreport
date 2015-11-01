using System;
using System.Collections.Generic;
using System.Text;

namespace QuickReportCore.Objects
{
    /// <summary>
    /// �ɽ��бȽϵ�Row��
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
        /// �����Ƚϵ����塣
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
        /// Row��
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
