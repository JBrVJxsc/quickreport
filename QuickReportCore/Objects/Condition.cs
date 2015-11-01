using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace QuickReportCore.Objects
{
    /// <summary>
    /// ������
    /// </summary>
    internal class Condition : BaseObject, IComparable
    {
        public Condition()
        {
    
        }

        public Condition(string id,string name)
        {
            ID = id;
            Name = name;
        }
        
        private Objects.ConditionType conditionType = new ConditionType();
        /// <summary>
        /// �������͡�
        /// </summary>
        public Objects.ConditionType ConditionType
        {
            get
            {
                return conditionType;
            }
            set
            {
                conditionType = value;
            }
        }
        private bool use = false;
        /// <summary>
        /// �Ƿ�ʹ�á�
        /// </summary>
        public bool Use
        {
            get
            {
                return use;
            }
            set
            {
                use = value;
            }
        }

        private bool defaultShow = true;
        /// <summary>
        /// �Ƿ�Ĭ����ʾ��
        /// </summary>
        public bool DefaultShow
        {
            get
            {
                return defaultShow;
            }
            set
            {
                defaultShow = value;
            }
        }

        private bool notNull = true;
        /// <summary>
        /// �Ƿ�ǿա�
        /// </summary>
        public bool NotNull
        {
            get
            {
                return notNull;
            }
            set
            {
                notNull = value;
            }
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

        private string operatorType = "����";
        /// <summary>
        /// ��������
        /// </summary>
        public string OperatorType
        {
            get
            {
                return operatorType;
            }
            set
            {
                operatorType = value;
            }
        }

        private string myvalue = string.Empty;
        /// <summary>
        /// ֵ��
        /// </summary>
        public string Value
        {
            get
            {
                return myvalue;
            }
            set
            {
                myvalue = value;
            }
        }

        private string andOr = "��";
        /// <summary>
        /// �һ��ǻ�
        /// </summary>
        public string AndOr
        {
            get
            {
                return andOr;
            }
            set
            {
                andOr = value;
            }
        }

        private System.Xml.XmlElement conditionSetting;
        /// <summary>
        /// ������ϸ���á�
        /// </summary>
        public System.Xml.XmlElement ConditionSetting
        {
            get
            {
                return conditionSetting;
            }
            set
            {
                conditionSetting = value;
            }
        }

        public Condition Clone()
        {
            Condition c = new Condition();
            c.ID = ID;
            c.Name = Name;
            if (ConditionType != null)
                c.ConditionType = ConditionType.Clone();
            c.SortId = SortId;
            c.DefaultShow = DefaultShow;
            c.Use = Use;
            if (ConditionSetting != null)
                c.ConditionSetting = ConditionSetting.Clone() as System.Xml.XmlElement;
            c.NotNull = NotNull;
            c.AndOr = AndOr;
            c.OperatorType = OperatorType;
            c.Value = myvalue;
            return c;
        }

        public override string ToString()
        {
            return Name;
        }

        /// <summary>
        /// �������͡�
        /// </summary>
        public enum InputValueType
        {
            /// <summary>
            /// �ַ���
            /// </summary>
            Text,
            /// <summary>
            /// ���֣�Int����
            /// </summary>
            NumeralInt,
            /// <summary>
            /// ���֣�Decimal����
            /// </summary>
            NumeralDecimal,
            /// <summary>
            /// ���ڡ�
            /// </summary>
            Date,
            /// <summary>
            /// ����ʱ�䡣
            /// </summary>
            DateTime,
            /// <summary>
            /// �Զ���������
            /// </summary>
            CustomComboBox
        }

        #region IComparable ��Ա

        public int CompareTo(object obj)
        {
            Condition c = obj as Condition;
            if (SortId > c.SortId)
                return 1;
            if (SortId < c.SortId)
                return -1;
            return 0;
        }

        #endregion
    }
}
