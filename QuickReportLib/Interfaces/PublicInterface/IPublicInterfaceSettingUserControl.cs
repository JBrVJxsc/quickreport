using System;
using System.Collections.Generic;
using System.Text;
using QuickReportLib.Objects.ReportSetting;
using QuickReportLib.Interfaces.GlobalValue;
using QuickReportLib.Enums;
using QuickReportLib.Interfaces.ReportSetting;

namespace QuickReportLib.Interfaces.PublicInterface
{
    /// <summary>
    /// 向外界公开的接口设置界面，需实现此接口。
    /// </summary>
    internal interface IPublicInterfaceSettingUserControl : IGlobalValueProvider, IChangedUserControl
    {
        /// <summary>
        /// 为何种接口服务。
        /// </summary>
        Type InterfaceType
        {
            get;
        }

        /// <summary>
        /// 接口设置实体。
        /// </summary>
        InterfaceSetting InterfaceSetting
        {
            get;
            set;
        }

        /// <summary>
        /// 新增。
        /// </summary>
        void Add();

        /// <summary>
        /// 删除。
        /// </summary>
        void Delete();

        /// <summary>
        /// 向上移动。
        /// </summary>
        void Up();

        /// <summary>
        /// 向下移动。
        /// </summary>
        void Down();

        /// <summary>
        /// 检查录入。
        /// </summary>
        /// <returns>1为成功；-1为失败。</returns>
        int CheckInput();

        /// <summary>
        /// 获取所需要的工具栏工具种类。
        /// </summary>
        /// <returns>工具种类。</returns>
        List<InterfaceSettingToolStripButtonType> GetNeededToolStripButtons();

        /// <summary>
        /// 通知已经加载完毕。
        /// </summary>
        void Loaded();
    }
}
