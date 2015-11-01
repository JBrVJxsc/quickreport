using System;
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
using QuickReportLib.Objects.GlobalValue;
using QuickReportLib.Interfaces.GlobalValue;
using QuickReportLib.Objects;
using QuickReportLib.Managers;
using QuickReportLib.Enums;

namespace QuickReportLib.Controls.PublicInterfaceSetting
{
    internal partial class ISystemValueSetting : BaseUserControl, IPublicInterfaceSettingUserControl
    {
        public ISystemValueSetting()
        {
            InitializeComponent();
        }

        private InterfaceSetting interfaceSetting;
        private DateGlobalValue dateGlobalValue;
        private DateTimeGlobalValue dateTimeGlobalValue;
        private PersonGlobalValue personGlobalValue;
        private DepartmentGlobalValue departmentGlobalValue;
        private OpenFileDialog openFileDialog = new OpenFileDialog();
        private ComboBoxCellType comboBoxCellType = new ComboBoxCellType();
        private HyperLinkCellType hyperLinkCellType = new HyperLinkCellType();
        private List<InterfaceSettingToolStripButtonType> interfaceSettingToolStripButtonTypeList;

        /// <summary>
        /// 将全局变量发送至框架。
        /// </summary>
        private void SendInterfaceToGlobalValue()
        {
            dateGlobalValue = new DateGlobalValue();
            dateTimeGlobalValue = new DateTimeGlobalValue();
            personGlobalValue = new PersonGlobalValue();
            departmentGlobalValue = new DepartmentGlobalValue();
            List<ISystemValue> dateSystemValueList = new List<ISystemValue>();
            List<ISystemValue> dateTimeSystemValueList = new List<ISystemValue>();
            List<ISystemValue> personSystemValueList = new List<ISystemValue>();
            List<ISystemValue> departmentSystemValueList = new List<ISystemValue>();
            foreach (ISystemValueImplementor iSystemValueImplementor in interfaceSetting.ISystemValueImplementorList)
            {
                ISystemValue iSystemValue = ReflectionManager.CreateInstanceByClassName(iSystemValueImplementor.DllName, iSystemValueImplementor.ClassName) as ISystemValue;
                switch (iSystemValue.ValueType)
                {
                    case SystemValueType.Date:
                        {
                            dateSystemValueList.Add(iSystemValue);
                            break;
                        }
                    case SystemValueType.DateTime:
                        {
                            dateTimeSystemValueList.Add(iSystemValue);
                            break;
                        }
                    case SystemValueType.Person:
                        {
                            personSystemValueList.Add(iSystemValue);
                            break;
                        }
                    case SystemValueType.Department:
                        {
                            departmentSystemValueList.Add(iSystemValue);
                            break;
                        }
                }
            }

            int sortID = dateGlobalValue.Value.Count;
            foreach (ISystemValue iSystemValue in dateSystemValueList)
            {
                BaseObject baseObject = new BaseObject(iSystemValue.ValueID, iSystemValue.ValueName, sortID);
                dateGlobalValue.Value.Add(baseObject);
                sortID++;
            }
            SendInterfaceToGlobalValue(dateGlobalValue);

            sortID = dateTimeGlobalValue.Value.Count;
            foreach (ISystemValue iSystemValue in dateTimeSystemValueList)
            {
                BaseObject baseObject = new BaseObject(iSystemValue.ValueID, iSystemValue.ValueName, sortID);
                dateTimeGlobalValue.Value.Add(baseObject);
                sortID++;
            }
            SendInterfaceToGlobalValue(dateTimeGlobalValue);

            sortID = personGlobalValue.Value.Count;
            foreach (ISystemValue iSystemValue in personSystemValueList)
            {
                BaseObject baseObject = new BaseObject(iSystemValue.ValueID, iSystemValue.ValueName, sortID);
                personGlobalValue.Value.Add(baseObject);
                sortID++;
            }
            SendInterfaceToGlobalValue(personGlobalValue);

            sortID = departmentGlobalValue.Value.Count;
            foreach (ISystemValue iSystemValue in departmentSystemValueList)
            {
                BaseObject baseObject = new BaseObject(iSystemValue.ValueID, iSystemValue.ValueName, sortID);
                departmentGlobalValue.Value.Add(baseObject);
                sortID++;
            }
            SendInterfaceToGlobalValue(departmentGlobalValue);
        }

        private void SendInterfaceToGlobalValue(IGlobalValue iGlobalValue)
        {
            if (GlobalValueChanged != null)
            {
                GlobalValueChanged(this, iGlobalValue);
            }
        }

        private void SetHyperLinkCellTypeCellText(Cell cell, string text)
        {
            hyperLinkCellType.Link = " ";
            hyperLinkCellType.Text = text;
            cell.CellType = hyperLinkCellType.Clone() as FarPoint.Win.Spread.CellType.HyperLinkCellType;
        }

        private void Add(ISystemValueImplementor iSystemValueImplementor)
        {
            fpInterfaces_Sheet1.Rows.Count++;
            int lastRowIndex = fpInterfaces_Sheet1.Rows.Count - 1;
            fpInterfaces_Sheet1.Rows[lastRowIndex].Tag = iSystemValueImplementor;
            if (iSystemValueImplementor.DllName == string.Empty)
            {
                fpInterfaces_Sheet1.Cells[lastRowIndex, 0].Value = "单击选择文件";
            }
            else
            {
                fpInterfaces_Sheet1.Cells[lastRowIndex, 0].Value = iSystemValueImplementor.DllName;
            }
            fpInterfaces_Sheet1.Cells[lastRowIndex, 1].Value = iSystemValueImplementor.ClassName;
            Cell cell = fpInterfaces_Sheet1.Cells[lastRowIndex, 0];
            SetHyperLinkCellTypeCellText(cell, cell.Value.ToString());
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
                ISystemValueImplementor iSystemValueImplementor = fpInterfaces_Sheet1.Rows[e.Row].Tag as ISystemValueImplementor;
                iSystemValueImplementor.DllName = dllName;
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
                ISystemValueImplementor iSystemValueImplementor = fpInterfaces_Sheet1.Rows[e.Row].Tag as ISystemValueImplementor;
                iSystemValueImplementor.ClassName = fpInterfaces_Sheet1.Cells[e.Row, 1].Text;
                if (!interfaceSetting.ISystemValueImplementorList.Contains(iSystemValueImplementor))
                {
                    interfaceSetting.ISystemValueImplementorList.Add(iSystemValueImplementor);
                }
                SendInterfaceToGlobalValue();
            }
        }

        #region IPublicInterfaceSettingUserControl 成员

        public Type InterfaceType
        {
            get
            { 
                return typeof(ISystemValue);
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
                foreach (ISystemValueImplementor iSystemValueImplementor in interfaceSetting.ISystemValueImplementorList)
                {
                    Add(iSystemValueImplementor);
                }
            }
        }

        public void Add()
        {
            ISystemValueImplementor iSystemValueImplementor = new ISystemValueImplementor();
            //添加至FP。此时先不将iSystemValueImplementor添加至interfaceSetting.ISystemValueImplementorList中。在FP的EditChange进行添加。
            //因为只有在选择一个完成的接口实现类之后才会触发EditChange事件，此时再将新添加的接口实现类添加至interfaceSetting.ISystemValueImplementorList才有意义。
            Add(iSystemValueImplementor);
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
            ISystemValueImplementor iSystemValueImplementor = fpInterfaces_Sheet1.Rows[cell.Row.Index].Tag as ISystemValueImplementor;
            //如果为非空的接口设置，才弹出确认删除询问。
            if (iSystemValueImplementor.DllName != string.Empty&&iSystemValueImplementor.ClassName!=string.Empty)
            {
                DialogResult dr = MessageBox.Show("确认要删除 " + iSystemValueImplementor.DllName + " 下的 "+iSystemValueImplementor.ClassName+" 吗？", "删除ISystemValue", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr != DialogResult.Yes)
                {
                    return;
                }
            }
            if (interfaceSetting.ISystemValueImplementorList.Contains(iSystemValueImplementor))
            {
                interfaceSetting.ISystemValueImplementorList.Remove(iSystemValueImplementor);
            }
            fpInterfaces_Sheet1.Rows.Remove(cell.Row.Index,1);
            SendInterfaceToGlobalValue();
            if (Changed != null)
            {
                Changed(this, null);
            }
        }

        public void Up()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void Down()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int CheckInput()
        {
            fpInterfaces.StopCellEditing();
            return 1;
        }

        public List<InterfaceSettingToolStripButtonType> GetNeededToolStripButtons()
        {
            if (interfaceSettingToolStripButtonTypeList == null)
            {
                interfaceSettingToolStripButtonTypeList = new List<InterfaceSettingToolStripButtonType>();
                interfaceSettingToolStripButtonTypeList.Add(InterfaceSettingToolStripButtonType.Add);
                interfaceSettingToolStripButtonTypeList.Add(InterfaceSettingToolStripButtonType.Delete);
            }
            return interfaceSettingToolStripButtonTypeList;
        }

        public void Loaded()
        {
            SendInterfaceToGlobalValue();
        }

        #endregion

        #region IGlobalValueProvider 成员

        public event GlobalValueChangedHandle GlobalValueChanged;

        #endregion

        #region IChangedUserControl 成员

        public event EventHandler Changed;

        #endregion
    }
}
