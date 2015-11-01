using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace QuickReportCore.Objects
{
    internal class CompareableRowComparer : BaseObject, IComparer, IComparer<Objects.CompareableRow>
    {
        public CompareableRowComparer(ValueType vt)
        {
            valueType = vt;
        }

        private ValueType valueType;

        #region IComparer<CompareableRow> 成员

        public int Compare(CompareableRow x, CompareableRow y)
        {
            if (valueType == ValueType.Decimal)
            {
                decimal xv = Convert.ToDecimal(x.Comparer);
                decimal yv = Convert.ToDecimal(y.Comparer);
                if (xv > yv)
                    return 1;
                else if (xv < yv)
                    return -1;
                return 0;
            }
            else if (valueType == ValueType.Int)
            {
                int xv = Convert.ToInt32(x.Comparer);
                int yv = Convert.ToInt32(y.Comparer);
                if (xv > yv)
                    return 1;
                else if (xv < yv)
                    return -1;
                return 0;
            }
            else if (valueType == ValueType.String)
            {
                string xv = x.Comparer.ToString();
                string yv = y.Comparer.ToString();
                return String.CompareOrdinal(xv, yv);
            }
            return 0;
        }

        #endregion

        public enum ValueType
        {
            /// <summary>
            /// Int型。
            /// </summary>
            Int,
            /// <summary>
            /// Decimal型。
            /// </summary>
            Decimal,
            /// <summary>
            /// String型。
            /// </summary>
            String
        }

        #region IComparer 成员

        public int Compare(object x, object y)
        {
            if (valueType == ValueType.Decimal)
            {
                decimal xv = Convert.ToDecimal((x as Objects.CompareableRow).Comparer);
                decimal yv = Convert.ToDecimal((y as Objects.CompareableRow).Comparer);
                if (xv > yv)
                    return 1;
                else if (xv < yv)
                    return -1;
                return 0;
            }
            else if (valueType == ValueType.Int)
            {
                int xv = Convert.ToInt32((x as Objects.CompareableRow).Comparer);
                int yv = Convert.ToInt32((y as Objects.CompareableRow).Comparer);
                if (xv > yv)
                    return 1;
                else if (xv < yv)
                    return -1;
                return 0;
            }
            else if (valueType == ValueType.String)
            {
                string xv = (x as Objects.CompareableRow).Comparer.ToString();
                string yv = (y as Objects.CompareableRow).Comparer.ToString();
                return String.CompareOrdinal(xv, yv);
            }
            return 0;
        }

        #endregion
    }
}
