using System;
using System.Collections.Generic;
using System.Text;
using QuickReportLib.ConditionInputType;

namespace QuickReportLib.Objects.ConditionInputTypeSetting
{
    /// <summary>
    /// ComboBox��¼����������ʵ�塣
    /// </summary>
    public class ComboBoxSetting : BaseInputTypeSetting
    {
        private string defaultValue = string.Empty;
        private bool canEdit = false;
        private string sql = string.Empty;

        /// <summary>
        /// Ĭ��ֵ��
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
        /// �Ƿ�����༭������
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
        /// SQL��䡣
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
