using System;
using System.Collections.Generic;
using System.Text;

namespace QuickReportCore.Objects.Setting
{
    internal class DetailSetting
    {
        private string sql = string.Empty;
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

        private QuickReportCore.Forms.frmQuickReportEditor.QueryActionType actionType = QuickReportCore.Forms.frmQuickReportEditor.QueryActionType.���������ѯ;
        /// <summary>
        /// �������͡�
        /// </summary>
        internal QuickReportCore.Forms.frmQuickReportEditor.QueryActionType ActionType
        {
            get
            {
                return actionType;
            }
            set
            {
                actionType = value;
            }
        }
    }
}
