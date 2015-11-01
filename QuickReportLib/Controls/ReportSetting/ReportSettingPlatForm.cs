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
    /// ��������ƽ̨��
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
        /// �洢��Ҫ����ʱ���¼���ICheckInput��
        /// </summary>
        private List<ICheckInput> iCheckInputList = new List<ICheckInput>();
        private List<IGlobalValueAsker> iGlobalValueAskerList = new List<IGlobalValueAsker>();
        private List<ILoadedListener> iLoadedListenerList = new List<ILoadedListener>();
        private List<IReportSettingUserControl> iReportSettingUserControlList = new List<IReportSettingUserControl>();

        /// <summary>
        /// ���������ý����е�ֵ�����ı�����������¼���
        /// </summary>
        internal event EventHandler Changed;

        /// <summary>
        /// ��Ӹ������ý��档
        /// </summary>
        private void Init()
        {
            //��ʼ�������ͷ��ƽ��档
            headerSetting.Init(report);
            //��ʼ�����������������ý��档
            reportSettingTabControl.Init(report);
        }

        /// <summary>
        /// ������¼�������
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
        /// ���汨��
        /// </summary>
        /// <returns>1�ɹ���-1ʧ�ܡ�</returns>
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
            #region ���浽���ݿ⡣
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
        /// �ݹ���ã�����ʵ�ָ��ֽӿڵĿؼ���ʵ�ָ��ӿڵĹ����Լ�Ϊ�����ؼ�����ֵ�ı��¼���
        /// </summary>
        /// <param name="controls">�ؼ��б�</param>
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
            #region ������ReportTabControl����ȫ�ֱ������ع���������Ϊ���ڵ�һ����ReportSettingPlatForm��ߵȼ�����ƽ��档
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
            #region ֪ͨILoadedListener�����Ѿ���ʾ�������������������ÿؼ����ְ���ȫ�ֱ����Ŀؼ���������ڱ�֪ͨLoaded�Ժ����ܷ����Լ�������ȫ�ֱ�����
            foreach (ILoadedListener iLoadedListener in iLoadedListenerList)
            {
                iLoadedListener.Loaded();
            }
            #endregion
            base.OnLoad(e);
        }

        #region IGlobalValueProvider ��Ա

        public event GlobalValueChangedHandle GlobalValueChanged;

        #endregion

        #region IGlobalValueToolStripItemAsker ��Ա

        public event AskForGlobalValueToolStripItemHandle AskForGlobalValueToolStripItem;

        public void SetGlobalValue(string globalValue)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        #region IToolStripMenuProvider ��Ա

        public event ProvideToolStripMenuHandle ProvideToolStripMenu;

        #endregion

        #region IShowStatusStripHelp ��Ա

        public event ShowStatusStripHelpHandle ShowStatusStripHelp;

        #endregion

        #region IBringToFront ��Ա

        public event AskForBringToFrontHandle AskForBringToFront;

        #endregion
    }
}
