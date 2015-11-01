using System;
using System.Collections.Generic;
using System.Text;

namespace QuickReportCore.Objects.Setting
{
    /// <summary>
    /// 数据接口设置。
    /// </summary>
    internal class InterfacesSetting
    {
        private Controls.ucReportInterfaceOtherSetting.INeedDatasActionType iNeedDatasActionType = QuickReportCore.Controls.ucReportInterfaceOtherSetting.INeedDatasActionType.双击激活接口;
        internal Controls.ucReportInterfaceOtherSetting.INeedDatasActionType INeedDatasActionType
        {
            get
            {
                return iNeedDatasActionType;
            }
            set
            {
                iNeedDatasActionType = value;
            }
        }

        private List<Objects.Interface> interfaceList = new List<Interface>();
        public List<Objects.Interface> InterfaceList
        {
            get
            {
                return interfaceList;
            }
            set
            {
                interfaceList = value;
            }
        }

        /// <summary>
        /// 根据接口类型获得数据接口的实例。
        /// </summary>
        /// <param name="interfaceType">接口类型。</param>
        /// <returns>数据接口的实例。</returns>
        public object GetInstance(Type interfaceType)
        { 
            foreach(Objects.Interface  i in InterfaceList)
            {
                if (i.InterfaceName == interfaceType.Name)
                    return i.Instance;
            }
            return null;
        }
    }
}
