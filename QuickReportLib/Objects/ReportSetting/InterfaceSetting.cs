using System;
using System.Collections.Generic;
using System.Text;

namespace QuickReportLib.Objects.ReportSetting
{
    /// <summary>
    /// ����ӿ�����ʵ�塣
    /// </summary>
    public class InterfaceSetting
    {
        private List<IDatasAskerImplementor> iDatasAskerImplementorList = new List<IDatasAskerImplementor>();
        private List<ISystemValueImplementor> iSystemValueImplementorList = new List<ISystemValueImplementor>();

        /// <summary>
        /// IDatasAskerʵ����ʵ���б�
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
        /// ISystemValueʵ����ʵ���б�
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
