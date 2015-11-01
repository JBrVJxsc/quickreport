using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using QuickReportLib.ConditionInputType;

namespace QuickReportLib.Objects
{
    /// <summary>
    /// 条件。
    /// </summary>
    public class Condition : BaseObject
    {
        private BaseInputType conditionInputType;
        private bool show = false;
        private bool notNull = true;
        private bool showOperator = false;
        private string operatorType = "等于";
        private bool showLogicOperator = true;
        private string logicOperator = "且";
        private string value = string.Empty;

        /// <summary>
        /// 条件的录入类型。
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
        /// 是否显示。
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

        /// <summary>
        /// 是否显示操作符。
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

        /// <summary>
        /// 值。
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
        /// 是否显示操作符。
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
        /// 逻辑操作符。
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
