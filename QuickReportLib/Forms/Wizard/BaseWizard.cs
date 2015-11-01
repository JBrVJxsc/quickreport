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
    /// �����򵼽��档
    /// </summary>
    public partial class BaseWizard : BaseForm
    {
        public BaseWizard()
        {
            InitializeComponent();
        }

        /// <summary>
        /// ��ʼ���򵼽��档
        /// </summary>
        /// <param name="report">����ʵ�塣</param>
        public BaseWizard(Report report)
        {
            InitializeComponent();
            this.report = report;
        }

        private bool isWizardOfWizard = false;
        private bool isDone = false;
        private int currentWizardSortID = 0;
        private string nextButtonText = "��һ��(&N)";
        private string finishButtonText = "���(&F)";
        private SortedList iWizardUserControlList;
        protected Report report;
        private WizardOfWizardDoneAction wizardOfWizardDoneAction = WizardOfWizardDoneAction.Continue;
        internal event WizardDoneHandle WizardDone;
        private DialogResult dialogResult = DialogResult.Cancel;

        /// <summary>
        /// �Ƿ����������򵼡�
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
        /// ���򵼽��������ɵ������͡�
        /// </summary>
        protected virtual Type WizardType
        {
            get
            {
                return null;
            }
        }

        /// <summary>
        /// �Ƿ����򵼵��򵼡�
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
        /// �����
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
                if (!isWizardOfWizard)//��������򵼵��򵼣�Ҳ���ǵ�һ���򵼣������á���һ����Ϊ����ʹ�á�
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
                if (!isWizardOfWizard)//������򵼵��򵼣�����Զ����ʾ��һ����
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
            if (!isWizardOfWizard)//��������򵼵��򵼣����ʼ���á���һ����Ϊ�����á�
            {
                btLast.Enabled = false;
            }
            InitWizards();
            ShowWizard();
            base.OnLoad(e);
        }

        private void btLast_Click(object sender, EventArgs e)
        {
            if (isWizardOfWizard)//�����ǰ���򵼵��򵼣�������ʾ��SortID�Ѿ��ǵ�0������ر��򵼡�
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
    /// �򵼽���ʱ��ִ�еķ�����
    /// </summary>
    /// <param name="sender">�¼�Դ��</param>
    /// <param name="report">����ʵ�塣</param>
    internal delegate void WizardDoneHandle(object sender, Report report);
}