using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace QuickReportCore.Objects
{
    /// <summary>
    /// 条件。
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
        /// 条件类型。
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
        /// 是否使用。
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
        /// 是否默认显示。
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
        /// 是否非空。
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
        /// 排列序号。
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

        private string operatorType = "等于";
        /// <summary>
        /// 操作符。
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
        /// 值。
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

        private string andOr = "且";
        /// <summary>
        /// 且还是或。
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
        /// 条件详细设置。
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
        /// 数据类型。
        /// </summary>
        public enum InputValueType
        {
            /// <summary>
            /// 字符。
            /// </summary>
            Text,
            /// <summary>
            /// 数字（Int）。
            /// </summary>
            NumeralInt,
            /// <summary>
            /// 数字（Decimal）。
            /// </summary>
            NumeralDecimal,
            /// <summary>
            /// 日期。
            /// </summary>
            Date,
            /// <summary>
            /// 日期时间。
            /// </summary>
            DateTime,
            /// <summary>
            /// 自定义下拉框。
            /// </summary>
            CustomComboBox
        }

        #region IComparable 成员

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
