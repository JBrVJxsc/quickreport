using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace QuickReportCore.Objects
{
    /// <summary>
    /// �С�
    /// </summary>
    internal class Row : BaseObject, IComparable
    {
        public Row()
        { 
            
        }

        public Row(string name)
        {
            Name = name;
        }

        private int sortId = 0;
        /// <summary>
        /// ������š�
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

        private float height = 25;
        /// <summary>
        /// �иߡ�
        /// </summary>
        public float Height
        {
            get
            {
                return height;
            }
            set
            {
                height = value;
            }
        }

        private string groupName = string.Empty;
        /// <summary>
        /// �������ơ�
        /// </summary>
        public string GroupName
        {
            get
            {
                return groupName;
            }
            set
            {
                groupName = value;
            }
        }

        private int groupIndex = 0;
        /// <summary>
        /// ������š�
        /// </summary>
        public int GroupIndex
        {
            get
            {
                return groupIndex;
            }
            set
            {
                groupIndex = value;
            }
        }

        public override string ToString()
        {
            return Name;
        }

        private System.Drawing.Font font;
        /// <summary>
        /// ���塣
        /// </summary>
        public System.Drawing.Font Font
        {
            get
            {
                return font;
            }
            set
            {
                font = value;
            }
        }
        private System.Drawing.Color color;
        public System.Drawing.Color Color
        {
            get
            {
                return color;
            }
            set
            {
                color = value;
            }
        }

        private FarPoint.Win.Spread.CellHorizontalAlignment hAligment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
        /// <summary>
        /// ������뷽ʽ��
        /// </summary>
        public FarPoint.Win.Spread.CellHorizontalAlignment HAligment
        {
            get
            {
                return hAligment;
            }
            set
            {
                hAligment = value;
            }
        }

        private FarPoint.Win.Spread.CellVerticalAlignment vAligment = FarPoint.Win.Spread.CellVerticalAlignment.General;
        /// <summary>
        /// ������뷽ʽ��
        /// </summary>
        public FarPoint.Win.Spread.CellVerticalAlignment VAligment
        {
            get
            {
                return vAligment;
            }
            set
            {
                vAligment = value;
            }
        }

        public Row Clone()
        {
            Row r = new Row();
            r.ID = ID;
            r.Name = Name;
            r.SortId = SortId;
            r.Height = Height;
            r.GroupName = GroupName;
            r.GroupIndex = GroupIndex;
            r.Font = Font;
            r.Color = Color;
            r.HAligment = HAligment;
            r.VAligment = VAligment;
            return r;
        }

        #region IComparable ��Ա

        public int CompareTo(object obj)
        {
            Row r = obj as Row;
            if (SortId > r.SortId)
                return 1;
            if (SortId < r.SortId)
                return -1;
            return 0;
        }

        #endregion
    }
}
