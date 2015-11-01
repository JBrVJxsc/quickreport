using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace QuickReportCore.Forms
{
    internal partial class frmConditionSetting : frmBase,Interfaces.IHaveBeenChanged
    {
        public frmConditionSetting()
        {
            InitializeComponent();
        }

        public static System.Reflection.Assembly assembly;
        private Controls.ucConditionObject ucConditionObject;
        public static Hashtable htIConditionValueUserControlList = new Hashtable();
        private Interfaces.IConditionValue IConditionValueUserControl;

        internal void Init(Controls.ucConditionObject ucObject, Objects.Condition.InputValueType conditionInputType)
        {
            ucConditionObject = ucObject;
            IConditionValueUserControl = System.Activator.CreateInstance(htIConditionValueUserControlList[conditionInputType] as Type) as Interfaces.IConditionValue;
            if (IConditionValueUserControl == null)
                return;
            IConditionValueUserControl.ClickButton += new QuickReportCore.Interfaces.ClickButtonHandle(IConditionValueUserControl_ClickButton);
            (IConditionValueUserControl as Controls.ucChangedKnownBase).HaveBeenChanged += new QuickReportCore.Interfaces.HaveBeenChangedHandle(frmConditionSetting_HaveBeenChanged);
            Controls.Add(IConditionValueUserControl as Control);
            IConditionValueUserControl.InitValue(ucConditionObject.Condition);
        }

        void frmConditionSetting_HaveBeenChanged(object sender, EventArgs e)
        {
            if (HaveBeenChanged != null)
                HaveBeenChanged(sender, e);
        }

        void IConditionValueUserControl_ClickButton(System.Xml.XmlElement defaultValue)
        {
            if (defaultValue != null)
            {
                System.Xml.XmlElement node = Forms.frmQuickReportEditor.xmlDocument.CreateElement(QuickReportCore.Controls.ucConditionObject.XmlAttrDic.ConditionSetting.ToString());
                node.AppendChild(defaultValue);
                ucConditionObject.Condition.ConditionSetting = node;
            }
            Close();
        }

        static frmConditionSetting()
        {
            assembly = System.Reflection.Assembly.LoadFrom("QuickReportCore.dll");
            Type[] types = assembly.GetTypes();
            List<Type> typeList = new List<Type>();
            for (int i = 0; i < types.Length; i++)
            {
                if (types[i].GetInterface(typeof(Interfaces.IConditionValue).FullName) == null)
                    continue;
                Interfaces.IConditionValue uc = System.Activator.CreateInstance(types[i]) as Interfaces.IConditionValue;
                if (!htIConditionValueUserControlList.Contains(uc.InputValueType))
                    htIConditionValueUserControlList.Add(uc.InputValueType, uc.GetType());
            }
        }

        #region IHaveBeenChanged ³ÉÔ±

        public event QuickReportCore.Interfaces.HaveBeenChangedHandle HaveBeenChanged;

        #endregion
    }
}