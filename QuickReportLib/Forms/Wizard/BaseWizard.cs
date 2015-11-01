using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using QuickReportLib.Objects;
using QuickReportLib.Interfaces.Wizard;
using QuickReportLib.Managers;
using QuickReportLib.Enums;

namespace QuickReportLib.Forms.Wizard
{
    /// <summary>
    /// 基础向导界面。
    /// </summary>
    public partial class BaseWizard : BaseForm
    {
        public BaseWizard()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 初始化向导界面。
        /// </summary>
        /// <param name="report">报表实体。</param>
        public BaseWizard(Report report)
        {
            InitializeComponent();
            this.report = report;
        }

        private bool isWizardOfWizard = false;
        private bool isDone = false;
        private int currentWizardSortID = 0;
        private string nextButtonText = "下一步(&N)";
        private string finishButtonText = "完成(&F)";
        private SortedList iWizardUserControlList;
        protected Report report;
        private WizardOfWizardDoneAction wizardOfWizardDoneAction = WizardOfWizardDoneAction.Continue;
        internal event WizardDoneHandle WizardDone;
        private DialogResult dialogResult = DialogResult.Cancel;

        /// <summary>
        /// 是否正常结束向导。
        /// </summary>
        public bool IsDone
        {
            get
            {
                return isDone;
            }
            set
            {
                isDone = value;
            }
        }

        /// <summary>
        /// 该向导界面所容纳的向导类型。
        /// </summary>
        protected virtual Type WizardType
        {
            get
            {
                return null;
            }
        }

        /// <summary>
        /// 是否是向导的向导。
        /// </summary>
        public bool IsWizardOfWizard
        {
            get
            {
                return isWizardOfWizard;
            }
            set
            {
                isWizardOfWizard = value;
            }
        }

        /// <summary>
        /// 结果。
        /// </summary>
        public new DialogResult DialogResult
        {
            get
            {
                return dialogResult;
            }
            set
            {
                dialogResult = value;
            }
        }

        private void InitWizards()
        {
            iWizardUserControlList = new SortedList();
            List<object> objectList = ReflectionManager.CreateInstancesByInterface(WizardType);
            foreach (object obj in objectList)
            {
                IWizardUserControl iWizardUserControl = obj as IWizardUserControl;
                iWizardUserControl.Report = report;
                iWizardUserControlList.Add(iWizardUserControl.SortID,iWizardUserControl);
            }
            SuspendLayout();
            foreach (DictionaryEntry de in iWizardUserControlList)
            {
                Control control = de.Value as Control;
                control.Dock= DockStyle.Fill;
                pnlCenter.Controls.Add(control);
            }
            ResumeLayout();
        }

        private void ShowWizard()
        {
            if (iWizardUserControlList.Count == 0)
            {
                return;
            }
            SuspendLayout();
            foreach (DictionaryEntry de in iWizardUserControlList)
            {
                (de.Value as Control).Visible = false; 
            }
            Control control = iWizardUserControlList[currentWizardSortID] as Control;
            control.Visible = true;
            IWizardUserControl iWizardUserControl = iWizardUserControlList[currentWizardSortID] as IWizardUserControl;
            iWizardUserControl.Report = report;
            lbWizardTitle.Text = iWizardUserControl.Title;
            lbWizardSummary.Text = iWizardUserControl.Summary;
            imgWizard.Image = iWizardUserControl.Image;
            ResumeLayout();
        }

        private void LastWizard()
        {
            currentWizardSortID--;
            ShowWizard();
            btNext.Text = nextButtonText;
            if (currentWizardSortID == 0)
            {
                if (!isWizardOfWizard)//如果不是向导的向导（也就是第一个向导），则置“上一步”为不可使用。
                {
                    btLast.Enabled = false;
                }
            }
        }

        private void NextWizard()
        {
            if (iWizardUserControlList.Count == 0)
            {
                return;
            }
            IWizardUserControl iWizardUserControl;
            bool canNext = false;
            iWizardUserControl = iWizardUserControlList[currentWizardSortID] as IWizardUserControl;
            canNext = iWizardUserControl.CanNext();
            if (!canNext)
            {
                return;
            }
            if (currentWizardSortID == iWizardUserControlList.Count - 1)
            {
                Done();
                return;
            }
            Control control = iWizardUserControlList[currentWizardSortID] as Control;
            if (control is IWizardContainsWizardUserControl)
            {
                IWizardContainsWizardUserControl iWizardContainsWizardUserControl = control as IWizardContainsWizardUserControl;
                iWizardContainsWizardUserControl.WizardOfWizardDone += new WizardOfWizardDoneHandle(iWizardContainsWizardUserControl_WizardOfWizardDone);
                iWizardContainsWizardUserControl.Report = report;
                iWizardContainsWizardUserControl.ShowWizard();
            }
            switch (wizardOfWizardDoneAction)
            {
                case WizardOfWizardDoneAction.Continue:
                    {
                        break;
                    }
                case WizardOfWizardDoneAction.Stay:
                    {
                        wizardOfWizardDoneAction = WizardOfWizardDoneAction.Continue;
                        return;
                    }
                case WizardOfWizardDoneAction.Done:
                    {
                        Done();
                        return;
                    }
            }
            currentWizardSortID++;
            ShowWizard();
            btLast.Enabled = true;
            if (currentWizardSortID == iWizardUserControlList.Count - 1)
            {
                if (!isWizardOfWizard)//如果是向导的向导，则永远都显示下一步。
                {
                    btNext.Text = finishButtonText;
                }
            }
        }

        private void Done()
        {
            if (WizardDone != null)
            {
                WizardDone(this, report);
            }
            isDone = true;
            dialogResult = DialogResult.Yes;
            Close();
        }

        void iWizardContainsWizardUserControl_WizardOfWizardDone(object sender, Report report, WizardOfWizardDoneAction doneAction)
        {
            this.report = report;
            wizardOfWizardDoneAction = doneAction;
        }

        protected override void OnLoad(EventArgs e)
        {
            if (WizardType == null || DesignMode)
            {
                return;
            }
            if (!isWizardOfWizard)//如果不是向导的向导，则初始设置“上一步”为不可用。
            {
                btLast.Enabled = false;
            }
            InitWizards();
            ShowWizard();
            base.OnLoad(e);
        }

        private void btLast_Click(object sender, EventArgs e)
        {
            if (isWizardOfWizard)//如果当前是向导的向导，且所显示的SortID已经是第0个，则关闭向导。
            {
                if (currentWizardSortID == 0)
                {
                    Close();
                    return;
                }
            }
            LastWizard();
        }

        private void btNext_Click(object sender, EventArgs e)
        {
            NextWizard();
        }

        private void msBottomShortCutKeyLast_Click(object sender, EventArgs e)
        {
            if (btLast.Enabled)
            {
                LastWizard();
            }
        }

        private void msBottomShortCutKeyNext_Click(object sender, EventArgs e)
        {
            if (btNext.Text == nextButtonText)
            {
                NextWizard();
            }
        }

        private void msBottomShortCutKeyFinish_Click(object sender, EventArgs e)
        {
            if (btNext.Text == finishButtonText)
            {
                NextWizard();
            }
        }
    }

    /// <summary>
    /// 向导结束时，执行的方法。
    /// </summary>
    /// <param name="sender">事件源。</param>
    /// <param name="report">报表实体。</param>
    internal delegate void WizardDoneHandle(object sender, Report report);
}