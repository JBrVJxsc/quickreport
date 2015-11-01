using System;
using System.Collections.Generic;
using System.Text;
using QuickReportLib.ConditionInputType;

namespace QuickReportLib.Objects.ConditionInputTypeSetting
{
    /// <summary>
    /// ComboBox型录入类型设置实体。
    /// </summary>
    public class ComboBoxSetting : BaseInputTypeSetting
    {
        private string defaultValue = string.Empty;
        private bool canEdit = false;
        private string sql = string.Empty;

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
        /// 是否允许编辑下拉框。
        /// </summary>
        public bool CanEdit
        {
            get
            {
                return canEdit;
            }
            set
            {
                canEdit = value;
            }
        }

        /// <summary>
        /// SQL语句。
        /// </summary>
        public string SQL
        {
            get
            {
                return sql;
            }
            set
            {
                sql = value;
            }
        }
    }
}
