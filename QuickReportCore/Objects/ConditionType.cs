using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace QuickReportCore.Objects
{
    /// <summary>
    /// 条件类别。
    /// </summary>
    internal class ConditionType : BaseObject
    {
        
        public ConditionType()
        { 
            
        }

        public ConditionType(string id,string name)
        {
            ID = id;
            Name = name;
        }

        private System.Xml.XmlElement content;
        /// <summary>
        /// 内容。
        /// </summary>
        public System.Xml.XmlElement Content
        {
            get
            {
                return content;
            }
            set
            {
                content = value;
            }
        }

        private string isvalid = "1";
        /// <summary>
        /// 是否有效。
        /// </summary>
        public string IsValid
        {
            get
            {
                return isvalid;
            }
            set
            {
                isvalid = value;
            }
        }

        public override string ToString()
        {
            return Name;
        }

        public ConditionType Clone()
        {
            ConditionType c = new ConditionType();
            c.ID = ID;
            c.Name = Name;
            c.Content = Content;
            return c;
        }

        /// <summary>
        /// 系统默认的条件类型。
        /// </summary>
        public static List<ConditionType> SystemConditionTypes = new List<ConditionType>();
        static ConditionType()
        {
            SystemConditionTypes.Add(new ConditionType(Condition.InputValueType.Text.ToString(), "字符"));
            SystemConditionTypes.Add(new ConditionType(Condition.InputValueType.NumeralInt.ToString(), "数字（Int）"));
            SystemConditionTypes.Add(new ConditionType(Condition.InputValueType.NumeralDecimal.ToString(), "数字（Decimal）"));
            SystemConditionTypes.Add(new ConditionType(Condition.InputValueType.Date.ToString(), "日期"));
            SystemConditionTypes.Add(new ConditionType(Condition.InputValueType.DateTime.ToString(), "日期时间"));
            SystemConditionTypes.Add(new ConditionType(Condition.InputValueType.CustomComboBox.ToString(), "自定义"));

            DataTypeCompareToConditionType.Add(typeof(System.String), new ConditionType(Condition.InputValueType.Text.ToString(), "字符"));
            DataTypeCompareToConditionType.Add(typeof(System.Int32), new ConditionType(Condition.InputValueType.NumeralInt.ToString(), "数字（Int）"));
            DataTypeCompareToConditionType.Add(typeof(System.Decimal), new ConditionType(Condition.InputValueType.NumeralDecimal.ToString(), "数字（Decimal）"));
            DataTypeCompareToConditionType.Add(typeof(System.DateTime), new ConditionType(Condition.InputValueType.DateTime.ToString(), "日期时间"));
        }

        public static Hashtable DataTypeCompareToConditionType = new Hashtable();
    }
}
