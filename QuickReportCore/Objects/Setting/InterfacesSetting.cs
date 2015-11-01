using System;
using System.Collections.Generic;
using System.Text;

namespace QuickReportCore.Objects.Setting
{
    /// <summary>
    /// ���ݽӿ����á�
    /// </summary>
    internal class InterfacesSetting
    {
        private Controls.ucReportInterfaceOtherSetting.INeedDatasActionType iNeedDatasActionType = QuickReportCore.Controls.ucReportInterfaceOtherSetting.INeedDatasActionType.˫������ӿ�;
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
        /// ���ݽӿ����ͻ�����ݽӿڵ�ʵ����
        /// </summary>
        /// <param name="interfaceType">�ӿ����͡�</param>
        /// <returns>���ݽӿڵ�ʵ����</returns>
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
