using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace QuickReportCore.Objects
{
    /// <summary>
    /// �������
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
        /// ���ݡ�
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
        /// �Ƿ���Ч��
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
        /// ϵͳĬ�ϵ��������͡�
        /// </summary>
        public static List<ConditionType> SystemConditionTypes = new List<ConditionType>();
        static ConditionType()
        {
            SystemConditionTypes.Add(new ConditionType(Condition.InputValueType.Text.ToString(), "�ַ�"));
            SystemConditionTypes.Add(new ConditionType(Condition.InputValueType.NumeralInt.ToString(), "���֣�Int��"));
            SystemConditionTypes.Add(new ConditionType(Condition.InputValueType.NumeralDecimal.ToString(), "���֣�Decimal��"));
            SystemConditionTypes.Add(new ConditionType(Condition.InputValueType.Date.ToString(), "����"));
            SystemConditionTypes.Add(new ConditionType(Condition.InputValueType.DateTime.ToString(), "����ʱ��"));
            SystemConditionTypes.Add(new ConditionType(Condition.InputValueType.CustomComboBox.ToString(), "�Զ���"));

            DataTypeCompareToConditionType.Add(typeof(System.String), new ConditionType(Condition.InputValueType.Text.ToString(), "�ַ�"));
            DataTypeCompareToConditionType.Add(typeof(System.Int32), new ConditionType(Condition.InputValueType.NumeralInt.ToString(), "���֣�Int��"));
            DataTypeCompareToConditionType.Add(typeof(System.Decimal), new ConditionType(Condition.InputValueType.NumeralDecimal.ToString(), "���֣�Decimal��"));
            DataTypeCompareToConditionType.Add(typeof(System.DateTime), new ConditionType(Condition.InputValueType.DateTime.ToString(), "����ʱ��"));
        }

        public static Hashtable DataTypeCompareToConditionType = new Hashtable();
    }
}
