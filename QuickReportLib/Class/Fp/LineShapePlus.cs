using System;
using System.Collections.Generic;
using System.Text;
using FarPoint.Win.Spread.DrawingSpace;

namespace QuickReportLib.Class.Fp
{
    internal class LineShapePlus : LineShape
    {
        private static int lineShapeName = 0;

        public LineShapePlus()
        {
            Name = GetName();
            CanPrint = true;
            Locked = true;
        }

        private string GetName()
        {
            lineShapeName++;
            return lineShapeName.ToString();
        }
    }
}
