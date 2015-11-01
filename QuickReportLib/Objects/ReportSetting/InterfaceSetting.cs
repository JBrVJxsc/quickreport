using System;
using System.Collections.Generic;
using System.Text;

namespace QuickReportLib.Objects.ReportSetting
{
    /// <summary>
    /// 报表接口设置实体。
    /// </summary>
    public class InterfaceSetting
    {
        private List<IDatasAskerImplementor> iDatasAskerImplementorList = new List<IDatasAskerImplementor>();
        private List<ISystemValueImplementor> iSystemValueImplementorList = new List<ISystemValueImplementor>();

        /// <summary>
        /// IDatasAsker实现者实体列表。
        /// </summary>
        public List<IDatasAskerImplementor> IDatasAskerImplementorList
        {
            get
            {
                return iDatasAskerImplementorList;
            }
            set
            {
                iDatasAskerImplementorList = value;
            }
        }

        /// <summary>
        /// ISystemValue实现者实体列表。
        /// </summary>
        public List<ISystemValueImplementor> ISystemValueImplementorList
        {
            get
            {
                return iSystemValueImplementorList;
            }
            set
            {
                iSystemValueImplementorList = value;
            }
        }
    }
}
