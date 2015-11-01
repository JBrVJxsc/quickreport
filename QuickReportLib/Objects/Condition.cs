using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using QuickReportLib.ConditionInputType;

namespace QuickReportLib.Objects
{
    /// <summary>
    /// ������
    /// </summary>
    public class Condition : BaseObject
    {
        private BaseInputType conditionInputType;
        private bool show = false;
        private bool notNull = true;
        private bool showOperator = false;
        private string operatorType = "����";
        private bool showLogicOperator = true;
        private string logicOperator = "��";
        private string value = string.Empty;

        /// <summary>
        /// ������¼�����͡�
        /// </summary>
        public BaseInputType ConditionInputType
        {
            get
            {
                return conditionInputType;
            }
            set
            {
                conditionInputType = value;
            }
        }

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

        /// <summary>
        /// �Ƿ���ʾ��������
        /// </summary>
        public bool ShowOperator
        {
            get
            {
                return showOperator;
            }
            set
            {
                showOperator = value;
            }
        }

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

        /// <summary>
        /// ֵ��
        /// </summary>
        public string Value
        {
            get
            {
                return value;
            }
            set
            {
                this.value = value;
            }
        }

        /// <summary>
        /// �Ƿ���ʾ��������
        /// </summary>
        public bool ShowLogicOperator
        {
            get
            {
                return showLogicOperator;
            }
            set
            {
                showLogicOperator = value;
            }
        }

        /// <summary>
        /// �߼���������
        /// </summary>
        public string LogicOperator
        {
            get
            {
                return logicOperator;
            }
            set
            {
                logicOperator = value;
            }
        }

        public override BaseObject Clone()
        {
            Condition condition = new Condition();
            condition.ID = ID;
            condition.Name = Name;
            condition.SortID = SortID;
            condition.conditionInputType = conditionInputType;
            condition.logicOperator = logicOperator;
            condition.notNull = notNull;
            condition.operatorType = operatorType;
            condition.show = show;
            condition.showLogicOperator = showLogicOperator;
            condition.showOperator = showOperator;
            condition.value = value;
            return condition;
        }
    }
}
