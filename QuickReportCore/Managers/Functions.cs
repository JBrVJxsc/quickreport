using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Collections;
using System.Data;

namespace QuickReportCore.Managers
{
    internal class Functions
    {
        private const Int32 AW_HOR_POSITIVE = 0x00000001;
        private const Int32 AW_HOR_NEGATIVE = 0x00000002;
        private const Int32 AW_VER_POSITIVE = 0x00000004;
        private const Int32 AW_VER_NEGATIVE = 0x00000008;
        private const Int32 AW_CENTER = 0x00000010;
        private const Int32 AW_HIDE = 0x00010000;
        private const Int32 AW_ACTIVATE = 0x00020000;
        private const Int32 AW_SLIDE = 0x00040000;
        private const Int32 AW_BLEND = 0x00080000;

        public static ToolTip toolTip;
        static Functions()
        {
            toolTip = new ToolTip();
            toolTip.ToolTipIcon = ToolTipIcon.Info;
            toolTip.ForeColor = Color.Blue;
            toolTip.ToolTipTitle = "��ʾ";
            toolTip.ShowAlways = true;
        }

        static void InitToolTip()
        {
            toolTip.Dispose();
            toolTip = new ToolTip();
            toolTip.ToolTipIcon = ToolTipIcon.Info;
            toolTip.ForeColor = Color.Blue;
            toolTip.ToolTipTitle = "��ʾ";
            toolTip.ShowAlways = true;
        }

        public static void ShowToolTip(Control c, string message)
        {
            InitToolTip();
            toolTip.Show(message, c, 5000);
        }

        public static void ShowToolTip(Control c, string message, bool focus)
        {
            InitToolTip();
            toolTip.Show(message, c, 5000);
            if (focus)
                c.Focus();
        }

        public static void ShowToolTip(Control c, string message, int during)
        {
            InitToolTip();
            toolTip.Show(message, c, during);
        }

        public static void ShowToolTip(Control c, string message, Point location)
        {
            InitToolTip();
            toolTip.Show(message, c, location, 5000);
        }

        public static void ShowToolTip(Control c, string message, int during, Point location)
        {
            InitToolTip();
            toolTip.Show(message, c, location, during);
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern bool AnimateWindow(
         IntPtr hwnd,
         int dwTime,
         int dwFlags
         );

        /// <summary>
        /// ����Ч�����ô��ڵ��롣
        /// </summary>
        /// <param name="handle">�����ָ�롣</param>
        /// <param name="duringTime">����ʱ�䡣</param>
        public static void AnimateWindowBlendIn(IntPtr handle, int duringTime)
        {
            AnimateWindow(handle, duringTime, AW_BLEND | AW_ACTIVATE);
        }

        /// <summary>
        /// ����Ч�����ô��ڵ�����
        /// </summary>
        /// <param name="handle">�����ָ�롣</param>
        /// <param name="duringTime">����ʱ�䡣</param>
        public static void AnimateWindowBlendOut(IntPtr handle, int duringTime)
        {
            AnimateWindow(handle, duringTime, AW_SLIDE | AW_HIDE | AW_BLEND);
        }

        [DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto, ExactSpelling = true)]
        private static extern IntPtr GetForegroundWindow();
        /// <summary>
        /// ��õ�ǰ����ڵľ����
        /// </summary>
        /// <returns>��ǰ����ڵľ����</returns>
        public static IntPtr GetActivityWindow()
        {
            return GetForegroundWindow();
        }

        const int WM_NCACTIVATE = 0x86;
        const int WA_ACTIVE = 0x1;
        const int WA_UNACTIVE = 0x0;
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private static extern int SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);
        /// <summary>
        /// ʹĳ���崦�ڷǼ���״̬��
        /// </summary>
        /// <param name="handle">����ľ����</param>
        /// <returns>�Ƿ�ɹ���</returns>
        public static int SetWindowUnActivate(IntPtr handle)
        {
            return SendMessage(handle, WM_NCACTIVATE, WA_UNACTIVE, 0);
        }

        /// <summary>
        /// ʹĳ�����ü���״̬��
        /// </summary>
        /// <param name="handle">����ľ����</param>
        /// <returns>�Ƿ�ɹ���</returns>
        public static int SetWindowActivate(IntPtr handle)
        {
            return SendMessage(handle, WM_NCACTIVATE, WA_ACTIVE, 0);
        }

        static Managers.QuickReportManager qr = new QuickReportManager();
        /// <summary>
        /// ����Sql��
        /// </summary>
        /// <returns>��������������������</returns>
        public static ArrayList ParseSql(string s)
        {
            if (s.Trim() == string.Empty)
                return null;
            s = TranslateTextWithSystemValue(s);
            s = "Select * From ( \n " + s + " \n )  Where 1<>1";
            DataSet ds = new DataSet();
            int i = qr.ExecQuery(s, ref ds);
            if (i < 0)
                return null;
            if (ds == null || ds.Tables == null || ds.Tables.Count == 0)
                return null;
            DataTable dt = ds.Tables[0];

            List<QuickReportCore.Objects.Column> columnList = new List<QuickReportCore.Objects.Column>();
            List<QuickReportCore.Objects.Condition> conditionList = new List<QuickReportCore.Objects.Condition>();

            Hashtable htTestor = new Hashtable();
            for (int index = 0; index < dt.Columns.Count; index++)
            {
                if (htTestor.Contains(dt.Columns[index].ColumnName))
                    return null;
                htTestor.Add(dt.Columns[index].ColumnName, dt.Columns[index].ColumnName);
                QuickReportCore.Objects.Column column = new QuickReportCore.Objects.Column();
                QuickReportCore.Objects.Condition condition = new QuickReportCore.Objects.Condition();
                column.ID = condition.ID = column.Name = condition.Name = dt.Columns[index].ColumnName;
                column.SortId = condition.SortId = index;
                if (dt.Columns[index].DataType == typeof(System.Decimal) || dt.Columns[index].DataType == typeof(System.Int32))
                {
                    column.IsNumber = true;
                }
                Objects.ConditionType ct = Objects.ConditionType.DataTypeCompareToConditionType[dt.Columns[index].DataType] as Objects.ConditionType;
                if (ct != null)
                    condition.ConditionType = ct;
                columnList.Add(column);
                conditionList.Add(condition);
            }
            ArrayList list = new ArrayList();
            list.Add(columnList);
            list.Add(conditionList);
            return list;
        }

        /// <summary>
        /// ��ȡSQL��ѯ���Ľ������ÿ�е��������͡�
        /// </summary>
        /// <param name="sql">SQL��</param>
        /// <returns>�������͵ļ��ϡ�</returns>
        static Objects.ConditionType[] GetDataType(string sql)
        {
            return null;
        }

        /// <summary>
        /// ����ϵͳ������ID���ϵͳ������ֵ��
        /// </summary>
        /// <param name="systemValueID">ϵͳ������ID��</param>
        /// <returns>ϵͳ������ֵ��</returns>
        public static string ConvertToSystemValue(string systemValueID)
        {
            return ((PublicInterfaces.ISystemValue)Forms.frmToolBoxSystemValue.htSystemValueList[systemValueID]).Value;
        }

        /// <summary>
        /// ��ʹ����ϵͳ������Text�е�ϵͳ���������滻�󲢷��ء�
        /// </summary>
        /// <param name="text">ԭText��</param>
        /// <returns>�滻���Text��</returns>
        public static string TranslateTextWithSystemValue(string text)
        {
            if (!text.Contains("["))//���text�в����б������򷵻�text��
                return text;
            foreach (DictionaryEntry de in Forms.frmToolBoxSystemValue.htSystemValueList)
            {
                text = text.Replace(Managers.Functions.GetSQLCode(de.Key.ToString(), SQLCodeType.System) , ((PublicInterfaces.ISystemValue)de.Value).Value);
            }
            return text;
        }

        /// <summary>
        /// ����XmlNode�Լ��������������ֵ��
        /// </summary>
        /// <param name="node">XmlNode��</param>
        /// <param name="attrName">��������</param>
        /// <param name="valueWhenNull">��NodeΪNullʱ�����ص�ֵ��</param>
        /// <returns>����ֵ</returns>
        public static string GetNodeAttrValue(System.Xml.XmlNode node,string attrName,string valueWhenNull)
        {
            if (node.Attributes[attrName] == null)
                return valueWhenNull;
            else
                return node.Attributes[attrName].Value;
        }


        [DllImport("user32.dll")]
        static extern void mouse_event(MouseEventFlag flags, int dx, int dy, uint data, UIntPtr extraInfo);
        [Flags]
        enum MouseEventFlag : uint
        {
            Move = 0x0001,
            LeftDown = 0x0002,
            LeftUp = 0x0004,
            RightDown = 0x0008,
            RightUp = 0x0010,
            MiddleDown = 0x0020,
            MiddleUp = 0x0040,
            XDown = 0x0080,
            XUp = 0x0100,
            Wheel = 0x0800,
            VirtualDesk = 0x4000,
            Absolute = 0x8000
        }

        /// <summary>
        /// �����ִ��һ�ε���������
        /// </summary>
        public static void MouseClick()
        {
            mouse_event(MouseEventFlag.LeftDown, 0, 0, 0, UIntPtr.Zero);
            mouse_event(MouseEventFlag.LeftUp, 0, 0, 0, UIntPtr.Zero);
        }

        /// <summary>
        /// �����ַ�����ø��ַ�����SQL�еı�ʾ��ʽ��
        /// </summary>
        /// <param name="code">�ַ�����</param>
        /// <param name="type">Code�ĵ����͡�</param>
        /// <returns>����SQL�еı�ʾ��ʽ��</returns>
        public static string GetSQLCode(string code,SQLCodeType type)
        {
            return "[" + type.ToString() + "-" + code + "]";
        }

        public enum SQLCodeType
        { 
            /// <summary>
            /// ����
            /// </summary>
            Tree,
            /// <summary>
            /// �С�
            /// </summary>
            Column,
            /// <summary>
            /// ������
            /// </summary>
            Condition,
            /// <summary>
            /// ϵͳ��
            /// </summary>
            System,
            /// <summary>
            /// ��̬�������������������ڲ�ѯ֮����е�ֵ��
            /// </summary>
            Dynamic
        }

        [DllImport("user32")]
        public static extern IntPtr GetSystemMenu(IntPtr hwnd, int bRevert);
        [DllImport("user32")]
        public static extern int RemoveMenu(IntPtr hMenu, int nPosition, int wFlags);
        public const int MF_BYPOSITION = 0x400;

        public static int RemoveCloseMenu(IntPtr hwnd)
        {
            return RemoveMenu(GetSystemMenu(hwnd, 0), 6, MF_BYPOSITION);
        }

        /// <summary>
        /// ����Dll���ƣ��Լ�������ʵ�ֵĽӿڣ���������з�������������Type��
        /// </summary>
        /// <param name="dllName">Dll���ơ�</param>
        /// <param name="interfaceType">�ӿ����͡�</param>
        /// <returns>Type���ϡ�</returns>
        public static List<Type> GetTypes(string dllName, Type interfaceType)
        {
            try
            {
                System.Reflection.Assembly assembly;
                List<Type> listType = new List<Type>();
                assembly = System.Reflection.Assembly.LoadFrom(dllName);
                Type[] types = assembly.GetTypes();
                for (int j = 0; j < types.Length; j++)
                {
                    if (types[j].GetInterface(interfaceType.Name) != null)
                        listType.Add(types[j]);
                }
                return listType;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// ����Dll���ƣ��Լ�������ʵ�ֵĽӿڣ���������з�������������Type��
        /// </summary>
        /// <param name="dllName">Dll���ơ�</param>
        /// <param name="interfaceType">�ӿ����͡�</param>
        /// <param name="type">���͵����͡�</param>
        /// <returns>Type���ϡ�</returns>
        public static List<Type> GetTypes(string dllName, Type interfaceType,TypeOfType type)
        {
            switch (type)
            {
                case TypeOfType.Interface:
                    {
                        try
                        {
                            System.Reflection.Assembly assembly;
                            List<Type> listType = new List<Type>();
                            assembly = System.Reflection.Assembly.LoadFrom(dllName);
                            Type[] types = assembly.GetTypes();
                            for (int j = 0; j < types.Length; j++)
                            {
                                if (types[j].GetInterface(interfaceType.Name) != null&&types[j].IsInterface)
                                    listType.Add(types[j]);
                            }
                            return listType;
                        }
                        catch
                        {
                            return null;
                        }
                    }
                case TypeOfType.Class:
                    {
                        try
                        {
                            System.Reflection.Assembly assembly;
                            List<Type> listType = new List<Type>();
                            assembly = System.Reflection.Assembly.LoadFrom(dllName);
                            Type[] types = assembly.GetTypes();
                            for (int j = 0; j < types.Length; j++)
                            {
                                if (types[j].GetInterface(interfaceType.Name) != null && types[j].IsClass)
                                    listType.Add(types[j]);
                            }
                            return listType;
                        }
                        catch
                        {
                            return null;
                        }
                    }
                case TypeOfType.Enum:
                    {
                        try
                        {
                            System.Reflection.Assembly assembly;
                            List<Type> listType = new List<Type>();
                            assembly = System.Reflection.Assembly.LoadFrom(dllName);
                            Type[] types = assembly.GetTypes();
                            for (int j = 0; j < types.Length; j++)
                            {
                                if (types[j].GetInterface(interfaceType.Name) != null && types[j].IsEnum)
                                    listType.Add(types[j]);
                            }
                            return listType;
                        }
                        catch
                        {
                            return null;
                        }
                    }
            }
            return null;
        }

        /// <summary>
        /// ���͵����͡�
        /// </summary>
        public enum TypeOfType
        { 
            /// <summary>
            /// �ӿڡ�
            /// </summary>
            Interface,
            /// <summary>
            /// �ࡣ
            /// </summary>
            Class,
            /// <summary>
            /// ö�١�
            /// </summary>
            Enum
        }

        /// <summary>
        /// ����Dll�����������������ʵ����
        /// </summary>
        /// <param name="dllName">Dll���ơ�</param>
        /// <param name="className">������</param>
        /// <returns>���ʵ����</returns>
        public static object CreateInstance(string dllName, string className)
        {
            try
            {
                System.Reflection.Assembly assembly;
                assembly = System.Reflection.Assembly.LoadFrom(dllName.Trim());
                Type type = assembly.GetType(className.Trim());
                if (type == null)
                    return null;
                else
                    return System.Activator.CreateInstance(type);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// ��õ�ǰQuickReport�����°汾�š�
        /// </summary>
        /// <returns>���°汾�š�</returns>
        public static decimal GetLastestVersion()
        {
            decimal ver = 1.00m;
            try
            {
                List<Type> typeList = GetTypes("QuickReportCore.dll", typeof(Interfaces.IAmReport));
                for (int i = 0; i < typeList.Count; i++)
                {
                    decimal tempVer = (System.Activator.CreateInstance(typeList[i]) as Interfaces.IAmReport).Version;
                    if (tempVer > ver)
                        ver = tempVer;
                    else
                        continue;
                }
            }
            catch
            {
                return ver;
            }
            return ver;
        }

        /// <summary>
        /// ����XML�汾�ţ�������ʺϵ�UcReport��
        /// </summary>
        /// <param name="version">�汾�š�</param>
        /// <returns>Interfaces.IAmReport��</returns>
        public static Interfaces.IAmReport GetPerfectReportControl(decimal version)
        {
            if(0<version&&version<2)
                return System.Activator.CreateInstance(typeof(QuickReportCore.Controls.Report.ucReportV100)) as Interfaces.IAmReport;
            return null;
        }
    }
}
