using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using FarPoint.Win.Spread;
using QuickReportLib.Interfaces;
using QuickReportLib.Interfaces.GlobalValue;
using QuickReportLib.Interfaces.ReportSetting;
using QuickReportLib.Objects;
using QuickReportLib.Enums;
using QuickReportLib.Managers;

namespace QuickReportLib.Controls.ReportSetting
{
    /// <summary>
    /// 报表设置平台。
    /// </summary>
    internal partial class ReportSettingPlatForm : BaseUserControl, IGlobalValueProvider, IGlobalValueToolStripItemAsker, IToolStripMenuProvider, IShowStatusStripHelp, IBringToFront
    {
        public ReportSettingPlatForm(Report report)
        {
            InitializeComponent();
            this.report = report;
        }

        private Report report;
        private DataBaseManager dataBaseManager = new DataBaseManager();
        /// <summary>
        /// 存储需要保存时检查录入的ICheckInput。
        /// </summary>
        private List<ICheckInput> iCheckInputList = new List<ICheckInput>();
        private List<IGlobalValueAsker> iGlobalValueAskerList = new List<IGlobalValueAsker>();
        private List<ILoadedListener> iLoadedListenerList = new List<ILoadedListener>();
        private List<IReportSettingUserControl> iReportSettingUserControlList = new List<IReportSettingUserControl>();

        /// <summary>
        /// 当报表设置界面中的值发生改变后，所触发的事件。
        /// </summary>
        internal event EventHandler Changed;

        /// <summary>
        /// 添加各种设置界面。
        /// </summary>
        private void Init()
        {
            //初始化报表表头设计界面。
            headerSetting.Init(report);
            //初始化报表其他属性设置界面。
            reportSettingTabControl.Init(report);
        }

        /// <summary>
        /// 检查界面录入情况。
        /// </summary>
        /// <returns></returns>
        public int CheckInput()
        {
            foreach (ICheckInput iCheckInput in iCheckInputList)
            {
                int i = iCheckInput.CheckInput();
                if (i < 0)
                {
                    return -1;
                }
            }
            return 1;
        }

        /// <summary>
        /// 保存报表。
        /// </summary>
        /// <returns>1成功；-1失败。</returns>
        public int Save()
        {
            int i;
            foreach (IReportSettingUserControl iReportSettingUserControl in iReportSettingUserControlList)
            {
                i = iReportSettingUserControl.Save();
                if (i == -1)
                {
                    return -1;
                }
            }
            i = headerSetting.Save();
            if (i == -1)
            {
                return -1;
            }
            #region 保存到数据库。
            Report reportTemp = dataBaseManager.QueryReportByID(report.ID);
            if (reportTemp == null)
            {
                dataBaseManager.InsertQuickReport(report);
            }
            else
            {
                dataBaseManager.UpdateQuickReport(report);
            }
            #endregion
            return 1;
        }

        /// <summary>
        /// 递归调用，过滤实现各种接口的控件并实现各接口的功能以及为基础控件设置值改变事件。
        /// </summary>
        /// <param name="controls">控件列表。</param>
        private void FilterControl(ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                if (control is TextBox)
                {
                    (control as TextBox).TextChanged += new EventHandler(control_Changed);
                }
                else if (control is ComboBox)
                {
                    (control as ComboBox).SelectedIndexChanged += new EventHandler(control_Changed);
                    (control as ComboBox).TextChanged += new EventHandler(control_Changed);
                }
                else if (control is CheckBox)
                {
                    (control as CheckBox).CheckedChanged += new EventHandler(control_Changed);
                }
                else if (control is RadioButton)
                {
                    (control as RadioButton).CheckedChanged += new EventHandler(control_Changed);
                }
                else if (control is DateTimePicker)
                {
                    (control as DateTimePicker).ValueChanged += new EventHandler(control_Changed);
                }
                else if (control is NumericUpDown)
                {
                    (control as NumericUpDown).ValueChanged += new EventHandler(control_Changed);
                }
                else if (control is FpSpread)
                {
                    (control as FpSpread).EditChange += new EditorNotifyEventHandler(control_Changed);
                    (control as FpSpread).FontChanged += new EventHandler(control_Changed);
                    (control as FpSpread).ColumnWidthChanged += new FarPoint.Win.Spread.ColumnWidthChangedEventHandler(control_Changed);
                    (control as FpSpread).RowHeightChanged += new RowHeightChangedEventHandler(control_Changed);
                    (control as FpSpread).ClipboardPasting += new ClipboardPastingEventHandler(control_Changed);
                }

                if (control is IChangedUserControl)
                {
                    (control as IChangedUserControl).Changed += new EventHandler(control_Changed);
                }

                if (control is ICheckInput)
                {
                    iCheckInputList.Add(control as ICheckInput);
                }

                if (control is IGlobalValueAsker)
                {
                    iGlobalValueAskerList.Add(control as IGlobalValueAsker);
                }

                if (control is IGlobalValueProvider)
                {
                    (control as IGlobalValueProvider).GlobalValueChanged += new GlobalValueChangedHandle(ReportSettingPlatForm_GloalValueChanged);
                }

                if (control is IGlobalValueToolStripItemAsker)
                {
                    (control as IGlobalValueToolStripItemAsker).AskForGlobalValueToolStripItem += AskForGlobalValueToolStripItem;
                }

                if (control is IToolStripMenuProvider)
                {
                    (control as IToolStripMenuProvider).ProvideToolStripMenu += ProvideToolStripMenu;
                }

                if (control is IShowStatusStripHelp)
                {
                    (control as IShowStatusStripHelp).ShowStatusStripHelp += ShowStatusStripHelp;
                }

                if (control is IBringToFront)
                {
                    (control as IBringToFront).AskForBringToFront += AskForBringToFront;
                }

                if (control is ILoadedListener)
                {
                    iLoadedListenerList.Add(control as ILoadedListener);
                }

                if (control is IReportSettingUserControl)
                {
                    iReportSettingUserControlList.Add(control as IReportSettingUserControl);
                }

                if (control.Controls.Count > 0)
                {
                    FilterControl(control.Controls);
                }
            }
        }

        void ReportSettingPlatForm_GloalValueChanged(object sender, IGlobalValue globalValue)
        {
            if (GlobalValueChanged != null)
            {
                GlobalValueChanged(sender, globalValue);
            }
            #region 不能由ReportTabControl来做全局变量调控工作，是因为对于单一报表，ReportSettingPlatForm最高等级的设计界面。
            foreach (IGlobalValueAsker iGlobalValueAsker in iGlobalValueAskerList)
            {
                if (iGlobalValueAsker.GlobalValueTypes.Contains(globalValue.GlobalValueType))
                {
                    iGlobalValueAsker.SetGlobalValue(globalValue);
                }
            }
            #endregion
        }

        void control_Changed(object sender, EventArgs e)
        {
            if (Changed != null)
            {
                Changed(sender, e);
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            Init();
            FilterControl(Controls);
            #region 通知ILoadedListener界面已经显示出来。例如像条件设置控件这种包含全局变量的控件，便可以在被通知Loaded以后，向框架发送自己包含的全局变量。
            foreach (ILoadedListener iLoadedListener in iLoadedListenerList)
            {
                iLoadedListener.Loaded();
            }
            #endregion
            base.OnLoad(e);
        }

        #region IGlobalValueProvider 成员

        public event GlobalValueChangedHandle GlobalValueChanged;

        #endregion

        #region IGlobalValueToolStripItemAsker 成员

        public event AskForGlobalValueToolStripItemHandle AskForGlobalValueToolStripItem;

        public void SetGlobalValue(string globalValue)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        #region IToolStripMenuProvider 成员

        public event ProvideToolStripMenuHandle ProvideToolStripMenu;

        #endregion

        #region IShowStatusStripHelp 成员

        public event ShowStatusStripHelpHandle ShowStatusStripHelp;

        #endregion

        #region IBringToFront 成员

        public event AskForBringToFrontHandle AskForBringToFront;

        #endregion
    }
}
