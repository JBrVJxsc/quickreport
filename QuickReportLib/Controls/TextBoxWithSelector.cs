using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using QuickReportLib.Controls.Plus;
using QuickReportLib.Interfaces.ReportUserControl;
using QuickReportLib.Managers;
using QuickReportLib.Enums;
using QuickReportLib.Controls.Forms;

namespace QuickReportCore.Controls
{
    internal partial class TextBoxWithSelector : TextBoxPlus , ISendQueryCommandUserControl , ISendTranslateValueCommandUserControl
    {
        public TextBoxWithSelector()
        {
            InitializeComponent();
        }

        private DataBaseManager dataBaseManager;
        private bool hideOutColumn = true;
        private bool useSelector = false;
        private bool usePadLeftZero = false;
        private string sql = string.Empty;
        private string title = "��ѡ��һ����¼��";
        private string outValue = string.Empty;
        private string nullMessage = string.Empty;
        private TextBoxWithSelectorActionType actionType = TextBoxWithSelectorActionType.��ѯ;
        private string outColumn = string.Empty;
        private SelectorForm frmSelector;
        private int leftPadZeroPlace = 12; 
        private bool translating = false;

        /// <summary>
        /// �Ƿ���������С�
        /// </summary>
        public bool HideOutColumn
        {
            get
            {
                return hideOutColumn;
            }
            set
            {
                hideOutColumn = value;
            }
        }

        /// <summary>
        /// �Ƿ�����ѡ����ܡ�
        /// </summary>
        public bool UseSelector
        {
            get
            {
                return useSelector;
            }
            set 
            {
                useSelector = value;
            }
        }

        /// <summary>
        /// �Ƿ�������ȫ���ܡ�
        /// </summary>
        public bool UsePadLeftZero
        {
            get
            {
                return usePadLeftZero;
            }
            set
            {
                usePadLeftZero = value;
            }
        }

        /// <summary>
        /// SQL��䡣
        /// </summary>
        public string SQL
        {
            get
            {
                return sql;
            }
            set
            {
                sql = value;
            }
        }

        /// <summary>
        /// ������Ϣ��
        /// </summary>
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
            }
        }

        /// <summary>
        /// ����ֵ��
        /// </summary>
        public string OutValue
        {
            get
            {
                return outValue;
            }
            set
            {
                outValue = value;
            }
        }

        /// <summary>
        /// ��δ���ҵ���Ч��¼ʱ����ʾ����Ϣ��
        /// </summary>
        public string NullMessage
        {
            get
            {
                return nullMessage;
            }
            set
            {
                nullMessage = value;
            }
        }

        /// <summary>
        /// TextBoxWithSelector��ѡ���ִ�еĲ�ѯ��
        /// </summary>
        public TextBoxWithSelectorActionType ActionType
        {
            get
            {
                return actionType;
            }
            set
            {
                actionType = value;
            }
        }

        /// <summary>
        /// �����С�
        /// </summary>
        public string OutColumn
        {
            get
            {
                return outColumn;
            }
            set
            {
                outColumn = value;
            }
        }

        /// <summary>
        /// ����λ����
        /// </summary>
        public int LeftPadZeroPlace
        {
            get
            {
                return leftPadZeroPlace;
            }
            set
            {
                leftPadZeroPlace = value;
            }
        }

        private void InitFormSelector()
        {
            if (dataBaseManager == null)
            {
                dataBaseManager = new DataBaseManager();
            }
            frmSelector = new SelectorForm();
            frmSelector.Title = Title;
            frmSelector.OutColumn = OutColumn;
            frmSelector.HideOutColumn = HideOutColumn;
            frmSelector.SelectItem +=new SelectItemHandle(frmSelector_SelectItem);
        }

        private int SetFormData()
        {
            string tempSql = SQL;
            if (TranslateValue != null)
            {
                #region ��Ҫ����������ࡣ
                SQLCodeType[] types = new SQLCodeType[4];
                types[0] = SQLCodeType.Tree;
                types[1] = SQLCodeType.System;
                types[2] = SQLCodeType.Condition;
                types[3] = SQLCodeType.Column;
                #endregion
                Translating = true;
                TranslateValue(tempSql, out tempSql, types);
                Translating = false;
            }
            DataSet ds = GetDataSet(tempSql);
            if (ds == null)
            {
                return -1;
            }
            return frmSelector.InitSelector(this, ds);
        }

        void frmSelector_SelectItem(string item)
        {
            if (item == null)
            {
                frmSelector = null;
                return;
            }
            OutValue = item;
            if (ActionType ==  TextBoxWithSelectorActionType.��ѯ && Query != null)
            {
                Query(this);
            }
        }

        private DataSet GetDataSet(string sql)
        {
            DataSet ds = null;
            dataBaseManager.ExecQuery(sql, ref ds);
            return ds;
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
            {
                return;
            }
            if (UsePadLeftZero)
            {
                Text = Text.PadLeft(LeftPadZeroPlace, '0');
                Select(Text.Length, 0);
            }
            if (!UseSelector)
            {
                if (Query != null)
                {
                    Query(this);
                }
                return;
            }
            if (frmSelector == null)
            {
                InitFormSelector();
            }
            int i = SetFormData();
            if (i <= 0)
            {
                WindowManager.ShowToolTip(this, NullMessage);
                return;
            }
            frmSelector.Show();
            base.OnKeyDown(e);
        }

        #region ISendQueryCommandUserControl ��Ա

        public event SendQueryCommandHandle Query;

        #endregion

        #region ISendTranslateValueCommandUserControl ��Ա

        public bool Translating
        {
            get
            {
                return translating;
            }
            set
            {
                translating = value;
            }
        }

        public event SendTranslateValueCommandHandle TranslateValue;

        #endregion
    }
}
