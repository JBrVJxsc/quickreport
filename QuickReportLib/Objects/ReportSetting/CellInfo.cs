using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using FarPoint.Win.Spread;
using FarPoint.Win;

namespace QuickReportLib.Objects.ReportSetting
{
    /// <summary>
    /// Cell��Ϣ��
    /// </summary>
    public class CellInfo
    {
        private int row = 0;
        private int column = 0;
        private int rowSpan = 1;
        private int columnSpan = 1;
        private string text = string.Empty;
        private Font font = new Font("����", 9, FontStyle.Regular);
        private Color color = System.Drawing.Color.Black;
        private CellHorizontalAlignment hAligment = CellHorizontalAlignment.General;
        private CellVerticalAlignment vAligment = CellVerticalAlignment.General;
        private CellBorder cellBorder = new CellBorder();
        private static FontConverter fontConverter = new FontConverter();

        /// <summary>
        /// ����š�
        /// </summary>
        public int Row
        {
            get
            {
                return row;
            }
            set
            {
                row = value;
            }
        }

        /// <summary>
        /// ����š�
        /// </summary>
        public int Column
        {
            get
            {
                return column;
            }
            set
            {
                column = value;
            }
        }

        /// <summary>
        /// �кϲ�����
        /// </summary>
        public int RowSpan
        {
            get
            {
                return rowSpan;
            }
            set
            {
                rowSpan = value;
            }
        }

        /// <summary>
        /// �кϲ�����
        /// </summary>
        public int ColumnSpan
        {
            get
            {
                return columnSpan;
            }
            set
            {
                columnSpan = value;
            }
        }

        /// <summary>
        /// Cell�ϵ��ַ���
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

        /// <summary>
        /// ���塣
        /// </summary>
        public string Font
        {
            get
            {
                string fontString = fontConverter.ConvertToInvariantString(font);
                return fontString;
            }
            set
            {
                font = fontConverter.ConvertFromInvariantString(value) as Font;
            }
        }

        /// <summary>
        /// ��ɫ��
        /// </summary>
        public string Color
        {
            get
            {
                string colorString = ColorTranslator.ToHtml(color);
                return colorString;
            }
            set
            {
                color = ColorTranslator.FromHtml(value);
            }
        }

        /// <summary>
        /// ��ȡCell�����塣
        /// </summary>
        /// <returns>���塣</returns>
        public Font GetFont()
        {
            return font;
        }

        /// <summary>
        /// ��ȡCell����ɫ��
        /// </summary>
        /// <returns>��ɫ��</returns>
        public Color GetColor()
        {
            return color;
        }

        /// <summary>
        /// ����Cell�����塣
        /// </summary>
        /// <param name="font">���塣</param>
        public void SetFont(Font font)
        {
            if (font != null)
            {
                this.font = font;
            }
        }

        /// <summary>
        /// ����Cell����ɫ��
        /// </summary>
        /// <param name="color">��ɫ</param>
        public void SetColor(Color color)
        {
            if (color != null)
            {
                this.color = color;
            }
        }

        /// <summary>
        /// ������뷽ʽ��
        /// </summary>
        public CellHorizontalAlignment HAligment
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

        /// <summary>
        /// ������뷽ʽ��
        /// </summary>
        public CellVerticalAlignment VAligment
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

        /// <summary>
        /// Cell�ı߿�
        /// </summary>
        public CellBorder CellBorder
        {
            get
            {
                return cellBorder;
            }
            set
            {
                cellBorder = value;
            }
        }

        /// <summary>
        /// ��Cell����Ϣ���CellInfo��
        /// </summary>
        /// <param name="cell">Cell����Ϣ��</param>
        public void SetCellInfo(Cell cell)
        {
            row = cell.Row.Index;
            column = cell.Column.Index;
            rowSpan = cell.RowSpan;
            columnSpan = cell.ColumnSpan;
            SetColor(cell.ForeColor);
            SetFont(cell.Font);
            cellBorder.SetCellBorder(cell.Border as LineBorder);
            hAligment = cell.HorizontalAlignment;
            vAligment = cell.VerticalAlignment;
            if (cell.Value != null)
            {
                text = cell.Value.ToString();
            }
        }
    }
}
