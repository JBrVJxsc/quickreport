using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Drawing;
using FarPoint.Win.Spread;
using QuickReportLib.Enums;

namespace QuickReportLib.Objects
{
    /// <summary>
    /// �С�
    /// </summary>
    public class Column : BaseObject 
    {
        private bool show = true;
        private bool columnTotalSum = false;
        private bool rowTotalSum = false;
        private bool sort = false;
        private bool filter = false;
        private float width = 90;
        private bool isNumber = false;
        private int decimalPlace = 2;
        private string groupName = string.Empty;
        private int groupIndex = 0;
        private Font font = new Font("����", 9, FontStyle.Regular);
        private Color color =System.Drawing.Color.Black;
        private CellHorizontalAlignment hAligment = CellHorizontalAlignment.Center;
        private CellVerticalAlignment vAligment = CellVerticalAlignment.Center;
        private Font headerFont = new Font("����", 9, FontStyle.Regular);
        private Color headerColor = System.Drawing.Color.Black;
        private CellHorizontalAlignment headerHAligment = CellHorizontalAlignment.Center;
        private CellVerticalAlignment headerVAligment = CellVerticalAlignment.Center;
        private bool merge = false;
        private ValueTranslateType valueTranslateType = ValueTranslateType.DoNothing;
        private static FontConverter fontConverter = new FontConverter();
        private Type dataType;

        /// <summary>
        /// �Ƿ���ʾ��
        /// </summary>
        public bool Show
        {
            get
            {
                return show;
            }
            set
            {
                show = value;
            }
        }

        /// <summary>
        /// �Ƿ�����кϼơ�
        /// </summary>
        public bool ColumnTotalSum
        {
            get
            {
                return columnTotalSum;
            }
            set
            {
                columnTotalSum = value;
            }
        }

        /// <summary>
        /// �Ƿ�����кϼơ�
        /// </summary>
        public bool RowTotalSum
        {
            get
            {
                return rowTotalSum;
            }
            set
            {
                rowTotalSum = value;
            }
        }

        /// <summary>
        /// �Ƿ�����
        /// </summary>
        public bool Sort
        {
            get
            {
                return sort;
            }
            set
            {
                sort = value;
            }
        }

        /// <summary>
        /// �Ƿ���ˡ�
        /// </summary>
        public bool Filter
        {
            get
            {
                return filter;
            }
            set
            {
                filter = value;
            }
        }

        /// <summary>
        /// �п�
        /// </summary>
        public float Width
        {
            get
            {
                return width;
            }
            set
            {
                width = value;
            }
        }

        /// <summary>
        /// �Ƿ��������͵ġ�
        /// </summary>
        public bool IsNumber
        {
            get
            {
                return isNumber;
            }
            set
            {
                isNumber = value;
            }
        }

        /// <summary>
        /// ����С����λ����
        /// </summary>
        public int DecimalPlace
        {
            get
            {
                return decimalPlace;
            }
            set
            {
                decimalPlace = value;
            }
        }

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

        /// <summary>
        /// �������塣
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
                font =fontConverter.ConvertFromInvariantString(value) as Font;
            }
        }

        /// <summary>
        /// ������ɫ��
        /// </summary>
        public string Color
        {
            get
            {
                string colorString=ColorTranslator.ToHtml(color);
                return colorString;
            }
            set
            {
                color = ColorTranslator.FromHtml(value);
            }
        }

        /// <summary>
        /// ���ݺ�����뷽ʽ��
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
        /// ����������뷽ʽ��
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
        /// ��ͷ���塣
        /// </summary>
        public string HeaderFont
        {
            get
            {
                string fontString = fontConverter.ConvertToInvariantString(headerFont);
                return fontString;
            }
            set
            {
                headerFont = fontConverter.ConvertFromInvariantString(value) as Font;
            }
        }

        /// <summary>
        /// ��ͷ��ɫ��
        /// </summary>
        public string HeaderColor
        {
            get
            {
                string colorString = ColorTranslator.ToHtml(headerColor);
                return colorString;
            }
            set
            {
                headerColor = ColorTranslator.FromHtml(value);
            }
        }

        /// <summary>
        /// ��ͷ������뷽ʽ��
        /// </summary>
        public CellHorizontalAlignment HeaderHAligment
        {
            get
            {
                return headerHAligment;
            }
            set
            {
                headerHAligment = value;
            }
        }

        /// <summary>
        /// ��ͷ������뷽ʽ��
        /// </summary>
        public CellVerticalAlignment HeaderVAligment
        {
            get
            {
                return headerVAligment;
            }
            set
            {
                headerVAligment = value;
            }
        }

        /// <summary>
        /// �Ƿ�ϲ�ͬ���
        /// </summary>
        public bool Merge
        {
            get
            {
                return merge;
            }
            set
            {
                merge = value;
            }
        }

        /// <summary>
        /// ֵ��ת����ʽ��
        /// </summary>
        public ValueTranslateType ValueTranslateType
        {
            get
            {
                return valueTranslateType;
            }
            set
            {
                valueTranslateType = value ;
            }
        }

        /// <summary>
        /// �������͡�
        /// </summary>
        public string DataType
        {
            get
            {
                return dataType.FullName;
            }
            set
            {
                dataType = Type.GetType(value);
            }
        }

        /// <summary>
        /// ��ȡ���ݵ����塣
        /// </summary>
        /// <returns>���塣</returns>
        public Font GetFont()
        {
            return font;
        }

        /// <summary>
        /// ��ȡ���ݵ���ɫ��
        /// </summary>
        /// <returns>��ɫ��</returns>
        public Color GetColor()
        {
            return color;
        }

        /// <summary>
        /// ��ȡ��ͷ�����塣
        /// </summary>
        /// <returns>���塣</returns>
        public Font GetHeaderFont()
        {
            return headerFont;
        }

        /// <summary>
        /// ��ȡ��ͷ����ɫ��
        /// </summary>
        /// <returns>��ɫ��</returns>
        public Color GetHeaderColor()
        {
            return headerColor;
        }

        /// <summary>
        /// ��ȡ�е��������͡�
        /// </summary>
        /// <returns>�������͡�</returns>
        public Type GetDataType()
        {
            return dataType;
        }

        /// <summary>
        /// �������ݵ����塣
        /// </summary>
        /// <param name="font">���塣</param>
        public void SetFont(Font font)
        {
            this.font = font;
        }

        /// <summary>
        /// �������ݵ���ɫ��
        /// </summary>
        /// <param name="color">��ɫ��</param>
        public void SetColor(Color color)
        {
            this.color = color;
        }

        /// <summary>
        /// ������ͷ�����塣
        /// </summary>
        /// <param name="font">���塣</param>
        public void SetHeaderFont(Font font)
        {
            headerFont = font;
        }

        /// <summary>
        /// ������ͷ����ɫ��
        /// </summary>
        /// <param name="color">��ɫ��</param>
        public void SetHeaderColor(Color color)
        {
            headerColor = color;
        }

        /// <summary>
        /// �����е��������͡�
        /// </summary>
        /// <param name="type">�������͡�</param>
        public void SetDataType(Type dataType)
        {
            this.dataType = dataType;
        }

        public override BaseObject Clone()
        {
            Column column = new Column();
            column.ID = ID;
            column.Name = Name;
            column.SortID = SortID;
            column.show = show;
            column.columnTotalSum = columnTotalSum;
            column.rowTotalSum = rowTotalSum;
            column.sort = sort;
            column.filter = filter;
            column.width = width;
            column.isNumber = isNumber;
            column.decimalPlace = decimalPlace;
            column.groupName = groupName;
            column.groupIndex = groupIndex;
            column.font = font;
            column.color = color;
            column.hAligment = hAligment;
            column.vAligment = vAligment;
            column.headerFont = headerFont;
            column.headerColor = headerColor;
            column.headerHAligment = headerHAligment;
            column.headerVAligment = headerVAligment;
            column.merge = merge;
            column.valueTranslateType = valueTranslateType;
            column.dataType = dataType;
            return column;
        }
    }
}
