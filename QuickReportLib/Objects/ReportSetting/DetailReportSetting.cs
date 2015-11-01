using System;
using System.Collections.Generic;
using System.Text;

namespace QuickReportLib.Objects.ReportSetting
{
    /// <summary>
    /// 明细报表设置实体。
    /// </summary>
    public class DetailReportSetting
    {
        private string id = string.Empty;
        private bool enableInterface = false;
        private List<DetailReportConditionCompare> conditionCompareList = new List<DetailReportConditionCompare>();

        /// <summary>
        /// 明细报表所指向的报表ID。
        /// </summary>
        public string ID
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        /// <summary>
        /// 是否允许执行明细报表的接口。
        /// </summary>
        public bool EnableInterface
        {
            get
            {
                return enableInterface;
            }
            set
            {
                enableInterface = value;
            }
        }

        /// <summary>
        /// 明细报表条件对照列表。
        /// </summary>
        public List<DetailReportConditionCompare> ConditionCompareList
        {
            get
            {
                return conditionCompareList;
            }
            set
            {
                conditionCompareList = value;
            }
        }
    }
}
