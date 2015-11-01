using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using FarPoint.Win.Spread;
using FarPoint.Win.Spread.CellType;
using QuickReportLib.Interfaces.PublicInterface;
using QuickReportLib.Objects.ReportSetting;
using QuickReportLib.PublicInterfaces;
using QuickReportLib.Interfaces.GlobalValue;
using QuickReportLib.Enums;
using QuickReportLib.Managers;
using QuickReportLib.Objects;

namespace QuickReportLib.Controls.PublicInterfaceSetting
{
    internal partial class IDatasAskerSetting : BaseUserControl, IPublicInterfaceSettingUserControl , IGlobalValueToolStripItemAsker
    {
        public IDatasAskerSetting()
        {
            InitializeComponent();
            InitAskForGlobalValueTypes();
        }

        private InterfaceSetting interfaceSetting;
        private OpenFileDialog openFileDialog = new OpenFileDialog();
        private ComboBoxCellType comboBoxCellType = new ComboBoxCellType();
        private HyperLinkCellType hyperLinkCellType = new HyperLinkCellType();
        private List<InterfaceSettingToolStripButtonType> interfaceSettingToolStripButtonTypeList; 
        private List<GlobalValueType> globalValueTypeList;
        private List<GlobalValueType> nullGlobalValueTypeList = new List<GlobalValueType>();

        private void SetHyperLinkCellTypeCellText(Cell cell, string text)
        {
            hyperLinkCellType.Link = " ";
            hyperLinkCellType.Text = text;
            cell.CellType = hyperLinkCellType.Clone() as FarPoint.Win.Spread.CellType.HyperLinkCellType;
        }

        private void Add(IDatasAskerImplementor iDatasAskerImplementor)
        {
            fpInterfaces_Sheet1.Rows.Count++;
            int lastRowIndex = fpInterfaces_Sheet1.Rows.Count - 1;
            fpInterfaces_Sheet1.Rows[lastRowIndex].Tag = iDatasAskerImplementor;
            if (iDatasAskerImplementor.DllName == string.Empty)
            {
                fpInterfaces_Sheet1.Cells[lastRowIndex, 0].Value = "单击选择文件";
            }
            else
            {
                fpInterfaces_Sheet1.Cells[lastRowIndex, 0].Value = iDatasAskerImplementor.DllName;
                fpInterfaces_Sheet1.Cells[lastRowIndex, 2].Locked = false;
            }
            fpInterfaces_Sheet1.Cells[lastRowIndex, 1].Value = iDatasAskerImplementor.ClassName;
            fpInterfaces_Sheet1.Cells[lastRowIndex, 2].Value = iDatasAskerImplementor.Value;
            Cell cell = fpInterfaces_Sheet1.Cells[lastRowIndex, 0];
            SetHyperLinkCellTypeCellText(cell, cell.Value.ToString());
        }

        private void InitAskForGlobalValueTypes()
        {
            globalValueTypeList = new List<GlobalValueType>();
            globalValueTypeList.Add(GlobalValueType.Date);
            globalValueTypeList.Add(GlobalValueType.DateTime);
            globalValueTypeList.Add(GlobalValueType.Person);
            globalValueTypeList.Add(GlobalValueType.Department);
            globalValueTypeList.Add(GlobalValueType.Column);
            globalValueTypeList.Add(GlobalValueType.Condition);
            globalValueTypeList.Add(GlobalValueType.Tree);
            globalValueTypeList.Add(GlobalValueType.Donamic);
        }

        private void AskForGlobalValue(bool b)
        {
            if (b)
            {
                if (AskForGlobalValueToolStripItem != null)
                {
                    AskForGlobalValueToolStripItem(this, globalValueTypeList);
                }
            }
            else
            {
                if (AskForGlobalValueToolStripItem != null)
                {
                    AskForGlobalValueToolStripItem(this, nullGlobalValueTypeList);
                }
            }
        }

        private void fpInterfaces_ButtonClicked(object sender, EditorNotifyEventArgs e)
        {
            DialogResult dr = openFileDialog.ShowDialog();
            if (dr == DialogResult.OK)
            {
                string dllName = openFileDialog.SafeFileName;
                List<Type> typeList = null;
                typeList = ReflectionManager.GetTypesByInterfaceWithOutAbstract(dllName, InterfaceType, TypeOfType.Class);
                if (typeList == null || typeList.Count == 0)
                {
                    return;
                }
                SetHyperLinkCellTypeCellText(fpInterfaces_Sheet1.Cells[e.Row, e.Column], dllName);
                IDatasAskerImplementor iDatasAskerImplementor = fpInterfaces_Sheet1.Rows[e.Row].Tag as IDatasAskerImplementor;
                iDatasAskerImplementor.DllName = dllName;
                string[] types = new string[typeList.Count];
                for (int i = 0; i < typeList.Count; i++)
                {
                    types[i] = typeList[i].FullName;
                }
                comboBoxCellType.Items = types;
                fpInterfaces_Sheet1.Cells[e.Row, 1].CellType = comboBoxCellType.Clone() as FarPoint.Win.Spread.CellType.ComboBoxCellType;
                fpInterfaces_Sheet1.Cells[e.Row, 1].Locked = false;
            }
        }

        private void fpInterfaces_EditChange(object sender, EditorNotifyEventArgs e)
        {
            if (e.Column == 1)
            {
                IDatasAskerImplementor iDatasAskerImplementor = fpInterfaces_Sheet1.Rows[e.Row].Tag as IDatasAskerImplementor;
                iDatasAskerImplementor.ClassName = fpInterfaces_Sheet1.Cells[e.Row, 1].Text;
                if (!interfaceSetting.IDatasAskerImplementorList.Contains(iDatasAskerImplementor))
                {
                    interfaceSetting.IDatasAskerImplementorList.Add(iDatasAskerImplementor);
                }
                fpInterfaces_Sheet1.Cells[e.Row, 1].CellType = comboBoxCellType.Clone() as FarPoint.Win.Spread.CellType.ComboBoxCellType;
                fpInterfaces_Sheet1.Cells[e.Row, 2].Locked = false;
            }
            else if (e.Column == 2)
            {
                IDatasAskerImplementor iDatasAskerImplementor = fpInterfaces_Sheet1.Rows[e.Row].Tag as IDatasAskerImplementor;
                iDatasAskerImplementor.Value = fpInterfaces_Sheet1.Cells[e.Row, 2].Text;
            }
        }

        private void fpInterfaces_CellClick(object sender, CellClickEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (e.Column == 2)
                {
                    AskForGlobalValue(true);
                }
                else
                {
                    AskForGlobalValue(false);
                }
            }
        }

        private void fpInterfaces_EnterCell(object sender, EnterCellEventArgs e)
        {
            if (e.Column == 2)
            {
                AskForGlobalValue(true);
            }
            else
            {
                AskForGlobalValue(false);
            }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            float column0Width = fpInterfaces_Sheet1.Columns[0].Width;
            float column1Width = fpInterfaces_Sheet1.Columns[1].Width;
            float column2Width = Width - (column0Width + column1Width)-10;
            if(column2Width>0)
            {
                fpInterfaces_Sheet1.Columns[2].Width = column2Width;
            }
            base.OnSizeChanged(e);
        }

        #region IPublicInterfaceSettingUserControl 成员

        public Type InterfaceType
        {
            get
            {
                return typeof(IDatasAsker);
            }
        }

        public InterfaceSetting InterfaceSetting
        {
            get
            {
                return interfaceSetting;
            }
            set
            {
                interfaceSetting = value; 
                fpInterfaces_Sheet1.Rows.Count = 0;
                List<BaseObject> baseObjectList = new List<BaseObject>();   
                foreach (IDatasAskerImplementor iDatasAskerImplementor in interfaceSetting.IDatasAskerImplementorList)
                {
                    baseObjectList.Add(iDatasAskerImplementor);
                }
                SortedList sl = ListManager.ListToSortedList(baseObjectList);
                foreach (DictionaryEntry de in sl)
                {
                    Add(de.Key as IDatasAskerImplementor);
                }
            }
        }

        public void Add()
        {
            IDatasAskerImplementor iDatasAskerImplementor = new IDatasAskerImplementor();
            //添加至FP。此时先不将iDatasAskerImplementor添加至interfaceSetting.IDatasAskerImplementorList中。在FP的EditChange进行添加。
            //因为只有在选择一个完成的接口实现类之后才会触发EditChange事件，此时再将新添加的接口实现类添加至interfaceSetting.IDatasAskerImplementorList才有意义。
            Add(iDatasAskerImplementor);
            if (Changed != null)
            {
                Changed(this, null);
            }
        }

        public void Delete()
        {
            Cell cell = fpInterfaces_Sheet1.ActiveCell;
            if (cell == null)
            {
                return;
            }
            IDatasAskerImplementor iDatasAskerImplementor = fpInterfaces_Sheet1.Rows[cell.Row.Index].Tag as IDatasAskerImplementor;
            //如果为非空的接口设置，才弹出确认删除询问。
            if (iDatasAskerImplementor.DllName != string.Empty && iDatasAskerImplementor.ClassName != string.Empty&&iDatasAskerImplementor.Value!=string.Empty)
            {
                DialogResult dr = MessageBox.Show("确认要删除 " + iDatasAskerImplementor.DllName + " 下的 " + iDatasAskerImplementor.ClassName + " 吗？", "删除ISystemValue", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr != DialogResult.Yes)
                {
                    return;
                }
            }
            if (interfaceSetting.IDatasAskerImplementorList.Contains(iDatasAskerImplementor))
            {
                interfaceSetting.IDatasAskerImplementorList.Remove(iDatasAskerImplementor);
            }
            fpInterfaces_Sheet1.Rows.Remove(cell.Row.Index, 1);
            if (Changed != null)
            {
                Changed(this, null);
            }
        }

        public void Up()
        {
            Cell cell = fpInterfaces_Sheet1.ActiveCell;
            if (cell == null||cell.Row.Index==0)
            {
                return;
            }
            fpInterfaces_Sheet1.MoveRow(cell.Row.Index, cell.Row.Index - 1, true);
            fpInterfaces_Sheet1.SetActiveCell(cell.Row.Index - 1, cell.Column.Index);
            if (Changed != null)
            {
                Changed(this, null);
            }
        }

        public void Down()
        {
            Cell cell = fpInterfaces_Sheet1.ActiveCell;
            if (cell == null||cell.Row.Index==fpInterfaces_Sheet1.Rows.Count-1)
            {
                return;
            }
            fpInterfaces_Sheet1.MoveRow(cell.Row.Index, cell.Row.Index + 1, true);
            fpInterfaces_Sheet1.SetActiveCell(cell.Row.Index + 1, cell.Column.Index);
            if (Changed != null)
            {
                Changed(this, null);
            }
        }

        public int CheckInput()
        {
            fpInterfaces.StopCellEditing();
            int sortID = 0;
            for (int i = 0; i < fpInterfaces_Sheet1.Rows.Count; i++)
            {
                IDatasAskerImplementor iDatasAskerImplementor = fpInterfaces_Sheet1.Rows[i].Tag as IDatasAskerImplementor;
                if (iDatasAskerImplementor.DllName != string.Empty && iDatasAskerImplementor.ClassName != string.Empty)
                {
                    iDatasAskerImplementor.SortID = sortID;
                    sortID++;
                }
            }
            return 1;
        }

        public List<InterfaceSettingToolStripButtonType> GetNeededToolStripButtons()
        {
            if (interfaceSettingToolStripButtonTypeList == null)
            {
                interfaceSettingToolStripButtonTypeList = new List<InterfaceSettingToolStripButtonType>();
                interfaceSettingToolStripButtonTypeList.Add(InterfaceSettingToolStripButtonType.Add);
                interfaceSettingToolStripButtonTypeList.Add(InterfaceSettingToolStripButtonType.Delete);
                interfaceSettingToolStripButtonTypeList.Add(InterfaceSettingToolStripButtonType.Up);
                interfaceSettingToolStripButtonTypeList.Add(InterfaceSettingToolStripButtonType.Down);
            }
            return interfaceSettingToolStripButtonTypeList;
        }

        public void Loaded()
        {

        }

        #endregion

        #region IGlobalValueProvider 成员

        public event GlobalValueChangedHandle GlobalValueChanged;

        #endregion

        #region IChangedUserControl 成员

        public event EventHandler Changed;

        #endregion

        #region IGlobalValueToolStripItemAsker 成员

        public event AskForGlobalValueToolStripItemHandle AskForGlobalValueToolStripItem;

        public void SetGlobalValue(string globalValue)
        {
            Cell cell = fpInterfaces_Sheet1.ActiveCell;
            if (cell != null)
            {
                if (fpInterfaces.IsEditing)
                {
                    GeneralEditor generalEditor = fpInterfaces.EditingControl as GeneralEditor;
                    int start = generalEditor.SelectionStart;
                    int length = generalEditor.SelectionLength;
                    if (generalEditor.Text == null)
                    {
                        generalEditor.Text = " ";
                        generalEditor.Text = string.Empty;
                    }
                    generalEditor.Text = generalEditor.Text.Remove(start, length);
                    generalEditor.Text = generalEditor.Text.Insert(start, globalValue);
                    generalEditor.Select(start + globalValue.Length, 0);
                }
                else
                {
                    cell.Value = cell.Text + globalValue;
                }
                if (Changed != null)
                {
                    Changed(this, null);
                }
            }
        }

        #endregion
    }
}
