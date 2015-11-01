using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace QuickReportCore.Controls
{
    internal partial class TextBoxWithSelector : TextBox, Interfaces.INeedTranslatedValue, Interfaces.INeedQuery
    {
        public TextBoxWithSelector()
        {
            InitializeComponent();
        }

        private Managers.QuickReportManager quickReportManager;

        private bool hideOutColumn = true;
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

        private bool useSelector = false;
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

        private bool usePadLeftZero = false;
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

        private string sql = string.Empty;
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

        private string title = "��ѡ��һ����¼��";
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

        private string outValue = string.Empty;
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

        private string nullMessage = string.Empty;
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

        private ConditionValue.ucConditionValueText.SelectorActionType actionType = QuickReportCore.Controls.ConditionValue.ucConditionValueText.SelectorActionType.��ѯ;
        internal ConditionValue.ucConditionValueText.SelectorActionType ActionType
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

        private string outColumn = string.Empty;
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

        private Forms.frmSelector frmSelector;

        private int leftPadZeroPlace = 12;
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
            if(quickReportManager==null)
                quickReportManager = new QuickReportCore.Managers.QuickReportManager();
            frmSelector = new QuickReportCore.Forms.frmSelector();
            frmSelector.Title = Title;
            frmSelector.OutColumn = OutColumn;
            frmSelector.HideOutColumn = HideOutColumn;
            frmSelector.SelectItem += new QuickReportCore.Forms.frmSelector.SelectItemHandle(frmSelector_SelectItem);
        }

        private int SetFormData()
        {
            string tempSql = SQL;
            if (NeedTranslatedValue != null)
            {
                #region ��Ҫ����������ࡣ
                Managers.Functions.SQLCodeType[] types = new QuickReportCore.Managers.Functions.SQLCodeType[4];
                types[0] = QuickReportCore.Managers.Functions.SQLCodeType.Tree;
                types[1] = QuickReportCore.Managers.Functions.SQLCodeType.System;
                types[2] = QuickReportCore.Managers.Functions.SQLCodeType.Condition;
                types[3] = QuickReportCore.Managers.Functions.SQLCodeType.Column;
                #endregion
                Translating = true;
                NeedTranslatedValue(ref tempSql, types);
                Translating = false;
            }
            DataSet ds = GetDataSet(tempSql);
            if (ds == null)
                return -1;
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
            if (ActionType== QuickReportCore.Controls.ConditionValue.ucConditionValueText.SelectorActionType.��ѯ && NeedQuery != null)
                NeedQuery(this);
        }

        private DataSet GetDataSet(string sql)
        {
            DataSet ds = null;
            quickReportManager.ExecQuery(sql, ref ds);
            return ds;
        }

        private void TextBoxWithSelector_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;
            if (UsePadLeftZero)
            {
                Text = Text.PadLeft(LeftPadZeroPlace, '0');
                Select(Text.Length, 0);
            }
            if (!UseSelector)
            {
                if (NeedQuery != null)
                    NeedQuery(this);
                return;
            }
            if (frmSelector == null)
                InitFormSelector();
            int i = SetFormData();
            if (i <= 0)
            {
                Managers.Functions.ShowToolTip(this, NullMessage);
                return;
            }
            frmSelector.Show();
        }

        #region INeedTranslatedValue ��Ա

        public event QuickReportCore.Interfaces.NeedTranslatedValueHandle NeedTranslatedValue;

        #endregion

        #region INeedQuery ��Ա

        public event QuickReportCore.Interfaces.NeedQueryHandle NeedQuery;

        #endregion

        #region INeedTranslatedValue ��Ա

        private bool translating = false;
        public bool Translating
        {
            get {return translating; }
            set { translating = value; }
        }

        #endregion
    }
}
