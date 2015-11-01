using System;
using System.Collections.Generic;
using System.Text;
using QuickReportLib.ConditionInputType;

namespace QuickReportLib.Objects.ConditionInputTypeSetting
{
    /// <summary>
    /// 文本框类型设置实体。
    /// </summary>
    public class TextBoxSetting : BaseInputTypeSetting
    {
        private string defaultValue = string.Empty;
        private bool onlyNumber = false;
        private bool leftZero = false;
        private int leftZeroPlace = 10;
        private bool userSelector = false;
        private string selectorSQL = string.Empty;
        private string outPutColumn = string.Empty;
        private bool hideOutPutColumn = true;
        private string selectorTitle = "请选择一条记录";
        private string selectorNullMessage = "未查找到有效记录。";

        /// <summary>
        /// 默认值。
        /// </summary>
        public string DefaultValue
        {
            get
            {
                return defaultValue;
            }
            set
            {
                defaultValue = value;
            }
        }

        /// <summary>
        /// 是否限制为数字。
        /// </summary>
        public bool OnlyNumber
        {
            get
            {
                return onlyNumber;
            }
            set
            {
                onlyNumber = value;
            }
        }

        /// <summary>
        /// 是否左补零。
        /// </summary>
        public bool LeftZero
        {
            get
            {
                return leftZero;
            }
            set
            {
                leftZero = value;
            }
        }

        /// <summary>
        /// 左补零位数。
        /// </summary>
        public int LeftZeroPlace
        {
            get
            {
                return leftZeroPlace;
            }
            set
            {
                leftZeroPlace = value;
            }
        }

        /// <summary>
        /// 是否使用选择框。
        /// </summary>
        public bool UserSelector
        {
            get
            {
                return userSelector;
            }
            set
            {
                userSelector = value;
            }
        }

        /// <summary>
        /// 选择框的SQL。
        /// </summary>
        public string SelectorSQL
        {
            get
            {
                return selectorSQL;
            }
            set
            {
                selectorSQL = value;
            }
        }

        /// <summary>
        /// 输入列。
        /// </summary>
        public string OutPutColumn
        {
            get
            {
                return outPutColumn;
            }
            set
            {
                outPutColumn = value;
            }
        }

        /// <summary>
        /// 是否隐藏输出列。
        /// </summary>
        public bool HideOutPutColumn
        {
            get
            {
                return hideOutPutColumn;
            }
            set
            {
                hideOutPutColumn = value;
            }
        }

        /// <summary>
        /// 选择框标题。
        /// </summary>
        public string SelectorTitle
        {
            get
            {
                return selectorTitle;
            }
            set
            {
                selectorTitle = value;
            }
        }

        /// <summary>
        /// 当未找到值时显示的信息。
        /// </summary>
        public string SelectorNullMessage
        {
            get
            {
                return selectorNullMessage;
            }
            set
            {
                selectorNullMessage = value;
            }
        }
    }
}
