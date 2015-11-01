using System;
using System.Collections.Generic;
using System.Text;

namespace QuickReportCore.Objects
{
    /// <summary>
    /// ���׻��β��
    /// </summary>
    internal class Header : BaseObject
    {
        private string text = string.Empty;
        /// <summary>
        /// ���ݡ�
        /// </summary>
        public string Text
        {
            get
            {
                return text;
            }
            set
            {
                text = value;
            }
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

        private float height = 20f;
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

        private int rowIndex = 0;
        /// <summary>
        /// �кš�
        /// </summary>
        public int RowIndex
        {
            get
            {
                return rowIndex;
            }
            set
            {
                rowIndex = value;
            }
        }

        public Header Clone()
        {
            Header h = new Header();
            h.Color = Color;
            h.Font = Font;
            h.HAligment = HAligment;
            h.VAligment = VAligment;
            h.RowIndex = RowIndex;
            h.Name = Name;
            h.ID = ID;
            h.Height = Height;
            h.Text = Text;
            return h;
        }
    }
}
